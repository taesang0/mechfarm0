using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumidityEvent : MonoBehaviour
{
    public GameObject fan;
    public GameObject fog;
    public float humidValue = 0;
    public void Humidity_onClick()
    { 
        if (humidValue > 70)
        {
            fan.SetActive(true);
            Invoke("falseactive", 3.0f);
        }
        else if(humidValue < 60)
        {
            fog.SetActive(true);
            Invoke("falseactive", 3.0f);
        }
    }
    public void falseactive()
    {
        fan.SetActive(false);
        fog.SetActive(false);
    }
}

