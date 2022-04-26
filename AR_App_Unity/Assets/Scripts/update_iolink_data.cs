using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class update_iolink_data : MonoBehaviour
{
    public TextMeshProUGUI masterTW2000, masterIF6123, masterUGT524, masterRB3100;
    public TextMeshProUGUI diO5C500, diKT5112;
    public TextMeshProUGUI doMotor, doRedLight, doGreenLight, doOrangeLight;
    public TextMeshProUGUI statusRL, statusGL, statusOL;
    public Sprite redLight, greenLight, orangeLight, grayLight, tickON, tickOFF;
    public Image picRedLight, picGreenLight, picOrangeLight, statusMotor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        masterTW2000.text = global_variables.sensorValueTW2000.ToString();
        masterUGT524.text = global_variables.sensorPositionUGT524.ToString();
        masterIF6123.text = global_variables.sensorValueIF6123.ToString();
        masterRB3100.text = global_variables.pulseRB3100.ToString();
        
        if (global_variables.clickKT5112 == true)
        {
            diKT5112.text = "1";
        }    
        else
        {
            diKT5112.text = "0";
        }    
        if (global_variables.sensorO5C500 == true)
        {
            diO5C500.text = "1";
        }    
        else
        {
            diO5C500.text = "0";
        }    
        // Co code update trang thai den, motor
        if (global_variables.byte65 == 0)
        {
            doRedLight.text = "0";
            doGreenLight.text = "0";
            picRedLight.sprite = grayLight;
            picGreenLight.sprite = grayLight;
            statusRL.text = "OFF";
            statusGL.text = "OFF";
        }    
        else if (global_variables.byte65 == 1)
        {
            doRedLight.text = "1";
            doGreenLight.text = "0";
            picRedLight.sprite = redLight;
            picGreenLight.sprite = grayLight;
            statusRL.text = "ON";
            statusGL.text = "OFF";
        }
        else if (global_variables.byte65 == 2)
        {
            doRedLight.text = "0";
            doGreenLight.text = "1";
            picRedLight.sprite = grayLight;
            picGreenLight.sprite = greenLight;
            statusRL.text = "OFF";
            statusGL.text = "ON";
        }
        else if (global_variables.byte65 == 3)
        {
            doRedLight.text = "1";
            doGreenLight.text = "1";
            picRedLight.sprite = redLight;
            picGreenLight.sprite = greenLight;
            statusRL.text = "ON";
            statusGL.text = "ON";
        }

        if (global_variables.byte67 == 0)
        {
            doMotor.text = "0";
            doOrangeLight.text = "0";
            statusMotor.sprite = tickOFF;
            picOrangeLight.sprite = grayLight;
            statusOL.text = "OFF";
        }
        else if (global_variables.byte67 == 1)
        {
            doMotor.text = "1";
            doOrangeLight.text = "0";
            statusMotor.sprite = tickON;
            picOrangeLight.sprite = grayLight;
            statusOL.text = "OFF";
        }
        else if (global_variables.byte67 == 2)
        {
            doMotor.text = "0";
            doOrangeLight.text = "1";
            statusMotor.sprite = tickOFF;
            picOrangeLight.sprite = orangeLight;
            statusOL.text = "ON";
        }
        else if (global_variables.byte67 == 3)
        {
            doMotor.text = "1";
            doOrangeLight.text = "1";
            statusMotor.sprite = tickON;
            picOrangeLight.sprite = orangeLight;
            statusOL.text = "ON";
        }

    }
}
