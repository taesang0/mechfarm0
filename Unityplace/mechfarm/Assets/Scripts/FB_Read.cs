using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
public class FB_Read : MonoBehaviour
{
    DatabaseReference m_Reference;
    string userid = "leets";
    
    public float temperature;
    public float humidity;
    public float soil_humidity;
    public float lightness;
    float data;
    // string userid;
    GameObject LoginOB;

    List<string> datatype = new List<string>() { "temp","humi","soil_humi","light" };

    // Start is called before the first frame update
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        ReadUserData();
        FirebaseDatabase.DefaultInstance.GetReference("users").ValueChanged += HandleValueChanged;
        LoginOB= GameObject.Find("LoginObject");
        // userid=LoginOB.GetComponent<MovetoMain>().user_id;
        Debug.Log(userid);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        if (args.Snapshot != null && args.Snapshot.Exists)
        {
            // 데이터가 변경되었을 때 실행될 코드
            ReadUserData();
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
                for ( int i = 0; i < datatype.Count; i++){
                    // Debug.Log(snapshot.Child(userid).Child("plant").Child("lettuce").Child(datatype[i]).Value);
                    data = Convert.ToSingle(snapshot.Child(userid).Child("plant").Child("lettuce").Child(datatype[i]).Value);
                // Debug.Log(datatype[i]);
                    // Debug.Log(data);
                    if (datatype[i]=="temp") temperature=data;
                    else if (datatype[i]=="humi") humidity=data;
                    else if (datatype[i]=="soil_humi") soil_humidity=data;
                    else if (datatype[i]=="light") lightness=data;
                }
                Debug.Log("temp: " + temperature.ToString() + " humi: " + humidity.ToString() + " soil_humi: " + soil_humidity.ToString() + " light: " + lightness.ToString());
            }
        });
    }
}
