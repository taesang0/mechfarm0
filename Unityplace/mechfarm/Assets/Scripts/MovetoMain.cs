using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MovetoMain : MonoBehaviour
{
    public string user_id;

    public GameObject LoginObject;
    public TMP_InputField Input_id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveScene()
    {
        user_id = Input_id.text.ToString();

        SceneManager.LoadScene("Main");
        DontDestroyOnLoad(LoginObject);
    }
}
