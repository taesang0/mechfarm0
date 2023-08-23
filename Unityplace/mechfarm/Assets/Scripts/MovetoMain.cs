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

    private void OnEnable(){
        Debug.Log("Subscribing to OnLoginSuccess event.");
        FirebaseAuthManager.OnLoginSuccess += moveScene;
    }

    private void OnDisable(){
        Debug.Log("Unsubscribing from OnLoginSuccess event.");
        FirebaseAuthManager.OnLoginSuccess -= moveScene;
    }
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
        Debug.Log("Moving to Main scene.");
        user_id = Input_id.text.ToString();
        Debug.Log("Current active scene: " + SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Main");
        Debug.Log("Current active scene: " + SceneManager.GetActiveScene().name);

        DontDestroyOnLoad(LoginObject);
    }
}
