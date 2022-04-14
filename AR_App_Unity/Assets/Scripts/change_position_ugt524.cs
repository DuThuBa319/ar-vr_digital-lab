
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class change_position_ugt524 : MonoBehaviour
{
    public GameObject cubeUGT524;
    public float moveSpeech; //1.5
    public TextMeshProUGUI positionTMProUGT524;
    public Image barPositionUGT524;

    float localPositionUGT524;
    Int16 calPositionUGT524;
    

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        localPositionUGT524 = cubeUGT524.transform.localPosition.x;
        calPositionUGT524 = (Int16)(90 * (localPositionUGT524 - 9.73) / (15.1 - 9.73));

        if (calPositionUGT524 >= 35 && calPositionUGT524 <= 300)
        {
            global_variables.sensorPositionUGT524 = calPositionUGT524;
            positionTMProUGT524.text = global_variables.sensorPositionUGT524.ToString() + " mm";
            barPositionUGT524.fillAmount = global_variables.sensorPositionUGT524 * 1.0f / 300.0f;
        }
        else if (calPositionUGT524 < 35)
        {
            global_variables.sensorPositionUGT524 = -32760;
            positionTMProUGT524.text = global_variables.sensorPositionUGT524.ToString() + " (UL)";
            barPositionUGT524.fillAmount = 35f * 1.0f / 300.0f;
        }
        else if (calPositionUGT524 > 300)
        {
            global_variables.sensorPositionUGT524 = 32760;
            positionTMProUGT524.text = global_variables.sensorPositionUGT524.ToString() + " (OL)";
            barPositionUGT524.fillAmount = 1.0f;
        }
    }
   
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * moveSpeech;
        if (localPositionUGT524 >= 9.73)
        {

            cubeUGT524.transform.Translate(rotX / 10, 0, 0, Space.Self);
        }
        else
        {
            cubeUGT524.transform.localPosition = new Vector3(9.73001f, 6.4f, -4.12f);
        }
        
    }
}
