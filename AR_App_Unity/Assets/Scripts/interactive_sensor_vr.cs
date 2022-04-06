using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class interactive_sensor_vr : MonoBehaviour
{
    public VRInteractiveItem UGT524;
    //public VRInteractiveItem btn1UGT524;
    
    public Image dotPic1, backgroundPic1;
    public GameObject panelUGT524;
    bool showUGT524;
    private void Awake()
    {
        //m_NormalMaterial = m_Renderer.material;
        panelUGT524.gameObject.SetActive(true);
    }


    private void OnEnable()
    {
        Debug.Log("Enable");
        UGT524.OnOver += HandleOver;
        UGT524.OnOut += HandleOut;
        UGT524.OnClick += HandleClick;

        //btn1UGT524.OnOver += HandleOver;
        //btn1UGT524.OnOut += HandleOut;
        //btn1UGT524.OnClick += HandleClick;
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
        UGT524.OnOver -= HandleOver;
        UGT524.OnOut -= HandleOut;
        UGT524.OnClick -= HandleClick;

        //btn1UGT524.OnOver -= HandleOver;
        //btn1UGT524.OnOut -= HandleOut;
        //btn1UGT524.OnClick -= HandleClick;
    }

    //Handle the Over event
    private void HandleOver()
    {
        //m_Renderer.material = m_OverMaterial;
        Debug.Log("Show over state");
        dotPic1.color = Color.green;
        backgroundPic1.color = Color.green;


    }

    //Handle the Out event
    private void HandleOut()
    {
        //m_Renderer.material = m_NormalMaterial;
        Debug.Log("Show out state");
        dotPic1.color = Color.red;
        backgroundPic1.color = Color.red;
        //panelUGT524.gameObject.SetActive(false);
    }

    //Handle the Click event
    private void HandleClick()
    {
        //m_Renderer.material = m_ClickedMaterial;
        Debug.Log("Show click state");
        if (showUGT524 == false)
        {
            panelUGT524.gameObject.SetActive(true);
            showUGT524 = true;
        }    
        else
        {
            panelUGT524.gameObject.SetActive(false);
            showUGT524 = false;
        }    
        
    }
}
