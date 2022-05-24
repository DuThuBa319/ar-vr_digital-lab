using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class effect_mcb_g120_on_off : MonoBehaviour
{
    public GameObject objOnMCB, objOffMCB;
    public GameObject led7Seg1, led7Seg2;
    public TextMeshProUGUI txtStatusMCB;
    public Sprite tickOn, tickOff;
    public Image imgStatusMCB;
    public Material lightG120Off, lightG120On, black, blue;
    public Renderer light1G120, light4G120, screenG120;
    // Start is called before the first frame update
    void Start()
    {
        led7Seg1.gameObject.SetActive(false);
        led7Seg2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "MCBG120_Switch")
            {
                if (global_variables.onMCBG120 == false)
                {
                    objOnMCB.gameObject.SetActive(true);
                    objOffMCB.gameObject.SetActive(false);
                    led7Seg1.gameObject.SetActive(true);
                    led7Seg2.gameObject.SetActive(true);
                    //textButtonOnOffMCB.text = "OFF MCB";
                    //statusOnOffMCB.sprite = spriteOnMCB;
                    global_variables.onMCBG120 = true;
                    txtStatusMCB.text = "ON";
                    imgStatusMCB.sprite = tickOn;
                    light1G120.material = lightG120On;
                    light4G120.material = lightG120On;
                    screenG120.material = blue;

                }
                else if (global_variables.onMCBG120 == true)
                {
                    objOnMCB.gameObject.SetActive(false);
                    objOffMCB.gameObject.SetActive(true);
                    led7Seg1.gameObject.SetActive(false);
                    led7Seg2.gameObject.SetActive(false);
                    //textButtonOnOffMCB.text = "ON MCB";
                    //statusOnOffMCB.sprite = spriteOffMCB;
                    global_variables.onMCBG120 = false;
                    txtStatusMCB.text = "OFF";
                    imgStatusMCB.sprite = tickOff;
                    light1G120.material = lightG120Off;
                    light4G120.material = lightG120Off;
                    screenG120.material = black;

                }
            }

        }


    }
}
