using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class MoveScene : MonoBehaviour
{
    public string nickname;
    public string number;
    public string date;
    string data;
    DatabaseReference m_Reference;

    List<string> datatype = new List<string>() { "nickname","date","number" };

    // Start is called before the first frame update
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        ReadUserData();

        //FirebaseDatabase.DefaultInstance.GetReference("users").ValueChanged += HandleValueChanged;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Scenechange()
    {

        if (number == "0")
        {
            SceneManager.LoadScene("PlantSetting");
        }
        else{
            SceneManager.LoadScene("NewMain");
        }
       
    }

    void ReadUserData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users")
            .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
            // for ( int i = 0; i < snapshot.ChildrenCount; i++)
            //     Debug.Log(snapshot.Child(i.ToString()).Child("username").Value);
              
            // }
                for ( int i = 0; i < datatype.Count; i++){
                    // Debug.Log(snapshot.Child(userid).Child("plant").Child("lettuce").Child(datatype[i]).Value);
                    data = Convert.ToString(snapshot.Child(FirebaseAuthManager.SafeEmail).Child("plant").Child("lettuce").Child(datatype[i]).Value);
                // Debug.Log(datatype[i]);
                    // Debug.Log(data);
                    if (datatype[i]=="nickname") nickname=data;
                    else if (datatype[i]=="date") date=data;
                    else if (datatype[i]=="number") number=data;
                }
            }
        });
        Debug.Log("date: " + date + " number: " + number + " nickname: " + nickname);

    }
}
