using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
 
public class CFirebase : MonoBehaviour
{
    DatabaseReference m_Reference;
    string userid = "leets";
   
    List<string> datatype = new List<string>() { "temp","humi","soil_humi","light" };
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
 
        WriteData("leets", "lettuce","33");
        // WriteData("leets", "lettuce","humi","43");
        // WriteData("leets", "lettuce","soil_humi","53");
        // WriteData("leets", "lettuce","light","63");

        ReadUserData();
 
 
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
            for ( int i = 0; i < datatype.Count; i++)
                Debug.Log(snapshot.Child(userid).Child("plant").Child("lettuce").Child(datatype[i]).Value);
                // Debug.Log(datatype[i]);
            }
        });
        
    }
    void WriteData(string userId, string sensorname, string value)
    {
        m_Reference.Child("users").Child(userId).Child("plant").Child(sensorname).Child("temp").SetValueAsync(value);
    }
    

 
}
 