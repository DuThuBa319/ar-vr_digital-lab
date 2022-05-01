using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Rotate_Potentiometer : MonoBehaviour
{
    float rotX;
    float degree, a1, a,a2, calDegree;
    public float speed;
    public GameObject potentiometer, gameObjParent, gameObjRotate;
    public TextMeshProUGUI ledAO;
    void Update()
    {
        a1 = gameObjRotate.transform.eulerAngles.z;
        a2 = gameObjParent.transform.parent.eulerAngles.z;
        degree = a1 - a2;
         
        
        if (degree <0 )
        {
            calDegree = degree + 360;
        }
        else
        {
            calDegree = degree;
        }
        //Debug.Log("degree==="+degree);
        Debug.Log("CalDegree===" + calDegree);
        
        if (calDegree >= 0 && calDegree <= 297)
        {
            potentiometer.transform.localEulerAngles = new Vector3(0.0f, 0.0f, degree);
        }
        
        else if (calDegree >297 && calDegree < 330)
        {
            potentiometer.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 297.0f);
        }
        else if (calDegree > 330)
        {
            potentiometer.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }

        //ledAO.text = (calDegree / 297.0f * 10.0f).ToString("0.0");
        global_variables.AI = (ushort)((calDegree/297.0f)*27648);
    }
    private void OnMouseDrag()
    {  
        if ((calDegree >= 0 && calDegree <= 297)) 
        {
            float rotX = Input.GetAxis("Mouse X") * speed;
            transform.Rotate(Vector3.forward, rotX);
        }
    }
}
