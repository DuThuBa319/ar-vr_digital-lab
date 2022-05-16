using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class update_data_inverter : MonoBehaviour
{
    public TextMeshProUGUI realTextOnOffG120, realTextVelSPG120, realTextVelG120, realTextSetVelSPG120;
    public Slider sliderVelG120SP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        global_variables.realSetVelSPG120 = (ushort)(sliderVelG120SP.value*1300.0f);
        realTextSetVelSPG120.text = global_variables.realSetVelSPG120.ToString();
        UpdateRealInverter();
    }

    void UpdateRealInverter()
    {
        if (global_variables.realOnOffG120 == 1150)
        {
            realTextOnOffG120.text = "OFF";
        }    
        else if (global_variables.realOnOffG120 == 1151)
        {
            realTextOnOffG120.text = "ON";
        }
        realTextVelSPG120.text = global_variables.realVelSPG120.ToString();
        realTextVelG120.text = global_variables.realVelG120.ToString();
        
    }    
      
}
