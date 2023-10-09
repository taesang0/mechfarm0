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
    public GameObject lightObject1;
    public GameObject lightObject2;
    public GameObject lightObject3;
    public GameObject lightObject4;
    public GameObject lightObject5;

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
            lightObject1.SetActive(true);
            lightObject2.SetActive(true);
            lightObject3.SetActive(true);
            lightObject4.SetActive(true);
            lightObject5.SetActive(true);
            WriteData("leets", "SpotlightSensor", 1);
        }

    }
    void falseactive()
    {
        lightObject1.SetActive(false);
        lightObject2.SetActive(false);
        lightObject3.SetActive(false);
        lightObject4.SetActive(false);
        lightObject5.SetActive(false);

        WriteData("leets", "SpotlightSensor", 0);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
