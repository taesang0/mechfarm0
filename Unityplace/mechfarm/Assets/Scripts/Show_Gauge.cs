using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Gauge : MonoBehaviour
{
    public Slider[] Sliders; //0: temp , 1: humi , 2: soil_humi, 3: light
    private float[] Firebase_Data = new float[4]; // Initialize the array

    private float[][] Plant_Data = new float[4][];
    private FB_Read readFBScript; // Read_FB 컴포넌트를 저장하기 위한 변수
    private Read_Plant_Database PlantDBScript;
    public Image[] ColorImages;
    // Start is called before the first frame update
    void Start()
    {
        // ReadData 오브젝트에서 Read_FB 스크립트의 인스턴스를 얻어옴
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();
        PlantDBScript = GameObject.Find("Plant_Database").GetComponent<Read_Plant_Database>();

        for (int i = 0; i < 4; i++)
        {
            Plant_Data[i] = new float[2];
        }
        if (readFBScript == null)
        {
            Debug.LogWarning("Read_FB component not found.");

        }


        Plant_Data[0][0] = PlantDBScript.plantData.Temperature_min;
        Plant_Data[0][1] = PlantDBScript.plantData.Temperature_max;
        Plant_Data[1][0] = PlantDBScript.plantData.Humidity_min;
        Plant_Data[1][1] = PlantDBScript.plantData.Humidity_max;
        Plant_Data[2][0] = PlantDBScript.plantData.Soil_humidity_min;
        Plant_Data[2][1] = PlantDBScript.plantData.Soil_humidity_max;
        Plant_Data[3][0] = PlantDBScript.plantData.Light_min;
        Plant_Data[3][1] = PlantDBScript.plantData.Light_max;
    }

    // Update is called once per frame
    void Update()
    {
        if (readFBScript != null)
        {
            Firebase_Data[0] = readFBScript.temperature;
            Firebase_Data[1] = readFBScript.humidity;
            Firebase_Data[2] = readFBScript.soil_humidity;
            Firebase_Data[3] = readFBScript.lightness;
            for (int i =0; i<Sliders.Length; i++)
            {
                Sliders[i].value = Firebase_Data[i];
                Gauge_Color(ColorImages[i],Plant_Data[i][0],Plant_Data[i][1],Firebase_Data[i]);
            }
        }
    }

    void Gauge_Color(Image image, float min, float max, float data)
    {
        if(data < min)
        {
            Color newColor = new Color(1f, 1f, 0f); // RGB 값으로 노란색 설정
            image.color = newColor; 
        }
        else if(data>max)
        {
            Color newColor = new Color(1f, 0f, 0f); // RGB 값으로 노란색 설정
            image.color = newColor; 
        }
        else
        {
            Color newColor = new Color(0f, 1f, 0f); // RGB 값으로 노란색 설정
            image.color = newColor; 
        }
    }
}
