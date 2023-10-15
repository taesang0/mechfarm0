using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene_setting : MonoBehaviour
{
    public static string kind_of_plant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scenechange()
    {
        SceneManager.LoadScene("PlantSetting");
    }
    public void Scenechange_NewMain_lettuce()
    {
        SceneManager.LoadScene("NewMain");
        kind_of_plant = "lettuce";
    }
    public void Scenechange_NewMain_herb()
    {
        SceneManager.LoadScene("NewMain");
        kind_of_plant = "herb";
    }
    public void Scenechange_LoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
