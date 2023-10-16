using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class Create_Plant : MonoBehaviour
{
    public GameObject[] Plant;
    public Transform[] Spawnpoint;
    // public GameObject[] myInstance;
    public List<GameObject> myInstance = new List<GameObject>();
    DatabaseReference m_Reference;
    int number=0;
    string userid = "leets";
    string startDate = "20231010";
    DateTime currentDate;
    DateTime startDateDateTime;
    TimeSpan difference;
    int daysDifference=0;
    float scale=1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine(FetchUserData());
        

        
    }

    private IEnumerator FetchUserData()
    {
        yield return FirebaseDatabase.DefaultInstance
            .GetReference("users")
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    number = int.Parse(snapshot.Child(userid).Child("plant").Child("lettuce").Child("number").Value.ToString());
                    Debug.Log("Number of lettuce plants: " + number);
                    startDate = snapshot.Child(userid).Child("plant").Child("lettuce").Child("date").Value.ToString();
                    // startDate를 DateTime 형식으로 변환
                    startDateDateTime = DateTime.ParseExact(startDate, "yyyyMMdd", null);
                    DateTime currentDate = DateTime.Now;
                    // 두 날짜 간의 차이 계산
                    difference = currentDate - startDateDateTime;
                    daysDifference = difference.Days;
                    Debug.Log(startDateDateTime+"Days : "+currentDate);
                    scale = daysDifference * 0.1f;
                    // Instantiate plants based on the retrieved number
                    for (int i = 0; i < number; i++)
                    {
                        if (MoveScene_setting.kind_of_plant == "lettuce")
                        {
                            GameObject instance = Instantiate(Plant[0]);
                            instance.transform.position = Spawnpoint[i].position;
                            instance.SetActive(true);
                            instance.transform.localScale = new Vector3(scale,scale,scale);
                            myInstance.Add(instance);
                        }
                        else if (MoveScene_setting.kind_of_plant == "herb")
                        {
                            GameObject instance = Instantiate(Plant[1]);
                            instance.transform.position = Spawnpoint[i].position;
                            instance.SetActive(true);
                            instance.transform.localScale = new Vector3(scale,scale,scale);
                            myInstance.Add(instance);
                        }
                        else
                        {
                            GameObject instance = Instantiate(Plant[0]);
                            instance.transform.position = Spawnpoint[i].position;
                            instance.SetActive(true);
                            instance.transform.localScale = new Vector3(scale,scale,scale);
                            myInstance.Add(instance);
                        }

                        
                        
                    }
                }
            });

    }

    // void Start()
    // {
    //     m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
    //     ReadUserData();

        
    //     if (MoveScene_setting.kind_of_plant =="lettuce")
    //     {
    //         for(int i=0; i<=number+1 && i < Spawnpoint.Length;i++){
    //             myInstance[i] = Instantiate(Plant[0]);
    //             myInstance[i].transform.position = Spawnpoint[i].position;        // Component에 접근 
    //             // myInstance.GetComponent<MyChild>().Init();
    //             // 오브젝트를 월드상에 보이도록 설정
    //             myInstance[i].SetActive(true);
    //         }
    //     }
    //     if (MoveScene_setting.kind_of_plant =="herb")
    //     {
    //         for(int i=0; i<number+1 && i < Spawnpoint.Length;i++){
    //             myInstance[i] = Instantiate(Plant[1]);
    //             myInstance[i].transform.position = Spawnpoint[i].position;        // Component에 접근 
    //             // myInstance.GetComponent<MyChild>().Init();
    //             // 오브젝트를 월드상에 보이도록 설정
    //             myInstance[i].SetActive(true);
    //         }
    //     }
    //     else{
    //         for(int i=0; i<number+1 && i < Spawnpoint.Length;i++){
    //             myInstance[i] = Instantiate(Plant[0]);
    //             myInstance[i].transform.position = Spawnpoint[i].position;        // Component에 접근 
    //             // myInstance.GetComponent<MyChild>().Init();
    //             // 오브젝트를 월드상에 보이도록 설정
    //             myInstance[i].SetActive(true);
    //         }
    //     }
    // }
    void ReadUserData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users")
            .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Debug.Log(snapshot.Child(userid).Child("plant").Child("lettuce").Child("number").Value.ToString());
                number = int.Parse(snapshot.Child(userid).Child("plant").Child("lettuce").Child("number").Value.ToString());
                Debug.Log(number);
                startDate = snapshot.Child(userid).Child("plant").Child("lettuce").Child("number").Value.ToString();
                Debug.Log(startDate);
            }
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
