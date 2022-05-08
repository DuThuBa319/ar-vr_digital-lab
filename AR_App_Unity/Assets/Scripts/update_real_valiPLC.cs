using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class update_real_valiPLC : MonoBehaviour
{
    public Sprite ledOff, ledOn, tickOn, tickOff;
    public Image switch0, switch1, switch2, switch3, switch4, switch5, switch6, switch7, LS1, LS2;
    public Image led0, led1, led2, led3, led4, led5, led6, led7;
    public Image circleBarAI;
    public TextMeshProUGUI ledAO, txtCircleBarAI, velSP, vel, posSP, pos;
    float tempCal2;
    public GameObject vitme; //-90.8 --> 98.9 (LS1: -99.1, LS2: 107.9)
    float tempPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDI();
        UpdateD0();
        UpdateAI();
        UpdateAO();
        UpdateStepperMotor();
    }

    void UpdateDI()
    {
        if ((global_variables.realDI & 128) == 128)
        {
            switch7.sprite = tickOn;
        }
        else
        {
            switch7.sprite = tickOff;
        }
        if ((global_variables.realDI & 64) == 64)
        {
            switch6.sprite = tickOn;
        }
        else
        {
            switch6.sprite = tickOff;
        }
        if ((global_variables.realDI & 32) == 32)
        {
            switch5.sprite = tickOn;
        }
        else
        {
            switch5.sprite = tickOff;
        }
        if ((global_variables.realDI & 16) == 16)
        {
            switch4.sprite = tickOn;
        }
        else
        {
            switch4.sprite = tickOff;
        }
        if ((global_variables.realDI & 8) == 8)
        {
            switch3.sprite = tickOn;
        }
        else
        {
            switch3.sprite = tickOff;
        }
        if ((global_variables.realDI & 4) == 4)
        {
            switch2.sprite = tickOn;
        }
        else
        {
            switch2.sprite = tickOff;
        }
        if ((global_variables.realDI & 2) == 2)
        {
            switch1.sprite = tickOn;
        }
        else
        {
            switch1.sprite = tickOff;
        }
        if ((global_variables.realDI & 1) == 1)
        {
            switch0.sprite = tickOn;
        }
        else
        {
            switch0.sprite = tickOff;
        }

    }    
    void UpdateD0()
    {
        if ((global_variables.realDO & 128) == 128)
        {
            led7.sprite = ledOn;
        }
        else
        {
            led7.sprite = ledOff;
        }
        if ((global_variables.realDO & 64) == 64)
        {
            led6.sprite = ledOn;
        }
        else
        {
            led6.sprite = ledOff;
        }
        if ((global_variables.realDO & 32) == 32)
        {
            led5.sprite = ledOn;
        }
        else
        {
            led5.sprite = ledOff;
        }
        if ((global_variables.realDO & 16) == 16)
        {
            led4.sprite = ledOn;
        }
        else
        {
            led4.sprite = ledOff;
        }
        if ((global_variables.realDO & 8) == 8)
        {
            led3.sprite = ledOn;
        }
        else
        {
            led3.sprite = ledOff;
        }
        if ((global_variables.realDO & 4) == 4)
        {
            led2.sprite = ledOn;
        }
        else
        {
            led2.sprite = ledOff;
        }
        if ((global_variables.realDO & 2) == 2)
        {
            led1.sprite = ledOn;
        }
        else
        {
            led1.sprite = ledOff;
        }
        if ((global_variables.realDO & 1) == 1)
        {
            led0.sprite = ledOn;
        }
        else
        {
            led0.sprite = ledOff;
        }
    }    
    void UpdateAI()
    {
        tempCal2 = (float)global_variables.realAI / 27648.0f;
        circleBarAI.fillAmount = tempCal2;
        txtCircleBarAI.text = (tempCal2 * 10.0f).ToString("0.0") + " (V)";
    }    
    void UpdateAO()
    {
        ledAO.text = ((((float)global_variables.realAO) / 27648.0f) * 10.0f).ToString("0.0");
    }   
    void UpdateStepperMotor()
    {
        
        velSP.text = global_variables.realVelSP.ToString("0.00") + " mm/s";
        posSP.text = global_variables.realPosSP.ToString("0.00") + " mm";
        vel.text = global_variables.realVel.ToString("0.00") + " mm/s";
        pos.text = global_variables.realPos.ToString("0.00") + " mm";
        
        tempPos = 1.897f * global_variables.realPos - 90.8f;
        if (tempPos > -99.1f && tempPos < 107.9f)
        {
            vitme.transform.localPosition = new Vector3(tempPos, 153.2f, 7.629395e-05f);
        }    
        else if (tempPos <= -99.1f)
        {
            vitme.transform.localPosition = new Vector3(-99.1f, 153.2f, 7.629395e-05f);
        }    
        else if (tempPos >= 107.9f)
        {
            vitme.transform.localPosition = new Vector3(107.9f, 153.2f, 7.629395e-05f);
        }    
        if (global_variables.realLS1 == true)
        {
            LS1.sprite = tickOn;
        }    
        else
        {
            LS1.sprite = tickOff;
        }
        if (global_variables.realLS2 == true)
        {
            LS2.sprite = tickOn;
        }
        else
        {
            LS2.sprite = tickOff;
        }
    }    
}
