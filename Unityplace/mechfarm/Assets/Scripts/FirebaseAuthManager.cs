using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;



public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    public TMP_InputField email;
    public TMP_InputField password;

    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }
    void Create()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => 
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("회원가입 실패");
                return;
            }
            
            FirebaseUser newUser = task.Result.User; // Get the FirebaseUser from AuthResult
            Debug.LogError("회원가입 완료");
        });
    }

    void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => 
        {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("로그인 실패");
                return;
            }
            
            FirebaseUser newUser = task.Result.User; // Get the FirebaseUser from AuthResult
            Debug.LogError("로그인 완료");
        });
    }

    void LogOut(){
        auth.SignOut();
        Debug.Log("로그아웃");
    }

}
