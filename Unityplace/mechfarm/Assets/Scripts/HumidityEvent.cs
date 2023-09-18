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
    private FB_Read readFBScript; // Read_FB ������Ʈ�� �����ϱ� ���� ����
    private Read_Plant_Database PlantDBScript;

    float humidity_value;

    void Start()
    {
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();
        PlantDBScript = GameObject.Find("Plant_Database").GetComponent<Read_Plant_Database>();
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    void Update()
    {
        if (readFBScript != null)
        {
            humidity_value = readFBScript.humidity;
        }
        if (humidity_value >=PlantDBScript.plantData.Humidity_min && humidity_value<=PlantDBScript.plantData.Humidity_max)
        {
            falseactive();
        }

    }
    public void Humidity_onClick()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (humidity_value > PlantDBScript.plantData.Humidity_max)
        {
            fan.SetActive(true);
            WriteData("leets", "HumiditySensor", 1);
        }
        else if (humidity_value < PlantDBScript.plantData.Humidity_min)
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

