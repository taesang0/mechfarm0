using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene_setting : MonoBehaviour
{
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
    public void Scenechange_NewMain()
    {
        SceneManager.LoadScene("NewMain");
    }
    public void Scenechange_LoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
