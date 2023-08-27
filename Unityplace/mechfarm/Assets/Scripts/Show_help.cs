using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Show_help : MonoBehaviour
{
    public GameObject panel_help;
    public TMP_Text txt;
    private Read_Plant_Database plant;
    // Start is called before the first frame update
    void Start()
    {
        plant = GameObject.Find("Plant_Database").GetComponent<Read_Plant_Database>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Close_help()
    {
        panel_help.SetActive(false);
    }
    public void Open_help()
    {
        plant = GameObject.Find("Plant_Database").GetComponent<Read_Plant_Database>();
        txt.text = plant.plantData.Help;
        panel_help.SetActive(true);
    }
}
