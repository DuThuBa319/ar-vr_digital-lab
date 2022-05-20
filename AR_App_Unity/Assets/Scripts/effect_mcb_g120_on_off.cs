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

                }
            }

        }


    }
}
