using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Gauge : MonoBehaviour
{
    public Slider Slider_temp;
    public Slider Slider_humi;
    public Slider Slider_soil_humi;
    public Slider Slider_light;

    private FB_Read readFBScript; // Read_FB 컴포넌트를 저장하기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        // ReadData 오브젝트에서 Read_FB 스크립트의 인스턴스를 얻어옴
        readFBScript = GameObject.Find("ReadData").GetComponent<FB_Read>();

        if (readFBScript == null)
        {
            Debug.LogWarning("Read_FB component not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (readFBScript != null)
        {
            Slider_temp.value = readFBScript.temperature * 0.01f;
            Slider_humi.value = readFBScript.humidity * 0.01f;
            Slider_soil_humi.value = readFBScript.soil_humidity * 0.01f;
            Slider_light.value = readFBScript.lightness * 0.01f;
            // 필요한 로직 추가...

        }
    }
}
