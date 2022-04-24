using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class update_data_real_vali : MonoBehaviour
{
    public Image out1UGT, out2UGT, out1IF, out2IF, outTW, outO5C, outOnKT, outOffKT;
    public Sprite tickON, tickOFF, blueO5C, grayO5C;
    public Image cirBarTW, prgBarUGT, prgBarIF;
    public TextMeshProUGUI disUGT, disIF, valIF,  valTW, valRB, angleRB;//goc quay, temTW,
    ushort outW1UGT, outW0IF, valW0IF, outW1TW;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        outW1UGT = (ushort)(global_variables.realW1UGT & 3);
        outW0IF = (ushort)(global_variables.realW0IF & 3);
        valW0IF = (ushort)(global_variables.realW0IF >> 2);
        outW1TW = (ushort)(global_variables.realW0TW & 1);
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
        prgBarUGT.fillAmount = global_variables.realW0UGT * 1.0f / 300.0f;

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
        prgBarIF.fillAmount = valW0IF * 1.0f / 4095.0f;

        //TW2000
        if (outW1TW == 0)
        {
            outTW.sprite = tickOFF;
        }    
        else if (outW1TW == 1)
        {
            outTW.sprite = tickON;
        }
        valTW.text = global_variables.realW0TW.ToString();
        //fill cirbar

        //RB3100
        valRB.text = global_variables.realW0RB.ToString();
    }
}
