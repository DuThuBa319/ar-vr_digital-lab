using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Switch_Control : MonoBehaviour
{
    public GameObject switch0On, switch0Off;
    public GameObject switch1On, switch1Off;
    public GameObject switch2On, switch2Off;
    public GameObject switch3On, switch3Off;
    public GameObject switch4On, switch4Off;
    public GameObject switch5On, switch5Off;
    public GameObject switch6On, switch6Off;
    public GameObject switch7On, switch7Off;
    public Renderer rendererLed0, rendererLed1, rendererLed2, rendererLed3;
    public Renderer rendererLed4, rendererLed5, rendererLed6, rendererLed7;
    public Material materialLedOn, materialLedOff;
    public TextMeshProUGUI ledAO, ledAOPanel, txtCircleBarAI;
    public Sprite ledOff, ledOn, tickOn, tickOff;
    public Image switch0, switch1, switch2, switch3, switch4, switch5, switch6, switch7;
    public Image led0, led1, led2, led3, led4, led5, led6, led7;
    public Image circleBarAI;
    bool state0On, state1On, state2On, state7On, state3On, state4On, state5On, state6On;
    float tempCal1, tempCal2;
    public Renderer cubeI0_0, cubeI0_1, cubeI0_2, cubeI0_3, cubeI0_4, cubeI0_5, cubeI0_6, cubeI0_7;
    public Renderer cubeQ0_0, cubeQ0_1, cubeQ0_2, cubeQ0_3, cubeQ0_4, cubeQ0_5, cubeQ0_6, cubeQ0_7;
    public Material lightPLCOff, lightPLCOn;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_0"))) //Vi tri Switch bi nguoc, Switch_0 = switch7
            {
                ChangeState(ref state0On, switch0On, switch0Off, 128);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_1")))
            {
                ChangeState(ref state1On, switch1On, switch1Off, 64);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_2")))
            {
                ChangeState(ref state2On, switch2On, switch2Off, 32);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_3")))
            {
                ChangeState(ref state3On, switch3On, switch3Off, 16);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_4")))
            {
                ChangeState(ref state4On, switch4On, switch4Off, 8);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_5")))
            {
                ChangeState(ref state5On, switch5On, switch5Off, 4);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_6")))
            {
                ChangeState(ref state6On, switch6On, switch6Off, 2);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_7")))
            {
                ChangeState(ref state7On, switch7On, switch7Off, 1);
            }
        }
        if (global_variables.onMCBPLC)
        {
            
            if ((global_variables.DO & 128) == 128)
            {
                rendererLed0.material = materialLedOn;
                led7.sprite = ledOn;
                cubeQ0_7.material = lightPLCOn;
            }
            else
            {
                rendererLed0.material = materialLedOff;
                led7.sprite = ledOff;
                cubeQ0_7.material = lightPLCOff;
            }
            if ((global_variables.DO & 64) == 64)
            {
                rendererLed1.material = materialLedOn;
                led6.sprite = ledOn;
                cubeQ0_6.material = lightPLCOn;
            }
            else
            {
                rendererLed1.material = materialLedOff;
                led6.sprite = ledOff;
                cubeQ0_6.material = lightPLCOff;
            }
            if ((global_variables.DO & 32) == 32)
            {
                rendererLed2.material = materialLedOn;
                led5.sprite = ledOn;
                cubeQ0_5.material = lightPLCOn;
            }
            else
            {
                rendererLed2.material = materialLedOff;
                led5.sprite = ledOff;
                cubeQ0_5.material = lightPLCOff;
            }
            if ((global_variables.DO & 16) == 16)
            {
                rendererLed3.material = materialLedOn;
                led4.sprite = ledOn;
                cubeQ0_4.material = lightPLCOn;
            }
            else
            {
                rendererLed3.material = materialLedOff;
                led4.sprite = ledOff;
                cubeQ0_4.material = lightPLCOff;
            }
            if ((global_variables.DO & 8) == 8)
            {
                rendererLed4.material = materialLedOn;
                led3.sprite = ledOn;
                cubeQ0_3.material = lightPLCOn;
            }
            else
            {
                rendererLed4.material = materialLedOff;
                led3.sprite = ledOff;
                cubeQ0_3.material = lightPLCOff;
            }
            if ((global_variables.DO & 4) == 4)
            {
                rendererLed5.material = materialLedOn;
                led2.sprite = ledOn;
                cubeQ0_2.material = lightPLCOn;
            }
            else
            {
                rendererLed5.material = materialLedOff;
                led2.sprite = ledOff;
                cubeQ0_2.material = lightPLCOff;
            }
            if ((global_variables.DO & 2) == 2)
            {
                rendererLed6.material = materialLedOn;
                led1.sprite = ledOn;
                cubeQ0_1.material = lightPLCOn;
            }
            else
            {
                rendererLed6.material = materialLedOff;
                led1.sprite = ledOff;
                cubeQ0_1.material = lightPLCOff;
            }
            if ((global_variables.DO & 1) == 1)
            {
                rendererLed7.material = materialLedOn;
                led0.sprite = ledOn;
                cubeQ0_0.material = lightPLCOn;
            }
            else
            {
                rendererLed7.material = materialLedOff;
                led0.sprite = ledOff;
                cubeQ0_0.material = lightPLCOff;
            }
            ActionState(state0On, switch7, cubeI0_7);
            ActionState(state1On, switch6, cubeI0_6);
            ActionState(state2On, switch5, cubeI0_5);
            ActionState(state3On, switch4, cubeI0_4);
            ActionState(state4On, switch3, cubeI0_3);
            ActionState(state5On, switch2, cubeI0_2);
            ActionState(state6On, switch1, cubeI0_1);
            ActionState(state7On, switch0, cubeI0_0);

            tempCal1 = (((float)global_variables.AO) / 27648.0f) * 10.0f;
            ledAO.text = tempCal1.ToString("0.0");
            //ledAO.text = ((((float)global_variables.AO) / 27648.0f) * 10.0f).ToString("0.0");
            ledAOPanel.text = tempCal1.ToString("0.0");
            tempCal2 = (float)global_variables.AI / 27648.0f;
            circleBarAI.fillAmount = tempCal2;
            txtCircleBarAI.text = (tempCal2 * 10.0f).ToString("0.0") + " (V)";
        }
        else
        {
            cubeQ0_7.material = lightPLCOff;
            cubeQ0_6.material = lightPLCOff;
            cubeQ0_5.material = lightPLCOff;
            cubeQ0_4.material = lightPLCOff;
            cubeQ0_3.material = lightPLCOff;
            cubeQ0_2.material = lightPLCOff;
            cubeQ0_1.material = lightPLCOff;
            cubeQ0_0.material = lightPLCOff;

            cubeI0_7.material = lightPLCOff;
            cubeI0_6.material = lightPLCOff;
            cubeI0_5.material = lightPLCOff;
            cubeI0_4.material = lightPLCOff;
            cubeI0_3.material = lightPLCOff;
            cubeI0_2.material = lightPLCOff;
            cubeI0_1.material = lightPLCOff;
            cubeI0_0.material = lightPLCOff;

            switch0.sprite = tickOff;
            switch1.sprite = tickOff;
            switch2.sprite = tickOff;
            switch3.sprite = tickOff;
            switch4.sprite = tickOff;
            switch5.sprite = tickOff;
            switch6.sprite = tickOff;
            switch7.sprite = tickOff;

            led0.sprite = ledOff;
            led1.sprite = ledOff;
            led2.sprite = ledOff;
            led3.sprite = ledOff;
            led4.sprite = ledOff;
            led5.sprite = ledOff;
            led6.sprite = ledOff;
            led7.sprite = ledOff;

            rendererLed0.material = materialLedOff;
            rendererLed1.material = materialLedOff;
            rendererLed2.material = materialLedOff;
            rendererLed3.material = materialLedOff;
            rendererLed4.material = materialLedOff;
            rendererLed5.material = materialLedOff;
            rendererLed6.material = materialLedOff;
            rendererLed7.material = materialLedOff;


            circleBarAI.fillAmount = 0.0f;
            txtCircleBarAI.text = "0.0 (V)";
            ledAO.text = "0.0";
            ledAOPanel.text = "0.0";
        }    

        
    }
    void ChangeState(ref bool state, GameObject switchOn, GameObject switchOff, byte valXor)
    {
        if(state == false)
        {
            switchOn.SetActive(true);
            switchOff.SetActive(false);
            /*
            switchLed.sprite = tickOn;
            cubeI.material = lightPLCOn;*/
            state = true;
        }
        else
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);
            /*
            switchLed.sprite = tickOff;
            cubeI.material = lightPLCOff;*/
            state = false;
        }
        global_variables.DI = (byte)(global_variables.DI ^ valXor);
        Debug.Log("Gia tri switch: " + global_variables.DI.ToString());
    }
    void ActionState(bool state, Image switchLed, Renderer cubeI)
    {
        if (state == true)
        {
            switchLed.sprite = tickOn;
            cubeI.material = lightPLCOn;
        }   
        else
        {
            switchLed.sprite = tickOff;
            cubeI.material = lightPLCOff;
        }    
    }    
    
}
