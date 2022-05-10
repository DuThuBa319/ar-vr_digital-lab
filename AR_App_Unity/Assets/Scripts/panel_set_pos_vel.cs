using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class panel_set_pos_vel : MonoBehaviour
{
    public GameObject panelPosVelSP, panelSetPosVelSP;
    // Start is called before the first frame update
    void Start()
    {
        panelSetPosVelSP.gameObject.SetActive(false);
        panelPosVelSP.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OpenPanelSetPosVelSP()
    {
        panelPosVelSP.gameObject.SetActive(false);
        panelSetPosVelSP.gameObject.SetActive(true);
    }    
    public void OpenPanelPosVelSP()
    {
        panelSetPosVelSP.gameObject.SetActive(false);
        panelPosVelSP.gameObject.SetActive(true);
    }    
}
