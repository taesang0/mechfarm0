using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class SpotlightEvent : MonoBehaviour
{
    
    DatabaseReference m_Reference;
    private FB_Read readFBScript; // Read_FB 컴포넌트를 저장하기 위한 변수

    public float spotlight_value = 0;

    void Start()
    {
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();
    }

    void Update()
    {
        if (readFBScript != null)
        {
            spotlight_value = readFBScript.lightness;
        }
        if (spotlight_value >= 6000)
        {
            falseactive();
        }

    }

    public void Spotlight_onClick()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (spotlight_value < 6000)
        {
            gameObject.SetActive(true);
            WriteData("leets", "SpotlightSensor", 1);
        }

    }
    void falseactive()
    {
        gameObject.SetActive(false);
        WriteData("leets", "SpotlightSensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
