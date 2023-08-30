using UnityEngine;
using System;
using Assets.SimpleAndroidNotifications;

public class NotifyManager : MonoBehaviour
{
    private int tempValue;  // 온도 센서로부터 받는 값 (가정)

    private void OnApplicationPause(bool isPause)
    {


        // Remove all registered notifications
        NotificationManager.CancelAll();
        TimeSpan delay = TimeSpan.FromSeconds(5);
        if (isPause)
        {
            Debug.LogWarning("call NotificationManager");

            // Check if the temperature value exceeds 50
            if (tempValue > 50)
            {
                // Send a notification about high temperature
                NotificationManager.SendWithAppIcon(delay,
                    "온도가 너무 높아요",  // Title: 온도가 너무 높아요
                    "온도가 현재 50을 초과하였습니다.",  // Message: 온도가 현재 50을 초과하였습니다.
                    Color.red,  // Color: 빨간색
                    NotificationIcon.Heart  // Icon: 하트 아이콘
                );
            }
        }
    }
}
