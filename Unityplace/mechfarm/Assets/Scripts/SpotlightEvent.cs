using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightEvent : MonoBehaviour
{
    public float spotValue = 0;
    public void onClick()
    {
        if (spotValue < 6000)
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
