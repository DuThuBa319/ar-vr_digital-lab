using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class on_off_mcb : MonoBehaviour
{
    public GameObject objOnMCB, objOffMCB;
    public TextMeshProUGUI textButtonOnOffMCB;
    public Image statusOnOffMCB;
    public Sprite spriteOnMCB, spriteOffMCB;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOffMCB()
    {
        if (global_variables.onMCB == false)
        {
            objOnMCB.gameObject.SetActive(true);
            objOffMCB.gameObject.SetActive(false);
            textButtonOnOffMCB.text = "OFF MCB";
            statusOnOffMCB.sprite = spriteOnMCB;
            global_variables.onMCB = true;
        }    
        else
        {
            objOnMCB.gameObject.SetActive(false);
            objOffMCB.gameObject.SetActive(true);
            textButtonOnOffMCB.text = "ON MCB";
            statusOnOffMCB.sprite = spriteOffMCB;
            global_variables.onMCB = false;
        }    

    }    
}
