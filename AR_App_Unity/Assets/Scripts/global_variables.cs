using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class global_variables : MonoBehaviour
{
    public static bool modeVR;
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
    public static float velSP;
    public static float posSP;
    public static float vel;
    public static float pos;
    public static float posHome;
    public static float posTotal;
    public static bool LS1;
    public static bool LS2;

    public static ushort realOnOffG120;
    public static ushort realVelSPG120;
    public static ushort realVelG120;

    public static ushort onOffG120;
    public static ushort velSPG120;
    public static ushort velG120;
    public static ushort velWriteG120;
    public static ushort setVelSPG120;
    public static ushort setOnOffG120;

    //AR App --> DA --> Real + Simulate Vali PLC
    public static float realSetPosSP;
    public static float realSetVelSP;
    public static float simulateSetPosSP;
    public static float simulateSetVelSP;
    public static ushort realSetVelSPG120;
    public static ushort realSetOnOffG120;


    public static byte realDI;
    public static byte realDO;
    public static ushort realAI;
    public static float realAO;
    public static float realVelSP;
    public static float realVel;
    public static float realPosSP;
    public static float realPos;
    public static float realVelEnc;
    public static float realPosEnc;
    public static bool realLS1;
    public static bool realLS2;

    // AR App --> DA --> ValiPLC
    public static byte DI;
    public static ushort AI;


    //MCB
    public static bool onMCB;
    public static bool onMCBG120;
    public static bool onMCBPLC;

    //Simulate
    public static bool simulateTW;
    public static bool clickToggleSwitch;

}
