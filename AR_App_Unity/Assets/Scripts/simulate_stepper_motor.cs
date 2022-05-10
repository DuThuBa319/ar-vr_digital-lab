using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class simulate_stepper_motor : MonoBehaviour
{
    public GameObject vitmeObj;
    public TextMeshProUGUI velSP, vel, posSP, pos;
    public GameObject vitmePic;
    public Sprite tickOn, tickOff;
    public Image LS1, LS2;
    float z, tempPos;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        LS1.sprite = tickOff;
        LS2.sprite = tickOff;
    }

    // Update is called once per frame
    void Update()
    {
        z = -0.00001039f * global_variables.posTotal + 0.003031f;
        if (z >= 0.001936f && z <= 0.003067f)
        {
            vitmeObj.transform.localPosition = new Vector3(-0.002065f, 0.001075f, z);
            if (z > 0.001940f && z < 0.003060f)
            {
                global_variables.LS1 = false;
                global_variables.LS2 = false;
            }

            LS1.sprite = tickOff;
            LS2.sprite = tickOff;
        }
        else if (z < 0.001936f)
        {
            vitmeObj.transform.localPosition = new Vector3(-0.002065f, 0.001075f, 0.001936f);
            global_variables.LS2 = true;
            Debug.Log("lllllllllllllllllllllssssssss" + global_variables.LS2.ToString());
            LS2.sprite = tickOn;
        }
        else if (z > 0.003067f)
        {
            vitmeObj.transform.localPosition = new Vector3(-0.002065f, 0.001075f, 0.003067f);
            global_variables.LS1 = true;
            LS1.sprite = tickOn;
        }
        UpdateTextStepperMotorSimulate();

    }

    void UpdateTextStepperMotorSimulate()
    {
        velSP.text = global_variables.velSP.ToString("0.00") + " mm/s";
        posSP.text = global_variables.posSP.ToString("0.00") + " mm";
        vel.text = global_variables.vel.ToString("0.00") + " mm/s";
        pos.text = global_variables.pos.ToString("0.00") + " mm";

        tempPos = 1.897f * global_variables.pos - 90.8f; //-89.7 --> 99.3
        if (tempPos > -99.1f && tempPos < 107.9f)
        {
            vitmePic.transform.localPosition = new Vector3(tempPos, 165.3f, 7.629395e-05f);
        }
        else if (tempPos <= -99.1f)
        {
            vitmePic.transform.localPosition = new Vector3(-99.1f, 165.3f, 7.629395e-05f);
            //global_variables.LS1 = true;
        }
        else if (tempPos >= 107.9f)
        {
            vitmePic.transform.localPosition = new Vector3(107.9f, 165.3f, 7.629395e-05f);
        }
    }
        
}
