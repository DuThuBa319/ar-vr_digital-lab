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
    public TextMeshProUGUI SP1_TW2000, rP1_TW2000, lightTemperaute;
    public TextMeshProUGUI rSLT_RB3100, cDir_RB3100, OUT_ENC_RB3100;
    public Image out1UGT, out2UGT, out1IF, out2IF, outTW2000;
    public Sprite outON, outOFF;

    public Renderer lightIF1, lightIF2, lightIF3, lightIF4, lightUGT1, lightUGT2;
    public Material lightOrangeIF6123, lightOff, lightGreenUGT524;
    float timerLightIF;
    int flagLightUGT = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region SimulateLightIF6123
        timerLightIF += Time.deltaTime;
        if (global_variables.onMCB == true)
        {
            if(global_variables.sensorValueIF6123 >0 && global_variables.sensorValueIF6123 <= 4095)
            {
                lightIF1.material = lightOrangeIF6123;
                lightIF2.material = lightOrangeIF6123;
                lightIF3.material = lightOrangeIF6123;
                lightIF4.material = lightOrangeIF6123;
            }    
            else
            {
                if (timerLightIF <= 0.4f)
                {
                    lightIF1.material = lightOrangeIF6123;
                    lightIF2.material = lightOrangeIF6123;
                    lightIF3.material = lightOrangeIF6123;
                    lightIF4.material = lightOrangeIF6123;
                    
                }
                else if (timerLightIF > 0.4f && timerLightIF <= 0.8f)
                {
                    lightIF1.material = lightOff;
                    lightIF2.material = lightOff;
                    lightIF3.material = lightOff;
                    lightIF4.material = lightOff;
                }
                else timerLightIF = 0;
            }    
        } 
        else
        {
                lightIF1.material = lightOff;
                lightIF2.material = lightOff;
                lightIF3.material = lightOff;
                lightIF4.material = lightOff;
        }
        #endregion

        //Chinh sua lai logic den cho hop ly dung thuc te
        #region SimulateLightUGT524
        if (global_variables.onMCB == true)
        {
            if (global_variables.sensorPositionUGT524 >= 35 && global_variables.sensorPositionUGT524 <= 300 && (global_variables.out1UGT != 1))
            {
                lightUGT1.material = lightGreenUGT524;
                lightUGT2.material = lightGreenUGT524;
            }  
            else
            {
                lightUGT1.material = lightOff;
                lightUGT2.material = lightOff;
            }    
            if (global_variables.out1UGT == 1)
            {
                lightUGT1.material = lightOrangeIF6123;
                lightUGT2.material = lightOrangeIF6123;
            }    
        }   
        else
        {
            lightUGT1.material = lightOff;
            lightUGT2.material = lightOff;
        }
        #endregion

        SP1_SSC1_UGT.text = global_variables.SP1SSC1UGT.ToString() + "mm";
        SP2_SSC1_UGT.text = global_variables.SP2SSC1UGT.ToString() + "mm";
        SP1_SSC2_UGT.text = global_variables.SP1SSC2UGT.ToString() + "mm";
        SP2_SSC2_UGT.text = global_variables.SP2SSC2UGT.ToString() + "mm";
        if (global_variables.sensorPositionUGT524 >= global_variables.SP2SSC1UGT && global_variables.sensorPositionUGT524 <= global_variables.SP1SSC1UGT)
        {
            out1UGT.sprite = outON;
            global_variables.out1UGT = 1;
        }
        else
        {
            out1UGT.sprite = outOFF;
            global_variables.out1UGT = 0;
        }
        if (global_variables.sensorPositionUGT524 >= global_variables.SP2SSC2UGT && global_variables.sensorPositionUGT524 <= global_variables.SP1SSC2UGT)
        {
            out2UGT.sprite = outON;
            global_variables.out2UGT = 2;
        }
        else
        {
            out2UGT.sprite = outOFF;
            global_variables.out2UGT = 0;
        }

        SP1_SSC1_IF.text = global_variables.SP1SSC1IF.ToString();
        SP2_SSC1_IF.text = global_variables.SP2SSC1IF.ToString();
        SP1_SSC2_IF.text = global_variables.SP1SSC2IF.ToString();
        SP2_SSC2_IF.text = global_variables.SP2SSC2IF.ToString();
        if (global_variables.sensorValueIF6123 >= global_variables.SP2SSC1IF && global_variables.sensorValueIF6123 <= global_variables.SP1SSC1IF)
        {
            out1IF.sprite = outON;
            global_variables.out1IF = 1;
        }
        else
        {
            out1IF.sprite = outOFF;
            global_variables.out1IF = 0;
        }
        if (global_variables.sensorValueIF6123 >= global_variables.SP2SSC2IF && global_variables.sensorValueIF6123 <= global_variables.SP1SSC2IF)
        {
            out2IF.sprite = outON;
            global_variables.out2IF = 2;
        }
        else
        {
            out2IF.sprite = outOFF;
            global_variables.out2IF = 0;
        }

        SP1_TW2000.text = "SP1: " + global_variables.SP1TW2000.ToString();
        rP1_TW2000.text = "rP1: " + global_variables.rP1TW2000.ToString();
        lightTemperaute.text = (global_variables.sensorValueTW2000 / 10.0).ToString("0.#");
        if (global_variables.sensorValueTW2000 >= global_variables.SP1TW2000) //Chua hieu ro
        {
            outTW2000.sprite = outON;
            global_variables.outTW = 1;
        }
        else
        {
            outTW2000.sprite = outOFF;
            global_variables.outTW = 0;
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
