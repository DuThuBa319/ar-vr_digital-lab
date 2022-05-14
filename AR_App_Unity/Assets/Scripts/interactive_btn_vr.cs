using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;


public class interactive_btn_vr : MonoBehaviour
{
    public VRInteractiveItem btnObj;
    private control_panels_v1 scriptControlPanel;
    public Image dotPic1, backgroundPic1;
    public string TAG;
    public int btnNumber;

    private void Awake()
    {
        scriptControlPanel = GameObject.FindGameObjectWithTag(TAG).GetComponent<control_panels_v1>();
    }


    private void OnEnable()
    {
        Debug.Log("Enable");
        btnObj.OnOver += HandleOver;
        btnObj.OnOut += HandleOut;
        btnObj.OnClick += HandleClick;
         

    }

    private void OnDisable()
    {
        Debug.Log("Disable");
        btnObj.OnOver -= HandleOver;
        btnObj.OnOut -= HandleOut;
        btnObj.OnClick -= HandleClick;

    }

    //Handle the Over event
    private void HandleOver()
    {
        Debug.Log("Show over state");
        dotPic1.color = Color.green;
        backgroundPic1.color = Color.green;


    }
    //Handle the Out event
    private void HandleOut()
    {
        Debug.Log("Show out state");
        dotPic1.color = Color.red;
        backgroundPic1.color = Color.red;
    }

    //Handle the Click event
    private void HandleClick()
    {
        if (btnNumber == 1)
        {
            scriptControlPanel.OpenPanelDatasheet();
        }   
        else if (btnNumber == 2)
        {
            scriptControlPanel.OpenPanelDatasheetDown();
        }   
        else if (btnNumber == 3)
        {
            scriptControlPanel.OpenPanelDatasheetUp();
        }    
        else if (btnNumber == 4)
        {
            scriptControlPanel.OpenPanelData();
        }    
        else if (btnNumber == 5)
        {
            scriptControlPanel.OpenPanelWiring();
        }    
        else if (btnNumber == 6)
        {
            scriptControlPanel.BackButton();
            
        }
        dotPic1.color = Color.red;
        backgroundPic1.color = Color.red;
        
    }
}
