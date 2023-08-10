using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sddssd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shower;
    
    public Slider water;
    // Update is called once per frame
    void Update()
    {


    }

    public void test()
    {

        //파이어베이스에 워터 값 보는걸로 고치기
        
        if (water.value <0.5)
        shower.SetActive(true);
        if (water.value>0.5)
        shower.SetActive(false);
        // Invoke("falseactive", 3.0f);
    }
    public void falseactive()
    {
        shower.SetActive(false);
    }

}
