using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Messaging;
using UnityEngine;

public class PushNotificationManager : MonoBehaviour
{
    private void Start()
    {
        // Firebase 초기화
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
        });

        // FCM 메시지 수신 이벤트 핸들러 등록
        FirebaseMessaging.TokenReceived += OnTokenReceived;
        FirebaseMessaging.MessageReceived += OnMessageReceived;
    }

    // 푸시 알림을 보내는 함수
    public void SendPushNotification(string title, string body)
    {
        // 푸시 알림 메시지 생성
        var message = new Message()
        {
            Notification = new Notification()
            {
                Title = title,
                Body = body
            },
            Token = "디바이스 푸시 토큰" // 디바이스별 푸시 토큰을 여기에 입력
        };

        // FCM 서버로 메시지 보내기
        FirebaseMessaging.SendAsync(message);
    }

    // FCM 토큰 수신 이벤트 핸들러
    private void OnTokenReceived(object sender, TokenReceivedEventArgs tokenArgs)
    {
        string token = tokenArgs.Token;
        Debug.Log("푸시 알림 토큰: " + token);
    }

    // FCM 메시지 수신 이벤트 핸들러
    private void OnMessageReceived(object sender, MessageReceivedEventArgs messageArgs)
    {
        var notification = messageArgs.Message.Notification;
        Debug.Log("푸시 알림 수신 - 제목: " + notification.Title + ", 내용: " + notification.Body);
    }
}

