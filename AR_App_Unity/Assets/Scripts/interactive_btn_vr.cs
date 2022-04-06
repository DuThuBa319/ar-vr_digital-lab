using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class interactive_btn_vr : MonoBehaviour
{
    public VRInteractiveItem btn1UGT524;
    //public VRInteractiveItem btn1UGT524;

    public Image dotPic1, backgroundPic1;
    //public GameObject panelbtn1UGT524;
    bool showbtn1UGT524;
    private void Awake()
    {
        //m_NormalMaterial = m_Renderer.material;
        //panelbtn1UGT524.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        Debug.Log("Enable");
        btn1UGT524.OnOver += HandleOver;
        btn1UGT524.OnOut += HandleOut;
        btn1UGT524.OnClick += HandleClick;

        
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
        btn1UGT524.OnOver -= HandleOver;
        btn1UGT524.OnOut -= HandleOut;
        btn1UGT524.OnClick -= HandleClick;

        
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
        //panelbtn1UGT524.gameObject.SetActive(false);
    }

    //Handle the Click event
    private void HandleClick()
    {
        //m_Renderer.material = m_ClickedMaterial;
        Debug.Log("btn1_uuuuuuuugggggggggtttttttttt555552222244444444");
        

    }
}
