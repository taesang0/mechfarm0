using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class Temperature : MonoBehaviour
{
    public GameObject icepack;
    public GameObject stove;
    DatabaseReference m_Reference;
    private FB_Read readFBScript; // Read_FB 컴포넌트를 저장하기 위한 변수
    float temperature_value;

    void Start()
    {
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();
    }

    void Update()
    {
        if (readFBScript != null)
        {
            temperature_value = readFBScript.temperature;
        }
        if (temperature_value <= 25 || temperature_value >=15)
        {
            falseactive(); 
        }
 
    }

    public void temp_onClick()
    {

        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (temperature_value > 25)
        {
            icepack.SetActive(true);
            WriteData("leets", "TemperatureSensor", 1);
        }

        else if (temperature_value < 15)
        {
            stove.SetActive(true);
            WriteData("leets", "TemperatureSensor", 2);
        }

 
    } 

    void falseactive ()
    {
        stove.SetActive(false);
        icepack.SetActive(false);
        WriteData("leets", "TemperatureSensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
