using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class update_data_real_vali : MonoBehaviour
{
    public Image out1UGT, out2UGT, out1IF, out2IF, outTW, outO5C, outOnKT, outOffKT;
    public Sprite tickON, tickOFF, blueO5C, grayO5C, redLight, greenLight, orangeLight, grayLight;
    public Image prgBarUGT, prgBarIF, circleBarTW, clockwiseRB, picRedLight, picGreenLight, picOrangeLight, statusMotor, statusRelay;
    public TextMeshProUGUI txtStatusMotor, txtStatusRelay;
    public Image statusUGT, statusTW;
    public TextMeshProUGUI disUGT, disIF, valIF,  valTW, val100_1000TW, valRB, angleRB;
    public TextMeshProUGUI disUGT_AL1102, valIF_AL1102, valTW_AL1102, valRB_AL1102, outO5C_AL2401, outKT_AL2401, outMotor, outRL, outOL, outGL;
    public TextMeshProUGUI SP1SSC1UGT, SP2SSC1UGT, SP1SSC2UGT, SP2SSC2UGT, SP1SSC1IF, SP2SSC1IF, SP1SSC2IF, SP2SSC2IF;
    public TextMeshProUGUI SP1TW, rP1TW, rSLTRB, cDirRB, OUT_ENCRB, statusRL, statusOL, statusGL;
    ushort outW1UGT, outW0IF, valW0IF, outW1TW;
    // Start is called before the first frame update
    void Start()
    {
        outOnKT.gameObject.SetActive(false);
        outOffKT.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        #region ValueValiIFM
        outW1UGT = (ushort)(global_variables.realW1UGT & 3);
        outW0IF = (ushort)(global_variables.realW0IF & 3);
        valW0IF = (ushort)(global_variables.realW0IF >> 2);
        outW1TW = (ushort)(global_variables.realW1TW & 1);
        if ((ushort)(global_variables.realW1UGT & 255) <= 3)
        {
            statusUGT.sprite = tickON;
        } 
        else
        {
            statusUGT.sprite = tickOFF;
        }
        if ((ushort)(global_variables.realW1TW & 255) <= 3)
        {
            statusTW.sprite = tickON;
        }
        else
        {
            statusTW.sprite = tickOFF;
        }

        //UGT524
        if (outW1UGT == 0)
        {
            out1UGT.sprite = tickOFF;
            out2UGT.sprite = tickOFF;
        } 
        else if (outW1UGT == 1)
        {
            out1UGT.sprite = tickON;
            out2UGT.sprite = tickOFF;
        }
        else if (outW1UGT == 2)
        {
            out1UGT.sprite = tickOFF;
            out2UGT.sprite = tickON;
        }
        else if (outW1UGT == 2)
        {
            out1UGT.sprite = tickON;
            out2UGT.sprite = tickON;
        }

        disUGT.text = global_variables.realW0UGT.ToString() + " mm";
        //Debug.Log("gia tri la " + global_variables.realW0UGT.ToString());
        //disUGT.text =  "sssss mm";
        prgBarUGT.fillAmount = global_variables.realW0UGT * 1.0f / 300.0f;
        disUGT_AL1102.text = global_variables.realW0UGT.ToString();

        //IF6123
        if (outW0IF == 0)
        {
            out1IF.sprite = tickOFF;
            out2IF.sprite = tickOFF;
        }
        else if (outW0IF == 1)
        {
            out1IF.sprite = tickON;
            out2IF.sprite = tickOFF;
        }
        else if (outW0IF == 2)
        {
            out1IF.sprite = tickOFF;
            out2IF.sprite = tickON;
        }
        else if (outW0IF == 2)
        {
            out1IF.sprite = tickON;
            out2IF.sprite = tickON;
        }

        valIF.text = valW0IF.ToString();
        //text mm
        prgBarIF.fillAmount = valW0IF / 4095.0f;
        valIF_AL1102.text = valW0IF.ToString();
        disIF.text = global_variables.realDisIF.ToString("0.### " + "mm");

        //TW2000
        if (outW1TW == 0)
        {
            outTW.sprite = tickOFF;
        }    
        else if (outW1TW == 1)
        {
            outTW.sprite = tickON;
        }
        valTW.text = (global_variables.realW0TW/10.0f).ToString("0.0");
        valTW_AL1102.text = global_variables.realW0TW.ToString();
        if (global_variables.realW0TW <= 100)
        {
            val100_1000TW.text = "100°C";
            circleBarTW.fillAmount = global_variables.realW0TW / 100.0f;
        }
        else
        {
            val100_1000TW.text = "1000°C";
            circleBarTW.fillAmount = global_variables.realW0TW / 1000.0f;
        }

        //RB3100
        valRB.text = global_variables.realW0RB.ToString();
        angleRB.text = "Vị trí: " + global_variables.realAngleRB.ToString("0.##") +"°";
        if (global_variables.realcDirRB3100 == 0)
        {
            clockwiseRB.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -global_variables.realAngleRB);
        }    
        else
        {
            clockwiseRB.transform.localEulerAngles = new Vector3(0.0f, 0.0f, global_variables.realAngleRB);
        }    
        

        valRB_AL1102.text = global_variables.realW0RB.ToString();

        //O5C500
        if ((global_variables.realByte68 & 32) == 32)
        {
            outO5C.sprite = blueO5C;
            outO5C_AL2401.text = "1";
        }    
        else
        {
            outO5C.sprite = grayO5C;
            outO5C_AL2401.text = "0";
        }    
        
        //KT5112
        if ((global_variables.realByte68 & 16) == 16)
        {
            outOnKT.gameObject.SetActive(true);
            outOffKT.gameObject.SetActive(false);
            outKT_AL2401.text = "1";
        }    
        else
        {
            outOnKT.gameObject.SetActive(false);
            outOffKT.gameObject.SetActive(true);
            outKT_AL2401.text = "0";
        }

        //BYTE65&67
        if (global_variables.realByte65 == 0)
        {
            outRL.text = "0";
            outGL.text = "0";
            picRedLight.sprite = grayLight;
            picGreenLight.sprite = grayLight;
            statusRL.text = "OFF";
            statusGL.text = "OFF";
        }
        else if (global_variables.realByte65 == 1)
        {
            outRL.text = "1";
            outGL.text = "0";
            picRedLight.sprite = redLight;
            picGreenLight.sprite = grayLight;
            statusRL.text = "ON";
            statusGL.text = "OFF";
        }
        else if (global_variables.realByte65 == 2)
        {
            outRL.text = "0";
            outGL.text = "1";
            picRedLight.sprite = grayLight;
            picGreenLight.sprite = greenLight;
            statusRL.text = "OFF";
            statusGL.text = "ON";
        }
        else if (global_variables.realByte65 == 3)
        {
            outRL.text = "1";
            outGL.text = "1";
            picRedLight.sprite = redLight;
            picGreenLight.sprite = greenLight;
            statusRL.text = "ON";
            statusGL.text = "ON";
        }

        if (global_variables.realByte67 == 0)
        {
            outMotor.text = "0";
            outOL.text = "0";
            statusMotor.sprite = tickOFF;
            statusRelay.sprite = tickOFF;
            txtStatusMotor.text = "OFF";
            txtStatusRelay.text = "OFF";
            picOrangeLight.sprite = grayLight;
            statusOL.text = "OFF";
        }
        else if (global_variables.realByte67 == 1)
        {
            outMotor.text = "1";
            outOL.text = "0";
            statusMotor.sprite = tickON;
            statusRelay.sprite = tickON;
            txtStatusMotor.text = "ON";
            txtStatusRelay.text = "ON";
            picOrangeLight.sprite = grayLight;
            statusOL.text = "OFF";

        }
        else if (global_variables.realByte67 == 2)
        {
            outMotor.text = "0";
            outOL.text = "1";
            statusMotor.sprite = tickOFF;
            statusRelay.sprite = tickOFF;
            txtStatusMotor.text = "OFF";
            txtStatusRelay.text = "OFF";
            picOrangeLight.sprite = orangeLight;
            statusOL.text = "ON";
        }
        else if (global_variables.realByte67 == 3)
        {
            outMotor.text = "1";
            outOL.text = "1";
            statusMotor.sprite = tickON;
            statusRelay.sprite = tickON;
            txtStatusMotor.text = "ON";
            txtStatusRelay.text = "ON";
            picOrangeLight.sprite = orangeLight;
            statusOL.text = "ON";
        }
        #endregion

        #region ConfigValiIFM
        if (global_variables.realSP1SSC1UGT != 0) SP1SSC1UGT.text = global_variables.realSP1SSC1UGT.ToString();
        else SP1SSC1UGT.text = "NaN";
        if (global_variables.realSP2SSC1UGT != 0) SP2SSC1UGT.text = global_variables.realSP2SSC1UGT.ToString();
        else SP1SSC1UGT.text = "NaN";
        if (global_variables.realSP1SSC2UGT != 0) SP1SSC2UGT.text = global_variables.realSP1SSC2UGT.ToString();
        else SP1SSC1UGT.text = "NaN";
        if (global_variables.realSP2SSC2UGT != 0) SP2SSC2UGT.text = global_variables.realSP2SSC2UGT.ToString();
        else SP2SSC2UGT.text = "NaN";

        if (global_variables.realSP1SSC1IF != 0) SP1SSC1IF.text = global_variables.realSP1SSC1IF.ToString();
        else SP1SSC1IF.text = "NaN";
        Debug.Log("SP1SSC1IFF ==========" + global_variables.realSP1SSC1IF.ToString());
        if (global_variables.realSP2SSC1IF != 0) SP2SSC1IF.text = global_variables.realSP2SSC1IF.ToString();
        else SP1SSC1IF.text = "NaN";
        if (global_variables.realSP1SSC2IF != 0) SP1SSC2IF.text = global_variables.realSP1SSC2IF.ToString();
        else SP1SSC1IF.text = "NaN";
        if (global_variables.realSP2SSC2IF != 0) SP2SSC2IF.text = global_variables.realSP2SSC2IF.ToString();
        else SP2SSC2IF.text = "NaN";

        if (global_variables.realSP1TW2000 != 0) SP1TW.text = "SP1: "+ global_variables.realSP1TW2000.ToString();
        else SP1TW.text = "NaN";
        if (global_variables.realrP1TW2000 != 0) rP1TW.text = "rP1: "+global_variables.realrP1TW2000.ToString();
        else rP1TW.text = "NaN";

        if (global_variables.realrSLTRB3100 != 0) rSLTRB.text = global_variables.realrSLTRB3100.ToString();
        else rSLTRB.text = "NaN";
        
        if (global_variables.realcDirRB3100 == 0) cDirRB.text = "cw/ A trước B";
        else if (global_variables.realcDirRB3100 == 1) cDirRB.text = "ccw/ B trước A";
        else cDirRB.text = "NaN";
        if (global_variables.realOUTENCRB3100 == 0) OUT_ENCRB.text = "TTL";
        else if (global_variables.realOUTENCRB3100 == 1) OUT_ENCRB.text = "HTL";
        else cDirRB.text = "NaN";
        Debug.Log("ddddddddddddirec " + global_variables.realcDirRB3100.ToString());
        #endregion
    }
}
