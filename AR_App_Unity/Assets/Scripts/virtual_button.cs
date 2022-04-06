using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class virtual_button : MonoBehaviour
{
     public GameObject btnVR1,btnVR2;
     GameObject capsua;
     string vbName;


    // Start is called before the first frame update
    void Start()
    {
        //capsua.gameObject.SetActive(false);
        btnVR1 = GameObject.Find("VirtualButton1");
        btnVR1.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onButtonPressed);
        btnVR1.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onButtonReleased);

        btnVR2 = GameObject.Find("VirtualButton2");
        btnVR2.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onButtonPressed);
        btnVR2.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onButtonReleased);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        //VR_Click_Logic = false; 
        // capsua.gameObject.SetActive(true);
        vbName = vb.VirtualButtonName;
        if (vbName == "VirtualButton1")
        {
            Debug.Log("Vao VB1");
        }    
        else if (vbName == "VirtualButton2")
        {
            Debug.Log("Vao VB2");
        }    
        //Global_variable.VR_Click_Logic = true;
    }
    public void onButtonReleased(VirtualButtonBehaviour vb)
    {
        vbName = vb.VirtualButtonName;
        if (vbName == "VirtualButton1")
        {
            Debug.Log("Thoat VB1");
        }
        else if (vbName == "VirtualButton2")
        {
            Debug.Log("Thoat VB2");
        }
    }
}
