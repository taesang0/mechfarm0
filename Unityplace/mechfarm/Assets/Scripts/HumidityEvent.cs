using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class HumidityEvent : MonoBehaviour
{
    public GameObject fan;
    public GameObject fog;
    DatabaseReference m_Reference;
    private FB_Read readFBScript; // Read_FB 컴포넌트를 저장하기 위한 변수

    float humidity_value;

    void Start()
    {
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();
    }
    void Update()
    {
        if (readFBScript != null)
        {
            humidity_value = readFBScript.humidity;
        }
        if (humidity_value >=60 || humidity_value<=70)
        {
            falseactive();
        }

    }
    public void Humidity_onClick()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (humidity_value > 70)
        {
            fan.SetActive(true);
            WriteData("leets", "HumiditySensor", 1);
        }
        else if (humidity_value < 60)
        {
            fog.SetActive(true);
            WriteData("leets", "HumiditySensor", 2);
        }

    }
    void falseactive()
    {
        fan.SetActive(false);
        fog.SetActive(false);
        WriteData("leets", "HumiditySensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}

