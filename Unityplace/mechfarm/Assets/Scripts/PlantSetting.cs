using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlantSetting : MonoBehaviour
{

    DatabaseReference m_Reference;
    public TMP_InputField year;
    public TMP_InputField month;
    public TMP_InputField day;
    public TMP_InputField nickname;
    public TMP_InputField number;
    string date;
    // Start is called before the first frame update
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void save_click()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        Writenickname("lettuce",nickname.text);
        Writenumber("lettuce",number.text);
        date=year.text+month.text+day.text;
        WriteDate("lettuce",date);


        SceneManager.LoadScene("NewMain");
    }
    void WriteDate(string plantname, string value)
    {
        m_Reference.Child("users").Child(FirebaseAuthManager.SafeEmail).Child("plant").Child(plantname).Child("date").SetValueAsync(value);
    }
    void Writenickname(string plantname, string value)
    {
        m_Reference.Child("users").Child(FirebaseAuthManager.SafeEmail).Child("plant").Child(plantname).Child("nickname").SetValueAsync(value);
    }
    void Writenumber(string plantname, string value)
    {
        m_Reference.Child("users").Child(FirebaseAuthManager.SafeEmail).Child("plant").Child(plantname).Child("number").SetValueAsync(value);
    }

}
