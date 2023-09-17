using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class Temperature : MonoBehaviour
{
    public GameObject icepack;
    public GameObject stove;
    DatabaseReference m_Reference;
    string userid = "leets";
    public float tempValue = 0;
    public GameObject lettuce;
    private Animator animator;

    // public State state = State.IDLE;

    void Start()
    {
        animator = lettuce.GetComponent<Animator>();
        
 
    }

    private void Update()
    {
        
    }
    public void temp_onClick()
    {

        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (tempValue > 25)
        {
            icepack.SetActive(true);
            WriteData("leets", "TemperatureSensor", 1);
            Invoke("falseactive", 3.0f);
            if (icepack.activeSelf)
            {
                animator.SetBool("hot",false);
            }
        }
        else if (tempValue <15)
        {
            stove.SetActive(true);
            WriteData("leets", "TemperatureSensor", 2);
            Invoke("falseactive", 3.0f);
        }
    }

    public void falseactive()
    {
        stove.SetActive(false);
        icepack.SetActive(false);
    }

    void WriteData(string userId, string sensorname, int value)
    {
        m_Reference.Child("users").Child(userId).Child("Actuator").Child(sensorname).SetValueAsync(value);
    }
}
