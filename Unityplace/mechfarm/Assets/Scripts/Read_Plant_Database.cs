using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable] // Make Plant struct serializable
public struct Plant
{
    public int ID;
    public string Plant_name;
    public float Temperature_min;
    public float Temperature_best;
    public float Temperature_max;
    public float Humidity_min;
    public float Humidity_best;
    public float Humidity_max;
    public float Light_min;
    public float Light_best;
    public float Light_max;
    public float Soil_humidity_min;
    public float Soil_humidity_best;
    public float Soil_humidity_max;
    public string Help;
}

public class Read_Plant_Database : MonoBehaviour
{

    public string csvFileName = "PlantDB.csv";
    public string user_plant_name = "lettuce";
    public Plant plantData;
    void Start()
    {
        string filePath = Path.Combine(Application.dataPath, csvFileName);
        ReadCSVFile(filePath);

        // GameObject LoginObject; //넷플릭스 화면에서 고른 식물 정보 받아와서 이런식으로 적어야 함.
        // LoginObject= GameObject.Find("LoginObject");
        // user_plant_name=LoginObject.GetComponent<MovetoMain>().user_plant;
    }

    void ReadCSVFile(string filePath)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); // Skip the header line

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] rowData = line.Split(',');

                    if (rowData[1] == user_plant_name)
                    {
                        plantData.ID = int.Parse(rowData[0]);
                        plantData.Plant_name = rowData[1];
                        plantData.Temperature_min = float.Parse(rowData[2]);
                        plantData.Temperature_best = float.Parse(rowData[3]);
                        plantData.Temperature_max = float.Parse(rowData[4]);
                        plantData.Humidity_min = float.Parse(rowData[5]);
                        plantData.Humidity_best = float.Parse(rowData[6]);
                        plantData.Humidity_max = float.Parse(rowData[7]);
                        plantData.Light_min = float.Parse(rowData[8]);
                        plantData.Light_best = float.Parse(rowData[9]);
                        plantData.Light_max = float.Parse(rowData[10]);
                        plantData.Soil_humidity_min = float.Parse(rowData[11]);
                        plantData.Soil_humidity_best = float.Parse(rowData[12]);
                        plantData.Soil_humidity_max = float.Parse(rowData[13]);
                        plantData.Help = rowData[14];
                    }
                }
            }
        }
        catch (IOException e)
        {
            Debug.LogError("Error reading CSV file: " + e.Message);
        }
    }
}
