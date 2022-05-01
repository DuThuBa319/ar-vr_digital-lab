using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class effect_mcb_plc_on_off : MonoBehaviour
{
    public GameObject led7Seg;
    public Renderer ledRunMaster, ledRunSlave, ledScalance;
    public Material blackGreen, glowGreen;
    public GameObject objOnMCBPLC, objOffMCBPLC;
    public Sprite tickOn, tickOff;
    public Image statusMCBPLC, statusScalance, statusPLCMaster, statusPLCSlave, statusHMI;
    public Image statusDrive, statusEncoder, statusMotor, statusPanelSwitch;

    //public Renderer cubeI0_0, cubeI0_1, cubeI0_2, cubeI0_3, cubeI0_4, cubeI0_5, cubeI0_6, cubeI0_7;
    //public Renderer cubeQ0_0, cubeQ0_1, cubeQ0_2, cubeQ0_3, cubeQ0_4, cubeQ0_5, cubeQ0_6, cubeQ0_7;
    //public Material lightPLCOff;

    //public Image switch0, switch1, switch2, switch3, switch4, switch5, switch6, switch7;
    //public Image led0, led1, led2, led3, led4, led5, led6, led7;
    //public Image circleBarAI;
    //public TextMeshProUGUI txtCircleBarAI, ledAO;

    //Light PLC, SCALANCE
    // Start is called before the first frame update
    void Start()
    {
        led7Seg.gameObject.SetActive(false);
        statusMCBPLC.sprite = tickOff;
        statusPLCMaster.sprite = tickOff;
        statusPLCSlave.sprite = tickOff;
        statusScalance.sprite = tickOff;
        statusHMI.sprite = tickOff;
        statusPanelSwitch.sprite = tickOff;
        statusDrive.sprite = tickOff;
        statusMotor.sprite = tickOff;
        statusEncoder.sprite = tickOff;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Switch_MCB_PLC")
            {
                if (global_variables.onMCBPLC == false)
                {
                    objOffMCBPLC.gameObject.SetActive(false);
                    objOnMCBPLC.gameObject.SetActive(true);
                    global_variables.onMCBPLC = true;
                    led7Seg.gameObject.SetActive(true);
                    statusMCBPLC.sprite = tickOn;
                    statusPLCMaster.sprite = tickOn;
                    statusPLCSlave.sprite = tickOn;
                    statusScalance.sprite = tickOn;
                    statusHMI.sprite = tickOn;
                    statusPanelSwitch.sprite = tickOn;
                    statusDrive.sprite = tickOn;
                    statusMotor.sprite = tickOn;
                    statusEncoder.sprite = tickOn;

                    ledRunMaster.material = glowGreen;
                    ledRunSlave.material = glowGreen;
                    ledScalance.material = glowGreen;

                   
                }
                else if (global_variables.onMCBPLC == true)
                {
                    objOffMCBPLC.gameObject.SetActive(true);
                    objOnMCBPLC.gameObject.SetActive(false);
                    global_variables.onMCBPLC = false;
                    led7Seg.gameObject.SetActive(false);
                    statusMCBPLC.sprite = tickOff;
                    statusPLCMaster.sprite = tickOff;
                    statusPLCSlave.sprite = tickOff;
                    statusScalance.sprite = tickOff;
                    statusHMI.sprite = tickOff;
                    statusPanelSwitch.sprite = tickOff;
                    statusDrive.sprite = tickOff;
                    statusMotor.sprite = tickOff;
                    statusEncoder.sprite = tickOff;

                    ledRunMaster.material = blackGreen;
                    ledRunSlave.material = blackGreen;
                    ledScalance.material = blackGreen;
                }
            }
        }
    }


}
