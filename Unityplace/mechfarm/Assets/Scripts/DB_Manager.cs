using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    public string DBurl = "https://farm0-b92d3-default-rtdb.firebaseio.com";
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
         FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(DBurl);
         Debug.Log(FirebaseAuthManager.SafeEmail);
        //  WriteDB();
          ReadDB();
    }

    public void WriteDB(){

    }

    public void ReadDB(){
        reference = FirebaseDatabase.DefaultInstance.GetReference("users");
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
        
                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary userData = (IDictionary)data.Value;
                    Debug.Log("이름 : " + userData["users"] + "" + userData["leets"]);
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
