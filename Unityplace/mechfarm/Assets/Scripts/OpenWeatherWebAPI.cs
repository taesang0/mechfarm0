using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;

public class OpenWeatherWebAPI : MonoBehaviour
{
    public string APP_ID;
    public TMP_Text weatherText;
    public TMP_Text TimeText;
    public WeatherData weatherInfo;
    

    // Start is called before the first frame update
    void Start()
    {
        CheckCityWeather("Jinju");
        StartCoroutine(GetTime());
        
    }

    public void CheckCityWeather(string city)
    {
        StartCoroutine(GetWeather(city));
    }

    IEnumerator GetWeather(string city)
    {
        city = UnityWebRequest.EscapeURL(city);
        string front_url = "http://api.openweathermap.org/data/2.5/weather?q=";
        string customer_city = "Jinju";
        string back_url="&units=metric&appid=c816f2d65b4e81937e514abcede240ef";
        string url = front_url + customer_city + back_url;


        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string json = www.downloadHandler.text;
        json = json.Replace("\"base\":", "\"basem\":");
        weatherInfo = JsonUtility.FromJson<WeatherData>(json);
        
        if(weatherInfo.weather.Length>0)
        {
            weatherText.text=weatherInfo.weather[0].main;
        }
        
    }
    IEnumerator GetTime()
    {
        while(true)
        {
            TimeText.text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            yield return new WaitForSeconds(1.0f);
        }
    }
}