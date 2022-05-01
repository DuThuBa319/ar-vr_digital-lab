using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class effect_mcb_on_off : MonoBehaviour
{
    public GameObject objOnMCB, objOffMCB;
    public TextMeshProUGUI textButtonOnOffMCB;
    public Image statusOnOffMCB;
    public Sprite spriteOnMCB, spriteOffMCB;

    public GameObject cubeUGT524, cubeIF6123;


    public GameObject lightO5C500, textTemperature;
    public Material lightOff, lightGreenOn, lightOrangeOn;
    public Renderer powerLightDN4012, powerLightAL1102, powerLightAL2401;
    public Renderer lightEthernetGreen, lightEthernetOrange, light_X31_AL1102, light_X01_AL1102, light1_1_X02_AL1102, light1_2_X02_AL1102;
    public Renderer light_X03_AL1102_Green, light_X03_AL1102_Orange, light_X05_AL1102, light_X06_AL1102;
    public Renderer light1_1_X04_AL1102_Green, light1_2_X04_AL1102_Green, light2_1_X04_AL1102_Orange, light2_2_X04_AL1102_Orange;
    public Renderer light1_X1_AL2330, light2_X1_AL233, light1_1_X31_AL2330_Up, light1_2_X31_AL2330_Down, light2_1_X31_AL2330_Up, light2_2_X31_AL2330_Down;

    public Sprite tickOn, tickOff;
    public Image tickDN4012, tickAL2401, tickO5C, tickKT, tickTW, tickAL1102, tickRB, tickUGT, tickIF, tickAL2330; // - Motor, Light, Switch, Relay

    // Start is called before the first frame update
    void Start()
    {
        lightO5C500.gameObject.SetActive(false);
        textTemperature.gameObject.SetActive(false);

        cubeUGT524.gameObject.SetActive(false);
        cubeIF6123.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Switch_MCB_IFM")
            {
                if (global_variables.onMCB == false)
                {
                    objOnMCB.gameObject.SetActive(true);
                    objOffMCB.gameObject.SetActive(false);
                    textButtonOnOffMCB.text = "OFF MCB";
                    statusOnOffMCB.sprite = spriteOnMCB;

                    cubeUGT524.gameObject.SetActive(true);
                    cubeIF6123.gameObject.SetActive(true);
                    global_variables.simulateTW = true;

                    global_variables.onMCB = true;

                    EffectLightOn();
                }
                else if (global_variables.onMCB == true)
                {
                    objOnMCB.gameObject.SetActive(false);
                    objOffMCB.gameObject.SetActive(true);
                    textButtonOnOffMCB.text = "ON MCB";
                    statusOnOffMCB.sprite = spriteOffMCB;
                    global_variables.onMCB = false;

                    cubeUGT524.gameObject.SetActive(false);
                    cubeIF6123.gameObject.SetActive(false);
                    global_variables.simulateTW = false;

                    EffectLightOff();
                }
            }
        }
        #region NotUse
        /*
        if (global_variables.onMCB == true)
        {
            lightO5C500.gameObject.SetActive(true);
            textTemperature.gameObject.SetActive(true);

            powerLightDN4012.material = lightGreenOn;
            powerLightAL1102.material = lightGreenOn;
            powerLightAL2401.material = lightGreenOn;

            lightEthernetGreen.material = lightGreenOn;
            lightEthernetOrange.material = lightOrangeOn;
            light_X31_AL1102.material = lightGreenOn;
            light_X01_AL1102.material = lightGreenOn;
            light1_1_X02_AL1102.material = lightGreenOn;
            light1_2_X02_AL1102.material = lightGreenOn;
            light_X03_AL1102_Green.material = lightGreenOn;
            light_X03_AL1102_Orange.material = lightOrangeOn;
            light_X05_AL1102.material = lightGreenOn;
            light_X06_AL1102.material = lightGreenOn;
            light1_1_X04_AL1102_Green.material = lightGreenOn;
            light1_2_X04_AL1102_Green.material = lightGreenOn;
            light2_1_X04_AL1102_Orange.material = lightOrangeOn;
            light2_1_X04_AL1102_Orange.material = lightOrangeOn;
            light2_2_X04_AL1102_Orange.material = lightOrangeOn;

            light1_X1_AL2330.material = lightGreenOn;
            light2_X1_AL233.material = lightGreenOn;
            light1_1_X31_AL2330_Up.material = lightGreenOn;
            light1_2_X31_AL2330_Down.material = lightGreenOn;
            light2_1_X31_AL2330_Up.material = lightGreenOn;
            light2_2_X31_AL2330_Down.material = lightGreenOn;

            tickDN4012.sprite = tickOn;
            tickAL2401.sprite = tickOn;
            tickO5C.sprite = tickOn;
            tickKT.sprite = tickOn;
            tickTW.sprite = tickOn;
            tickAL1102.sprite = tickOn;
            tickRB.sprite = tickOn;
            tickUGT.sprite = tickOn;
            tickIF.sprite = tickOn;
            tickAL2330.sprite = tickOn;


        }
        else
        {
            lightO5C500.gameObject.SetActive(false);
            textTemperature.gameObject.SetActive(false);

            powerLightDN4012.material = lightOff;
            powerLightAL1102.material = lightOff;
            powerLightAL2401.material = lightOff;

            lightEthernetGreen.material = lightOff;
            lightEthernetOrange.material = lightOff;
            light_X31_AL1102.material = lightOff;
            light_X01_AL1102.material = lightOff;
            light1_1_X02_AL1102.material = lightOff;
            light1_2_X02_AL1102.material = lightOff;
            light_X03_AL1102_Green.material = lightOff;
            light_X03_AL1102_Orange.material = lightOff;
            light_X05_AL1102.material = lightOff;
            light_X06_AL1102.material = lightOff;
            light1_1_X04_AL1102_Green.material = lightOff;
            light1_2_X04_AL1102_Green.material = lightOff;
            light2_1_X04_AL1102_Orange.material = lightOff;
            light2_1_X04_AL1102_Orange.material = lightOff;
            light2_2_X04_AL1102_Orange.material = lightOff;

            light1_X1_AL2330.material = lightOff;
            light2_X1_AL233.material = lightOff;
            light1_1_X31_AL2330_Up.material = lightOff;
            light1_2_X31_AL2330_Down.material = lightOff;
            light2_1_X31_AL2330_Up.material = lightOff;
            light2_2_X31_AL2330_Down.material = lightOff;

            tickDN4012.sprite = tickOff;
            tickAL2401.sprite = tickOff;
            tickO5C.sprite = tickOff;
            tickKT.sprite = tickOff;
            tickTW.sprite = tickOff;
            tickAL1102.sprite = tickOff;
            tickRB.sprite = tickOff;
            tickUGT.sprite = tickOff;
            tickIF.sprite = tickOff;
            tickAL2330.sprite = tickOff;
        }
        */
        #endregion
    }
    public void EffectLightOn()
    {
        lightO5C500.gameObject.SetActive(true);
        textTemperature.gameObject.SetActive(true);

        powerLightDN4012.material = lightGreenOn;
        powerLightAL1102.material = lightGreenOn;
        powerLightAL2401.material = lightGreenOn;

        lightEthernetGreen.material = lightGreenOn;
        lightEthernetOrange.material = lightOrangeOn;
        light_X31_AL1102.material = lightGreenOn;
        light_X01_AL1102.material = lightGreenOn;
        light1_1_X02_AL1102.material = lightGreenOn;
        light1_2_X02_AL1102.material = lightGreenOn;
        light_X03_AL1102_Green.material = lightGreenOn;
        light_X03_AL1102_Orange.material = lightOrangeOn;
        light_X05_AL1102.material = lightGreenOn;
        light_X06_AL1102.material = lightGreenOn;
        light1_1_X04_AL1102_Green.material = lightGreenOn;
        light1_2_X04_AL1102_Green.material = lightGreenOn;
        light2_1_X04_AL1102_Orange.material = lightOrangeOn;
        light2_1_X04_AL1102_Orange.material = lightOrangeOn;
        light2_2_X04_AL1102_Orange.material = lightOrangeOn;

        light1_X1_AL2330.material = lightGreenOn;
        light2_X1_AL233.material = lightGreenOn;
        light1_1_X31_AL2330_Up.material = lightGreenOn;
        light1_2_X31_AL2330_Down.material = lightGreenOn;
        light2_1_X31_AL2330_Up.material = lightGreenOn;
        light2_2_X31_AL2330_Down.material = lightGreenOn;

        tickDN4012.sprite = tickOn;
        tickAL2401.sprite = tickOn;
        tickO5C.sprite = tickOn;
        tickKT.sprite = tickOn;
        tickTW.sprite = tickOn;
        tickAL1102.sprite = tickOn;
        tickRB.sprite = tickOn;
        tickUGT.sprite = tickOn;
        tickIF.sprite = tickOn;
        tickAL2330.sprite = tickOn;
    }
    public void EffectLightOff()
    {
        lightO5C500.gameObject.SetActive(false);
        textTemperature.gameObject.SetActive(false);

        powerLightDN4012.material = lightOff;
        powerLightAL1102.material = lightOff;
        powerLightAL2401.material = lightOff;

        lightEthernetGreen.material = lightOff;
        lightEthernetOrange.material = lightOff;
        light_X31_AL1102.material = lightOff;
        light_X01_AL1102.material = lightOff;
        light1_1_X02_AL1102.material = lightOff;
        light1_2_X02_AL1102.material = lightOff;
        light_X03_AL1102_Green.material = lightOff;
        light_X03_AL1102_Orange.material = lightOff;
        light_X05_AL1102.material = lightOff;
        light_X06_AL1102.material = lightOff;
        light1_1_X04_AL1102_Green.material = lightOff;
        light1_2_X04_AL1102_Green.material = lightOff;
        light2_1_X04_AL1102_Orange.material = lightOff;
        light2_1_X04_AL1102_Orange.material = lightOff;
        light2_2_X04_AL1102_Orange.material = lightOff;

        light1_X1_AL2330.material = lightOff;
        light2_X1_AL233.material = lightOff;
        light1_1_X31_AL2330_Up.material = lightOff;
        light1_2_X31_AL2330_Down.material = lightOff;
        light2_1_X31_AL2330_Up.material = lightOff;
        light2_2_X31_AL2330_Down.material = lightOff;

        tickDN4012.sprite = tickOff;
        tickAL2401.sprite = tickOff;
        tickO5C.sprite = tickOff;
        tickKT.sprite = tickOff;
        tickTW.sprite = tickOff;
        tickAL1102.sprite = tickOff;
        tickRB.sprite = tickOff;
        tickUGT.sprite = tickOff;
        tickIF.sprite = tickOff;
        tickAL2330.sprite = tickOff;
    }
}
