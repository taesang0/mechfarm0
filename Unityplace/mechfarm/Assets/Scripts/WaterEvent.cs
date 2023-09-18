using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class WaterEvent : MonoBehaviour
{
    DatabaseReference m_Reference;
    private FB_Read readFBScript; // Read_FB ������Ʈ�� �����ϱ� ���� ����
    private Read_Plant_Database PlantDBScript;
    float water_value;
    public GameObject waterObject;
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
            water_value = readFBScript.soil_humidity;
        }
        if (water_value >= PlantDBScript.plantData.Soil_humidity_min)
        {
            falseactive();
            Debug.Log(PlantDBScript.plantData.Soil_humidity_min);
        }

    }

    public void Water_onClick()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        if (water_value < PlantDBScript.plantData.Soil_humidity_min)
        {
            waterObject.SetActive(true);
            WriteData("leets", "WaterSensor", 1);
        }
    }

    void falseactive()
    {
        waterObject.SetActive(false);
        WriteData("leets", "WaterSensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
