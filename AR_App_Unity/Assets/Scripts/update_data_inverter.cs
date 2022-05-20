using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class update_data_inverter : MonoBehaviour
{
    public TextMeshProUGUI realTextOnOffG120, realTextVelSPG120, realTextVelG120, realTextSetVelSPG120;
    public TextMeshProUGUI simulateTextOnOffG120, simulateTextVelSPG120, simulateTextVelG120, simulateTextSetVelSPG120;
    public GameObject diskMotor;
    public Slider sliderVelG120SP, simulateSilderVelG120SP;
    //public int speed;

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
        global_variables.setVelSPG120 = (ushort)(simulateSilderVelG120SP.value * 1300.0f);
        simulateTextSetVelSPG120.text = global_variables.setVelSPG120.ToString();
        UpdateSimulateInverter();
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

    void UpdateSimulateInverter()
    {
        if (global_variables.onOffG120 == 1150)
        {
            simulateTextOnOffG120.text = "OFF";
        }
        else if (global_variables.onOffG120 == 1151)
        {
            simulateTextOnOffG120.text = "ON";
        }
        simulateTextVelSPG120.text = global_variables.velSPG120.ToString();
        //simulate = Ramp Function?
        if (global_variables.onOffG120 == 1151)
        {
            global_variables.velWriteG120 = (ushort)(global_variables.velSPG120 * 16384 / 1300);
        }
        else
        {
            global_variables.velWriteG120 = 0;
        } 
            
        
        simulateTextVelG120.text = global_variables.velG120.ToString();

        diskMotor.transform.Rotate(0f, 0f, 5f * global_variables.velG120 * Time.deltaTime);
    }    
      
}