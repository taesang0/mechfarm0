using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class Temperature : MonoBehaviour
{
    public GameObject wind;
    DatabaseReference m_Reference;
    private FB_Read readFBScript; // Read_FB ������Ʈ�� �����ϱ� ���� ����
    private Read_Plant_Database PlantDBScript;
    float temperature_value;

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
            temperature_value = readFBScript.temperature;
        }
        if (temperature_value <= PlantDBScript.plantData.Temperature_max&& temperature_value >=PlantDBScript.plantData.Temperature_min)
        {
            falseactive(); 
        }
 
    }

    public void temp_onClick()
    {

        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (temperature_value > PlantDBScript.plantData.Temperature_max)
        {
            wind.SetActive(true);
            WriteData("leets", "TemperatureSensor", 1);
        }

        else if (temperature_value < PlantDBScript.plantData.Temperature_min)
        {
            WriteData("leets", "TemperatureSensor", 2);
        }

    } 

    void falseactive ()
    {
        wind.SetActive(false);
        WriteData("leets", "TemperatureSensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
