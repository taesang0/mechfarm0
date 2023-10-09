using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    public TMP_InputField email;
    public TMP_InputField password;
    public static string SafeEmail;

    public string DBurl = "https://farm0-b92d3-default-rtdb.firebaseio.com/";
    DatabaseReference reference;
    private bool state;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        state = false;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        });

    }

    public void Create()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("회원가입 실패");
                return;
            }

            FirebaseUser newUser = task.Result.User; // Get the FirebaseUser from AuthResult
            Debug.Log("회원가입 완료");
            WriteDB(email.text);
        });
    }

    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log(email.text + " 로 로그인 하셨습니다.");
                SafeEmail = email.text.Split('@')[0];
                state = true;
            }
            else
            {
                Debug.Log("로그인에 실패하셨습니다.");
            }
        });
    }

    public void Update()
    {
        if (state == true)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("로그아웃");
    }

    public void WriteDB(string email)
    {
        Debug.Log("DB 실행");

        SafeEmail = email.Split('@')[0]; // email에서 @ 앞 부분만 가져옵니다.

        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        // 식물 이름들의 리스트
        List<string> plantNames = new List<string> { "lettuce", "strawberry", "tomato", "potato" };

        foreach (string plantName in plantNames)
        {
            UserData user = new UserData(email, plantName); // 각 식물 이름에 대한 UserData를 생성합니다.

            // users/(로그인한 이메일의 @ 앞부분)/plant/(식물 이름)/ 아래에 데이터를 저장합니다.
            reference.Child("users").Child(SafeEmail).Child("plant").Child(plantName).Child("humi").SetValueAsync(user.humi);
            reference.Child("users").Child(SafeEmail).Child("plant").Child(plantName).Child("light").SetValueAsync(user.light);
            reference.Child("users").Child(SafeEmail).Child("plant").Child(plantName).Child("soil_humi").SetValueAsync(user.soil_humi);
            reference.Child("users").Child(SafeEmail).Child("plant").Child(plantName).Child("temp").SetValueAsync(user.temp);

            // 회원가입한 날짜를 저장합니다.
            reference.Child("users").Child(SafeEmail).Child("plant").Child(plantName).Child("start_date").SetValueAsync(currentDate);
        }
    }


}

public class UserData
{
    public string userName = "";
    public string plantName = "";
    public int humi = 0;
    public int light = 0;
    public int soil_humi = 0;
    public int temp = 0;

    public UserData(string userName, string defultPlantName)
    {
        this.userName = userName;
        this.plantName = defultPlantName;
    }

    public void setPlantName(string plantName)
    {
        plantName = this.plantName;
    }

    public void setHumi()
    {
        humi = this.humi;
    }

    public void setLight()
    {
        light = this.light;
    }

    public void setSoilHumi()
    {
        soil_humi = this.soil_humi;
    }

    public void setTemp()
    {
        temp = this.temp;
    }
}
