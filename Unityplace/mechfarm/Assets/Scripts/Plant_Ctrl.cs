using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Ctrl : MonoBehaviour
{
    private FB_Read readFBScript; 
    string max_state;
    float max_value;
    private Animator animator;
    // public State state = State.IDLE;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();

        if (readFBScript == null)
        {
            Debug.LogWarning("Read_FB component not found.");
        }
        StartCoroutine(CheckState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckState()
    {
        while(true)
        {
            yield return new WaitForSeconds(4.3f);
            if (readFBScript != null)
            {
                max_value = 10.0f; // 그냥 +-10으로 기준잡음

                if (Mathf.Abs(readFBScript.temperature-50.0f)>max_value)
                {
                    max_value = Mathf.Abs(readFBScript.temperature-50.0f);
                    if (readFBScript.temperature-50.0f>0) max_state="temperature_H";
                    else max_state="temperature_L";
                }

                if (Mathf.Abs(readFBScript.humidity-50.0f)>max_value)
                {
                    max_value = Mathf.Abs(readFBScript.humidity-50.0f);
                    if (readFBScript.humidity-50.0f>0) max_state="humidity_H";
                    else max_state="humidity_L";
                }
                else if (Mathf.Abs(readFBScript.soil_humidity-50.0f)>max_value)
                {
                    max_value = Mathf.Abs(readFBScript.soil_humidity-50.0f);
                    if (readFBScript.soil_humidity-50.0f>0) max_state ="soil_humidity_H";
                    else max_state= "soil_humidity_L";
                }
                else if (Mathf.Abs(readFBScript.lightness-50.0f)>max_value)
                {
                    max_value = Mathf.Abs(readFBScript.lightness-50.0f);
                    if (readFBScript.lightness-50.0f>0) max_state ="lightness_H";
                    else max_state= "lightness_L";

                }
                animator_manager(animator,max_state);

            }
            Debug.Log(max_state);
        }
    }

    void animator_manager(Animator ani,string state)
    {
        if (state == "soil_hummidity_H")
        {
            ani.SetBool("dry",true);
            ani.SetBool("hot",false);
            ani.SetBool("cold",false);
            ani.SetBool("smile",false);
        }
        else if (state == "temperature_H")
        {
            ani.SetBool("dry",false);
            ani.SetBool("hot",true);
            ani.SetBool("cold",false);
            ani.SetBool("smile",false);
        }
        else if (state == "temperature_L")
        {
            ani.SetBool("dry",false);
            ani.SetBool("hot",false);
            ani.SetBool("cold",true);
            ani.SetBool("smile",false);
        }
    }

}
