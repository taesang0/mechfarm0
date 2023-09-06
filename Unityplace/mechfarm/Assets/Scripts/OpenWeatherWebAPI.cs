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
    public string hour;
    public string whether;
    public GameObject day_background;
    public GameObject evening_background;
    public GameObject night_background;
    public GameObject Cloud;
    public GameObject Rain;


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
//Clear, 
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
            whether=weatherInfo.weather[0].main;
            
            //weatherText.text=weatherInfo.weather[0].main;

            if (whether == "Clouds")
            {
                Cloud.SetActive(true);
                Rain.SetActive(false);
            }
            else if (whether == "Rain")
            {
                Cloud.SetActive(true);
                Rain.SetActive(true);
            }
        }
        
    }
    IEnumerator GetTime()
    {
        while(true)
        {
            //TimeText.text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            hour = DateTime.Now.ToString("HH");
            
            if(int.Parse(hour) >= 6 && int.Parse(hour)<= 18)//day
            {
                day_background.SetActive(true);
                evening_background.SetActive(false);
                night_background.SetActive(false);
            }
            else if(int.Parse(hour) < 6 || int.Parse(hour) >= 20) // night
            {
                day_background.SetActive(false);
                evening_background.SetActive(false);
                night_background.SetActive(true);
            }
            else
            {
                day_background.SetActive(false);
                evening_background.SetActive(true);
                night_background.SetActive(false);
            }


            Debug.Log(hour);
            yield return new WaitForSeconds(100.0f); //100초마다 GetTime 실행 
        }
    }
}