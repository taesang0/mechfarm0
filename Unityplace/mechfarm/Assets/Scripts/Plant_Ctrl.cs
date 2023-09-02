using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Ctrl : MonoBehaviour
{
    private FB_Read readFBScript; 
    private Read_Plant_Database PlantDBScript;
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
        PlantDBScript = GameObject.Find("Plant_Database").GetComponent<Read_Plant_Database>();

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
                max_value = 0.05f; // 그냥 +-10으로 기준잡음

                if (Mathf.Abs((readFBScript.temperature-PlantDBScript.plantData.Temperature_best)/(PlantDBScript.plantData.Temperature_max-PlantDBScript.plantData.Temperature_min))>max_value)
                {
                    max_value = Mathf.Abs((readFBScript.temperature-PlantDBScript.plantData.Temperature_best)/(PlantDBScript.plantData.Temperature_max-PlantDBScript.plantData.Temperature_min));
                    if ((readFBScript.temperature-PlantDBScript.plantData.Temperature_best)>0) max_state="temperature_H";
                    else max_state="temperature_L";
                }

                if (Mathf.Abs((readFBScript.humidity-PlantDBScript.plantData.Humidity_best)/(PlantDBScript.plantData.Humidity_max-PlantDBScript.plantData.Humidity_min))>max_value)
                {
                    max_value = Mathf.Abs((readFBScript.humidity-PlantDBScript.plantData.Humidity_best)/(PlantDBScript.plantData.Humidity_max-PlantDBScript.plantData.Humidity_min));
                    if ((readFBScript.humidity-PlantDBScript.plantData.Humidity_best)>0) max_state="humidity_H";
                    else max_state="humidity_L";
                }
                if (Mathf.Abs((readFBScript.soil_humidity-PlantDBScript.plantData.Soil_humidity_best)/(PlantDBScript.plantData.Soil_humidity_max-PlantDBScript.plantData.Soil_humidity_min))>max_value)
                {
                    max_value = Mathf.Abs((readFBScript.soil_humidity-PlantDBScript.plantData.Soil_humidity_best)/(PlantDBScript.plantData.Soil_humidity_max-PlantDBScript.plantData.Soil_humidity_min));
                    if ((readFBScript.soil_humidity-PlantDBScript.plantData.Soil_humidity_best)>0) max_state ="soil_humidity_H";
                    else max_state= "soil_humidity_L";
                }
                if (Mathf.Abs((readFBScript.lightness-PlantDBScript.plantData.Light_best)/(PlantDBScript.plantData.Light_max-PlantDBScript.plantData.Light_min))>max_value)
                {
                    max_value =Mathf.Abs((readFBScript.lightness-PlantDBScript.plantData.Light_best)/(PlantDBScript.plantData.Light_max-PlantDBScript.plantData.Light_min));
                    if ((readFBScript.lightness-PlantDBScript.plantData.Light_best)>0) max_state ="lightness_H";
                    else max_state= "lightness_L";

                }
                animator_manager(animator,max_state);

            }
            Debug.Log(max_value + " "+max_state);
        }
    }

    void animator_manager(Animator ani,string state)
    {
        if (state == "soil_humidity_H")
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
