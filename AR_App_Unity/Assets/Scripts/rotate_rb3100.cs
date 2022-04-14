using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class rotate_rb3100: MonoBehaviour
{
    public GameObject clockHand;
    public float rotSpeechClockHand; //10
    public GameObject gameObjectParent, gameObjectRotate;

    float a1, a2, angle;
    float rawResolution = 1024;
    float localAngleRB3100;

    public TextMeshProUGUI pulseTMProRB3100;
    public TextMeshProUGUI angleTMProRB3100;
    public GameObject clockWise;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ClockHand: 0--> 270-->-90 --> 0 degree
        a1 = gameObjectRotate.transform.eulerAngles.z;
        a2 = gameObjectParent.transform.parent.eulerAngles.z;
        angle = a1 - a2;

        if (angle < 0)
        {
            localAngleRB3100 = angle + 360;
        }
        else
        {
            localAngleRB3100 = angle;
        }

        global_variables.pulseRB3100 = (Int16)(localAngleRB3100 * rawResolution / 360);
        pulseTMProRB3100.text = global_variables.pulseRB3100.ToString();
        angleTMProRB3100.text = localAngleRB3100.ToString("0.##") + "°";
    }

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeechClockHand;
        transform.Rotate(Vector3.forward, rotX);
        clockWise.transform.localEulerAngles = new Vector3(0.0f,0.0f,-localAngleRB3100);
    }
}
