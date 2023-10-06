using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class SpotlightEvent : MonoBehaviour
{
    
    DatabaseReference m_Reference;
    private FB_Read readFBScript; // Read_FB ������Ʈ�� �����ϱ� ���� ����
    private Read_Plant_Database PlantDBScript;
    float spotlight_value;
    public GameObject lightObject;

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
            spotlight_value = readFBScript.lightness;
        }
        if (spotlight_value >= PlantDBScript.plantData.Light_min)
        {
            falseactive();
        }

    }

    public void Spotlight_onClick()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (spotlight_value < PlantDBScript.plantData.Light_min)
        {
            lightObject.SetActive(true);
            WriteData("leets", "SpotlightSensor", 1);
        }

    }
    void falseactive()
    {
        lightObject.SetActive(false);
        WriteData("leets", "SpotlightSensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
