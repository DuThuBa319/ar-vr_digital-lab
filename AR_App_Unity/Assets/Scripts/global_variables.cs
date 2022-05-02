using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class global_variables : MonoBehaviour
{
    public static bool clickGameObjectO5C500;
    public static bool clickDataO5C500;

    public static Int16 sensorPositionUGT524;
    public static double sensorPositionIF6123;
    public static Int16 sensorValueIF6123;

    public static Int16 pulseRB3100;

    public static Int16 sensorValueTW2000;

    public static bool sensorO5C500;
    public static bool clickKT5112;

    public static short out1UGT, out2UGT, out1IF, out2IF, outTW;

    //Desktop App to ValiIFM 
    public static ushort SP1SSC1UGT;
    public static ushort SP2SSC1UGT;
    public static ushort SP1SSC2UGT;
    public static ushort SP2SSC2UGT;

    public static ushort SP1SSC1IF;
    public static ushort SP2SSC1IF;
    public static ushort SP1SSC2IF;
    public static ushort SP2SSC2IF;

    public static ushort SP1TW2000;
    public static ushort rP1TW2000;

    public static ushort rSLTRB3100;
    public static byte cDirRB3100;
    public static byte OUTENCRB3100;

    public static ushort disUGT;
    public static float disIF;
    public static float temTW;
    public static float angleRB;
    public static byte byte65, byte67;

    //Desktop App to Real ValiIFM
    public static ushort realW0UGT;
    public static ushort realW1UGT;
    public static ushort realW0IF;
    public static float realDisIF;
    public static ushort realW0TW;
    public static ushort realW1TW;
    public static float realTemTW;
    public static ushort realW0RB;
    public static float realAngleRB;
    public static byte realByte65, realByte67, realByte68;

    public static ushort realSP1SSC1UGT;
    public static ushort realSP2SSC1UGT;
    public static ushort realSP1SSC2UGT;
    public static ushort realSP2SSC2UGT;

    public static ushort realSP1SSC1IF;
    public static ushort realSP2SSC1IF;
    public static ushort realSP1SSC2IF;
    public static ushort realSP2SSC2IF;

    public static ushort realSP1TW2000;
    public static ushort realrP1TW2000;

    public static ushort realrSLTRB3100;
    public static byte realcDirRB3100;
    public static byte realOUTENCRB3100;

    //ValiPLC + Real ValiPLC --> DA --> AR App
    public static byte DO;
    public static ushort AO;

    public static byte realDI;
    public static byte realDO;
    public static ushort realAI;
    public static float realAO;

    // AR App --> DA --> ValiPLC
    public static byte DI;
    public static ushort AI;


    //MCB
    public static bool onMCB;
    public static bool onMCBPLC;

    //Simulate
    public static bool simulateTW;
}
