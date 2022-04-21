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

    public GameObject cubeUGT524, cubeIF6123;
    //bool showCubeUGT524, showCubeIF6123;

    // Start is called before the first frame update
    void Start()
    {
        cubeUGT524.gameObject.SetActive(false);
        cubeIF6123.gameObject.SetActive(false);
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

            cubeUGT524.gameObject.SetActive(true);
            cubeIF6123.gameObject.SetActive(true);
            global_variables.simulateTW = true;

            global_variables.onMCB = true;

            

        }    
        else
        {
            objOnMCB.gameObject.SetActive(false);
            objOffMCB.gameObject.SetActive(true);
            textButtonOnOffMCB.text = "ON MCB";
            statusOnOffMCB.sprite = spriteOffMCB;
            global_variables.onMCB = false;

            cubeUGT524.gameObject.SetActive(false);
            cubeIF6123.gameObject.SetActive(false);
            global_variables.simulateTW = false;
        }    

    }    
}
