using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEvent : MonoBehaviour
{
    public float waterValue = 0;
    public void onClick()
    {
        if (waterValue < 30)
        {
            gameObject.SetActive(true);
            Invoke("falseactive", 3.0f);
        }
    }

    public void falseactive()
    {
        gameObject.SetActive(false);
    }
}
