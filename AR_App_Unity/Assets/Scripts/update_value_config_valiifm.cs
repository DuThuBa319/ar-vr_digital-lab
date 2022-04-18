using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class update_value_config_valiifm : MonoBehaviour
{
    public TextMeshProUGUI SP1_SSC1_UGT, SP2_SSC1_UGT, SP1_SSC2_UGT, SP2_SSC2_UGT;
    public TextMeshProUGUI SP1_SSC1_IF, SP2_SSC1_IF, SP1_SSC2_IF, SP2_SSC2_IF;
    public TextMeshProUGUI SP1_TW2000, rP1_TW2000;
    public TextMeshProUGUI rSLT_RB3100, cDir_RB3100, OUT_ENC_RB3100;
    public Image out1UGT, out2UGT, out1IF, out2IF, outTW2000;
    public Sprite outON, outOFF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SP1_SSC1_UGT.text = global_variables.SP1SSC1UGT.ToString() + "mm";
        SP2_SSC1_UGT.text = global_variables.SP2SSC1UGT.ToString() + "mm";
        SP1_SSC2_UGT.text = global_variables.SP1SSC2UGT.ToString() + "mm";
        SP2_SSC2_UGT.text = global_variables.SP2SSC2UGT.ToString() + "mm";
        if (global_variables.sensorPositionUGT524 >= global_variables.SP2SSC1UGT && global_variables.sensorPositionUGT524 <= global_variables.SP1SSC1UGT)
        {
            out1UGT.sprite = outON;
        }
        else
        {
            out1UGT.sprite = outOFF;
        }
        if (global_variables.sensorPositionUGT524 >= global_variables.SP2SSC2UGT && global_variables.sensorPositionUGT524 <= global_variables.SP1SSC2UGT)
        {
            out2UGT.sprite = outON;
        }
        else
        {
            out2UGT.sprite = outOFF;
        }

        SP1_SSC1_IF.text = global_variables.SP1SSC1IF.ToString();
        SP2_SSC1_IF.text = global_variables.SP2SSC1IF.ToString();
        SP1_SSC2_IF.text = global_variables.SP1SSC2IF.ToString();
        SP2_SSC2_IF.text = global_variables.SP2SSC2IF.ToString();
        if (global_variables.sensorValueIF6123 >= global_variables.SP2SSC1IF && global_variables.sensorValueIF6123 <= global_variables.SP1SSC1IF)
        {
            out1IF.sprite = outON;
        }
        else
        {
            out1IF.sprite = outOFF;
        }
        if (global_variables.sensorValueIF6123 >= global_variables.SP2SSC2IF && global_variables.sensorValueIF6123 <= global_variables.SP1SSC2IF)
        {
            out2IF.sprite = outON;
        }
        else
        {
            out2IF.sprite = outOFF;
        }

        SP1_TW2000.text = "SP1: " + global_variables.SP1TW2000.ToString();
        rP1_TW2000.text = "rP1: " + global_variables.rP1TW2000.ToString();
        if (global_variables.sensorValueTW2000 >= global_variables.SP1TW2000) //Chua hieu ro
        {
            outTW2000.sprite = outON;
        }
        else
        {
            outTW2000.sprite = outOFF;
        }

        rSLT_RB3100.text = global_variables.rSLTRB3100.ToString() + "ppr";
        if (global_variables.cDirRB3100 == 0)
        {
            cDir_RB3100.text = "cw/ A trước B";
        }    
        else if (global_variables.cDirRB3100 == 1)
        {
            cDir_RB3100.text = "ccw/ B trước A";
        }
        if (global_variables.OUTENCRB3100 == 0)
        {
            OUT_ENC_RB3100.text = "TTL";
        }
        else if (global_variables.OUTENCRB3100 == 1)
        {
            OUT_ENC_RB3100.text = "HTL";
        }

    }
}
