using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public float hydrationLevel = 100.0f; // 초기 수분 레벨
    public float hydrationThreshold = 30.0f; // 수분 부족 임계치
    public float hydrationDecreaseRate = 1.0f; // 수분 감소 속도 (예: 초당 1씩 감소)

    private PushNotificationManager notificationManager;

    private void Start()
    {
        notificationManager = GetComponent<PushNotificationManager>();
        InvokeRepeating("DecreaseHydration", 1.0f, 1.0f); // 1초마다 수분 감소
    }

    private void DecreaseHydration()
    {
        // 수분을 주기적으로 감소시킴
        hydrationLevel -= hydrationDecreaseRate;

        // 수분이 부족한 경우 푸시 알림을 보냄
        if (hydrationLevel < hydrationThreshold)
        {
            SendHydrationNotification();
        }
    }

    private void SendHydrationNotification()
    {
        string title = "주의: 수분 부족!";
        string body = "캐릭터의 수분이 부족합니다. 물을 마셔주세요.";

        // 푸시 알림을 보냄
        notificationManager.SendPushNotification(title, body);
    }
}

