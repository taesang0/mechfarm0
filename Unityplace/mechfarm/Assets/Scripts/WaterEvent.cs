using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEvent : MonoBehaviour
{
    public void onClick()
    {
        gameObject.SetActive(true);
        Invoke("falseactive", 3.0f);
    }

    public void falseactive()
    {
        gameObject.SetActive(false);
    }
}
