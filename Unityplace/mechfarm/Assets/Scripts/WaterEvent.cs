using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class WaterEvent : MonoBehaviour
{
    DatabaseReference m_Reference;
    private FB_Read readFBScript; // Read_FB 컴포넌트를 저장하기 위한 변수

    public float water_value;

    void Start()
    {
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();
    }

    void Update()
    {
        if (readFBScript != null)
        {
            water_value = readFBScript.soil_humidity;
        }
        if (water_value >= 30)
        {
            falseactive();
        }

    }

    public void Water_onClick()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        if (water_value < 30)
        {
            gameObject.SetActive(true);
            WriteData("leets", "WaterSensor", 1);
        }
    }

    void falseactive()
    {
        gameObject.SetActive(false);
        WriteData("leets", "WaterSensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
