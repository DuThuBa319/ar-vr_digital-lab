using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class simulate_tw2000 : MonoBehaviour
{
    public Slider sliderTW2000;
    public TextMeshProUGUI simulateTMProTW2000, circleBarTMProUpTW2000, circleBarTMProDownTW2000;
    float temperatureTW2000;
    public Image circleBarTW2000;

    bool showSlider;

    // Start is called before the first frame update
    void Start()
    {
        sliderTW2000.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (global_variables.simulateTW == true)
        {
            sliderTW2000.gameObject.SetActive(true);
        }    
        else
        {
            sliderTW2000.gameObject.SetActive(false);
        }    

        temperatureTW2000 = sliderTW2000.value * 1000.0f;
        global_variables.sensorValueTW2000 = (Int16)(temperatureTW2000 * 10);
        if (temperatureTW2000 <= 100)
        {
            simulateTMProTW2000.text = temperatureTW2000.ToString("0.##") + "°C";

            circleBarTMProDownTW2000.text = "100°C";
            circleBarTMProUpTW2000.text = temperatureTW2000.ToString("0.##") + "°C";
            circleBarTW2000.fillAmount = temperatureTW2000 * 1.0f / 100.0f;
        }
        else
        {
            simulateTMProTW2000.text = temperatureTW2000.ToString("0.##") + "°C";

            circleBarTMProDownTW2000.text = "1000°C";
            circleBarTMProUpTW2000.text = temperatureTW2000.ToString("0.##") + "°C";
            circleBarTW2000.fillAmount = temperatureTW2000 * 1.0f / 1000.0f;
        } 
            

    }
    public void ShowHideSlider()
    {
        //if (showSlider == false)
        //{
        //    sliderTW2000.gameObject.SetActive(true);
        //    showSlider = true;
        //}    
        //else
        //{
        //    sliderTW2000.gameObject.SetActive(false);
        //    showSlider = false;
        //}    
    }    
}
