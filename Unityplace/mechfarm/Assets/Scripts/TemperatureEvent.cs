using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    public GameObject fan;
    public GameObject stove;
    public float tempValue = 0;
    public void temp_onClick()
    {
        if (tempValue > 50)
        {
            fan.SetActive(true);
            Invoke("falseactive", 3.0f);
        }
        else
        {
            stove.SetActive(true);
            Invoke("falseactive", 3.0f);
        }
    }
    public void falseactive()
    {
        stove.SetActive(false);
        fan.SetActive(false);
    }
}
