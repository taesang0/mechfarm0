using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public GameObject plant1;
    public GameObject plant2;
    public DateTime startDate; 

    void Start()
    {
        // 임의로 설정해놓음 ( 일단 날짜로 스케일 변경 )
        startDate = new DateTime(2023, 10, 9, 8, 23, 0);
    }


    void Update()
    {
        DateTime currentDate = DateTime.Now;
        TimeSpan difference = currentDate - startDate;
        int day = difference.Days;

        // day 변수가 10의 배수일 때마다 scale을 1씩 증가
        if (day % 10 == 0 && day <= 50)
        {
            // 현재의 scale 값을 가져온 후, x, y, z 각각 1씩 증가시킴
            Vector3 currentScale1 = plant1.transform.localScale;
            currentScale1.x += 1f;
            currentScale1.y += 1f;
            currentScale1.z += 1f;

            Vector3 currentScale2 = plant2.transform.localScale;
            currentScale2.x += 1f;
            currentScale2.y += 1f;
            currentScale2.z += 1f;

            // GameObject의 scale을 변경
            plant1.transform.localScale = currentScale1;
            plant1.transform.localScale = currentScale2;
        }
    }
}
