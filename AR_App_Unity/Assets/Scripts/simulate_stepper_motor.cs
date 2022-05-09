using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class simulate_stepper_motor : MonoBehaviour
{
    public GameObject vitmeObj;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        z = -0.00001039f * global_variables.posTotal + 0.003031f;
        if (z >= 0.001936f && z <= 0.003067f)
        {
            vitmeObj.transform.localPosition = new Vector3(-0.002065f, 0.001075f, z);
        }
        else if (z < 0.001936f)
        {
            vitmeObj.transform.localPosition = new Vector3(-0.002065f, 0.001075f, 0.001936f);
        }
        else if (z > 0.003067f)
        {
            vitmeObj.transform.localPosition = new Vector3(-0.002065f, 0.001075f, 0.003067f);
        }


    }
    
}
