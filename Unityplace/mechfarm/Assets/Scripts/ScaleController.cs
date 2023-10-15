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
        // ���Ƿ� �����س��� ( �ϴ� ��¥�� ������ ���� )
        startDate = new DateTime(2023, 10, 9, 8, 23, 0);
    }


    void Update()
    {
        DateTime currentDate = DateTime.Now;
        TimeSpan difference = currentDate - startDate;
        int day = difference.Days;

        // day ������ 10�� ����� ������ scale�� 1�� ����
        if (day % 10 == 0 && day <= 50)
        {
            // ������ scale ���� ������ ��, x, y, z ���� 1�� ������Ŵ
            Vector3 currentScale1 = plant1.transform.localScale;
            currentScale1.x += 1f;
            currentScale1.y += 1f;
            currentScale1.z += 1f;

            Vector3 currentScale2 = plant2.transform.localScale;
            currentScale2.x += 1f;
            currentScale2.y += 1f;
            currentScale2.z += 1f;

            // GameObject�� scale�� ����
            plant1.transform.localScale = currentScale1;
            plant2.transform.localScale = currentScale2;
        }
    }
}
