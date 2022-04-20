using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class change_position_if6123 : MonoBehaviour
{
    public GameObject cubeIF6123;
    public float moveSpeech; //1.5
    public TextMeshProUGUI positionTMProIF6123;
    public TextMeshProUGUI valueTMProIF6123;
    public Image barValueIF6123;

    Int16 calValueIF6123;
    float localPositionIF6123;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        localPositionIF6123 = cubeIF6123.transform.localPosition.x;
        //calValueIF6123 = (Int16)(4095 * (localPositionIF6123 - 9.73) / (9.95375 - 9.73));
        calValueIF6123 = (Int16)(4095 * (localPositionIF6123 - 9.751) / (9.94 - 9.751));

        if (calValueIF6123 >=0 && calValueIF6123 <= 4095)
        {
            global_variables.sensorValueIF6123 = calValueIF6123;
            global_variables.sensorPositionIF6123 = 0.375 + calValueIF6123 * (3.75-0.375) / 4095;
            valueTMProIF6123.text = global_variables.sensorValueIF6123.ToString();
            positionTMProIF6123.text = global_variables.sensorPositionIF6123.ToString("0.###") + " mm";
            barValueIF6123.fillAmount = global_variables.sensorValueIF6123 * 1.0f / 4095.0f;
        }
        else if (calValueIF6123 > 4095)
        {
            global_variables.sensorValueIF6123 = 8184;
            valueTMProIF6123.text = global_variables.sensorValueIF6123.ToString() + " (OL)";
            positionTMProIF6123.text = "NaN";
            barValueIF6123.fillAmount = 1.0f;
        }
        else if (calValueIF6123 <0)
        {
            global_variables.sensorValueIF6123 = -8184;
            valueTMProIF6123.text = global_variables.sensorValueIF6123.ToString() + " (UL)";
            positionTMProIF6123.text = "NaN";
            barValueIF6123.fillAmount = 0.0f;
        }


    }
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * moveSpeech;
        if (localPositionIF6123 >= 9.73)
        {
            cubeIF6123.transform.Translate(rotX / 10, 0, 0, Space.Self);
        }
        else
        {
            cubeIF6123.transform.localPosition = new Vector3(9.73001f, 6.4f, -6.32f);
        }
        
    }
}
