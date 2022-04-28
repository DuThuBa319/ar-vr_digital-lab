using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Potentiometer : MonoBehaviour
{
    float rotX;
    float degree;
    public float speed;
    public GameObject potentiometer;
    void Update()
    {


    }
    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            rotX = Input.GetAxis("Mouse X") * speed;

            if (potentiometer.transform.localEulerAngles.z >= 280)
            {
                degree = potentiometer.transform.localEulerAngles.z - 307;
            }
            else degree = potentiometer.transform.localEulerAngles.z + 53;
            if ((degree <= 300 || rotX < 0) && (degree >= 0 || rotX > 0))
            {
                potentiometer.transform.Rotate(Vector3.forward, rotX);
            }
            else potentiometer.transform.Rotate(Vector3.forward, 0.0f); 
            Debug.Log(degree);
        }
    }
}
