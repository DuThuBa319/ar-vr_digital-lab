using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using System;
using System.Text;
using TMPro;
[Serializable]

public class mqtt_script : M2MqttUnity.M2MqttUnityClient
{
    public Sprite connectError, connectOK;
    public Image iconConnect;
    public TextMeshProUGUI notifyConnect, txtBtnConnect;
    public TMP_InputField inputFieldID;
    public TMP_InputField addressIF, portIF, usernameIF, passwordIF;
    


    public DataDAToValiIFM DataDAToValiIFMObj = new DataDAToValiIFM();
    public DataDAToValiPLC DataDAToValiPLCObj = new DataDAToValiPLC();
    public DataDAToInverter DataDAToInverterObj = new DataDAToInverter();
    public DataValiIFMToDA DataValiIFMToDAObj = new DataValiIFMToDA();
    public DataValiPLCToDA DataValiPLCToDAObj = new DataValiPLCToDA();
    public DataSetSPValiPLCToDA DataSetSPValiPLCToDAObj = new DataSetSPValiPLCToDA();
    public DataButtonReadConfigValiIFM DataButtonReadConfigValiIFMObj = new DataButtonReadConfigValiIFM();
    public DataSetSPRInverter DataSetSPRInverterObj = new DataSetSPRInverter();
    public DataSetOnOffRInverter DataSetOnOffRInverterObj = new DataSetOnOffRInverter();
    public DataSetSPInverter DataSetSPInverterObj = new DataSetSPInverter();
    public DataSetOnOffInverter DataSetOnOffInverterObj = new DataSetOnOffInverter();

    public DataValueDAToRValiIFM DataValueDAToRValiIFMObj = new DataValueDAToRValiIFM();
    public DataConfParaDAToRValiIFM DataConfParaDAToRValiIFMObj = new DataConfParaDAToRValiIFM();
    public DataDAToRValiPLC DataDAToRValiPLCObj = new DataDAToRValiPLC();
    public DataDAToRInverter DataDAToRInverterObj = new DataDAToRInverter();
    public DataRValiPLCToDA DataRValiPLCToDAObj = new DataRValiPLCToDA();
    public DataInverterToDA DataInverterToDAObj = new DataInverterToDA();





    float startTime, t;
    bool mqttConnected, flagConnect = true, pubSimulateSP, pubRealSP, pubRealSPG120, pubRealOnOffG120, pubSPG120, pubOnOffG120;
    string topicARAppToDA, topicDAtoARApp;
    string jsonDataReceive, jsonPublish;
    int readConfig;

    //Class
    //----------------------------------------------------------------------
    public class DataDAToValiIFM
    {
        public byte idV1;
        public ushort SP1SSC1UGT = 300;
        public ushort SP2SSC1UGT = 40;
        public ushort SP1SSC2UGT = 300;
        public ushort SP2SSC2UGT = 40;

        public ushort SP1SSC1IF = 3800;
        public ushort SP2SSC1IF = 388;
        public ushort SP1SSC2IF = 3800;
        public ushort SP2SSC2IF = 388;

        public ushort SP1TW2000 = 2500;
        public ushort rP1TW2000 = 2300;

        public ushort rSLTRB3100 = 1024;
        public byte cDirRB3100 = 0;
        public byte OUT_ENCRB = 1;

        public ushort disUGT;
        public float disIF;
        public float temTW;
        public float angleRB;
        public byte byte65, byte67;
    }
    public class DataDAToValiPLC
    {
        public byte idV2;
        public byte DI, DO;
        public ushort AI, AO;
        public float velSP, vel, posSP, pos, posHome;
    }
    public class DataDAToInverter   //Inverter PLCSIM
    {
        public byte idV3;
        public ushort onOffG120;
        public ushort velSPG120, velG120;
    }
    public class DataInverterToDA   //Inverter PLCSIM
    {
        public byte idV9;
        public ushort velG120;
    }
    public class DataValiIFMToDA
    {
        public byte idV4;
        public short w0UGT, w1UGT, w0IF, w0TW, w1TW, w0RB;
        public bool outKT, outO5C;
    }
    public class DataValiPLCToDA
    {
        public byte idV5;
        public byte DI;
        public ushort AI;
        public bool LS1;
        public bool LS2;
        //Stepper Motor
    }
    public class DataSetSPValiPLCToDA
    {
        public byte idV6;
        public float siPosSP, siVelSP;
    }
    public class DataSetSPInverter
    {
        public byte idV7;
        public ushort siVelSetSPG120;

    }
    public class DataSetOnOffInverter
    {
        public byte idV8;
        public ushort siOnOffSetG120;
    }

    //----------------------------------------------------------------------
    public class DataValueDAToRValiIFM  //RValiIFM: AR cho các các mã QR của ValiIFM thật 
    {
        public byte idR1;
        public ushort w0UGT;
        public ushort w1UGT;
        public ushort w0IF;
        public float disIF;
        public ushort w0TW;
        public ushort w1TW;
        public float temTW;
        public ushort w0RB;
        public float angleRB;
        public byte byte65;
        public byte byte67;
        public byte byte68;
    }
    public class DataConfParaDAToRValiIFM
    {
        public byte idR2;
        public ushort SP1SSC1UGT;
        public ushort SP2SSC1UGT;
        public ushort SP1SSC2UGT;
        public ushort SP2SSC2UGT;
        public ushort SP1SSC1IF;
        public ushort SP2SSC1IF;
        public ushort SP1SSC2IF;
        public ushort SP2SSC2IF;
        public ushort SP1TW2000;
        public ushort rP1TW2000;
        public ushort rSLTRB3100;
        public byte cDirRB3100 = 2;
        public byte OUT_ENCRB = 2;
    }
    public class DataDAToRValiPLC
    {
        public byte idR3;
        public byte DI, DO;
        public ushort AI, AO;
        public float velSP, vel, posSP, pos, velEnc, posEnc;
        public bool LS1, LS2;
    }
    public class DataDAToRInverter          
    {
        public byte idR4;
        public ushort onOffG120;
        public ushort velSPG120, velG120;
    }
    public class DataRValiPLCToDA   //QR AR App --> DA --> Real ValiPLC
    {
        public byte idR5;
        public float velSP, posSP;

    }
    public class DataButtonReadConfigValiIFM
    {
        public byte idR6;
        public bool readConfig;
    }
    public class DataSetSPRInverter
    {
        public byte idR7;
        public ushort velSetSPG120;
        
    }
    public class DataSetOnOffRInverter
    {
        public byte idR8;
        public ushort onOffSetG120;
    }    
    //


    protected override void Start()
    {
        base.Start();
        startTime = Time.time;

        topicARAppToDA = "ARAppToDA: ID = 0";
        topicDAtoARApp = "DAToARApp: ID = 0";

        addressIF.text = "40.76.54.39";
        portIF.text = "1883";
        usernameIF.text = "mqtt2";
        passwordIF.text = "passwordmqtt2";

    }

    protected override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Connected");
        mqttConnected = true;
        iconConnect.sprite = connectOK;
        notifyConnect.text = "Kết nối thành công!";
        //Luu y cmt dong 313 trong file M2MqttUnityClient de ko bi bao loi khi ko ket noi duoc Broker
    }
    protected override void OnDisconnected()
    {
        base.OnDisconnected();
        mqttConnected = false;
        iconConnect.sprite = connectError;
        notifyConnect.text = "Kết nối không thành công! Bạn vui lòng kiểm tra lại!";
    }
    protected override void Update()
    {
        base.Update(); // Dang sua dong 236 file M2MqttUnityClient.cs --> Them try catch

        
        //jsonPublish = JsonUtility.ToJson(DataValiIFMToDAObj, true);
        //UpdateDataDAtoValiIFM();
        

        t = Time.time - startTime;
        if (t >= 0.1f)
        {
            if (mqttConnected)
            {
                if (global_variables.onMCB)
                {
                    UpdateDataValiIFMToDA();
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                }    
                if (global_variables.onMCBPLC)
                {
                    UpdateDataValiPLCToDA();
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                }   
                else
                {
                    UpdateDataValiPLCToDA_MCBOff();
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                }
                if ((readConfig == 1) || (readConfig == 2))
                {
                    
                    if (readConfig == 1)
                    {
                        DataButtonReadConfigValiIFMObj.readConfig = true;
                        jsonPublish = JsonUtility.ToJson(DataButtonReadConfigValiIFMObj, true);
                        client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

                    }
                    else if (readConfig == 2)
                    {
                        DataButtonReadConfigValiIFMObj.readConfig = false;
                        jsonPublish = JsonUtility.ToJson(DataButtonReadConfigValiIFMObj, true);
                        client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    }
                    readConfig = readConfig + 1;    
                }
                else readConfig = 0;


                if (global_variables.onMCBPLC && pubSimulateSP == true)
                {
                    jsonPublish = JsonUtility.ToJson(DataSetSPValiPLCToDAObj, true);
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    pubSimulateSP = false;
                }    
                if (pubRealSP == true)
                {
                    jsonPublish = JsonUtility.ToJson(DataRValiPLCToDAObj, true);
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    pubRealSP = false;
                }    
                if (pubRealSPG120 == true)
                {
                    jsonPublish = JsonUtility.ToJson(DataSetSPRInverterObj, true);
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    pubRealSPG120 = false;
                }    
                if (pubRealOnOffG120 == true)
                {
                    jsonPublish = JsonUtility.ToJson(DataSetOnOffRInverterObj, true);
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    pubRealOnOffG120 = false;
                }
                //Chua co dk MCB ON
                if (true)
                {
                    UpdateDataInverterToDAObj();
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                }    
                
                //
                if (pubSPG120 == true)
                {
                    jsonPublish = JsonUtility.ToJson(DataSetSPInverterObj, true);
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    pubSPG120 = false;
                }
                if (pubOnOffG120 == true)
                {
                    jsonPublish = JsonUtility.ToJson(DataSetOnOffInverterObj, true);
                    client.Publish(topicARAppToDA, System.Text.Encoding.UTF8.GetBytes(jsonPublish), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    pubOnOffG120 = false;
                }


            }
            startTime = Time.time;
        }


    }

    ////Subscribe Topic + Decode
    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { topicDAtoARApp }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
    }

    protected override void DecodeMessage(string topic, byte[] message)
    {
        if (message != null)
        {
            jsonDataReceive = System.Text.Encoding.UTF8.GetString(message);
        }    
        if (global_variables.onMCBPLC)
        {
            if (jsonDataReceive.Contains("idV1"))
            {
                DataDAToValiIFMObj = JsonUtility.FromJson<DataDAToValiIFM>(jsonDataReceive);
                UpdateDataDAtoValiIFMObj();
            }
            else if (jsonDataReceive.Contains("idV2"))
            {
                DataDAToValiPLCObj = JsonUtility.FromJson<DataDAToValiPLC>(jsonDataReceive);
                UpdateDataDAtoValiPLCObj();
            }
        }
        //INVERTER PLCSIM
        if (jsonDataReceive.Contains("idV3"))
        {
            DataDAToInverterObj = JsonUtility.FromJson<DataDAToInverter>(jsonDataReceive);
            UpdateDataDAToInverterObj();
        }    

        if (jsonDataReceive.Contains("idR1"))
        {
            DataValueDAToRValiIFMObj = JsonUtility.FromJson<DataValueDAToRValiIFM>(jsonDataReceive);
            UpdateDataValueDAToRValiIFMObj();
        }
        else if (jsonDataReceive.Contains("idR2"))
        {
            DataConfParaDAToRValiIFMObj = JsonUtility.FromJson<DataConfParaDAToRValiIFM>(jsonDataReceive);
            UpdateDataConfParaDAToRValiIFMObj();
        }
        else if (jsonDataReceive.Contains("idR3"))
        {
            DataDAToRValiPLCObj = JsonUtility.FromJson<DataDAToRValiPLC>(jsonDataReceive);
            UpdateDataDAToRValiPLCObj();
        }
        else if (jsonDataReceive.Contains("idR4"))
        {
            DataDAToRInverterObj = JsonUtility.FromJson<DataDAToRInverter>(jsonDataReceive);
            UpdateDataDAToRInverter();
        }    

    }


    //Function 
    void UpdateDataValiIFMToDA()
    {
        //UGT524  --> Co lien ket cac bien out trong file update_value_config_valiifm
        DataValiIFMToDAObj.w0UGT = global_variables.sensorPositionUGT524;
        DataValiIFMToDAObj.w1UGT =  (short)(global_variables.out1UGT | global_variables.out2UGT);

        DataValiIFMToDAObj.w0IF = (short)((global_variables.sensorValueIF6123 << 2)|(global_variables.out1IF | global_variables.out2IF));

        DataValiIFMToDAObj.w0TW = global_variables.sensorValueTW2000;
        DataValiIFMToDAObj.w1TW = global_variables.outTW;

        DataValiIFMToDAObj.w0RB = global_variables.pulseRB3100;

        DataValiIFMToDAObj.outO5C = global_variables.sensorO5C500;
        DataValiIFMToDAObj.outKT = global_variables.clickKT5112;

        jsonPublish = JsonUtility.ToJson(DataValiIFMToDAObj, true);
    }

    void UpdateDataValiPLCToDA()
    {
        DataValiPLCToDAObj.DI = global_variables.DI;
        DataValiPLCToDAObj.AI = global_variables.AI;
        DataValiPLCToDAObj.LS1 = global_variables.LS1;
        DataValiPLCToDAObj.LS2 = global_variables.LS2;
        jsonPublish = JsonUtility.ToJson(DataValiPLCToDAObj, true);
    }    

    void UpdateDataValiPLCToDA_MCBOff()
    {
        DataValiPLCToDAObj.DI = 0;
        DataValiPLCToDAObj.AI = 0;

        jsonPublish = JsonUtility.ToJson(DataValiPLCToDAObj, true);
    }    
    // 
    void UpdateDataDAtoValiIFMObj()
    {
        global_variables.SP1SSC1UGT = DataDAToValiIFMObj.SP1SSC1UGT;
        global_variables.SP2SSC1UGT = DataDAToValiIFMObj.SP2SSC1UGT;
        global_variables.SP1SSC2UGT = DataDAToValiIFMObj.SP1SSC2UGT;
        global_variables.SP2SSC2UGT = DataDAToValiIFMObj.SP2SSC2UGT;

        global_variables.SP1SSC1IF = DataDAToValiIFMObj.SP1SSC1IF;
        global_variables.SP2SSC1IF = DataDAToValiIFMObj.SP2SSC1IF;
        global_variables.SP1SSC2IF = DataDAToValiIFMObj.SP1SSC2IF;
        global_variables.SP2SSC2IF = DataDAToValiIFMObj.SP2SSC2IF;

        global_variables.SP1TW2000 = DataDAToValiIFMObj.SP1TW2000;
        global_variables.rP1TW2000 = DataDAToValiIFMObj.rP1TW2000;

        global_variables.rSLTRB3100 = DataDAToValiIFMObj.rSLTRB3100;
        global_variables.cDirRB3100 = DataDAToValiIFMObj.cDirRB3100;
        global_variables.OUTENCRB3100 = DataDAToValiIFMObj.OUT_ENCRB;

        global_variables.disUGT = DataDAToValiIFMObj.disUGT;
        global_variables.disIF = DataDAToValiIFMObj.disIF;
        global_variables.temTW = DataDAToValiIFMObj.temTW;
        global_variables.angleRB = DataDAToValiIFMObj.angleRB;
        global_variables.byte65 = DataDAToValiIFMObj.byte65;
        global_variables.byte67 = DataDAToValiIFMObj.byte67;
    }
                
    void UpdateDataDAtoValiPLCObj()
    {
        global_variables.DO = DataDAToValiPLCObj.DO;
        global_variables.AO = DataDAToValiPLCObj.AO;
        global_variables.velSP = DataDAToValiPLCObj.velSP;
        global_variables.vel = DataDAToValiPLCObj.vel;
        //
        global_variables.posSP = DataDAToValiPLCObj.posSP;
        global_variables.pos = DataDAToValiPLCObj.pos;
        global_variables.posHome = DataDAToValiPLCObj.posHome;
        global_variables.posTotal = global_variables.posHome + global_variables.pos;
    }    

    void UpdateDataValueDAToRValiIFMObj()
    {
        global_variables.realW0UGT = DataValueDAToRValiIFMObj.w0UGT;
        global_variables.realW1UGT = DataValueDAToRValiIFMObj.w1UGT;
        global_variables.realW0IF = DataValueDAToRValiIFMObj.w0IF;
        global_variables.realDisIF = DataValueDAToRValiIFMObj.disIF;
        global_variables.realW0TW = DataValueDAToRValiIFMObj.w0TW;
        global_variables.realW1TW = DataValueDAToRValiIFMObj.w1TW;
        global_variables.realTemTW = DataValueDAToRValiIFMObj.temTW;
        global_variables.realW0RB = DataValueDAToRValiIFMObj.w0RB;
        global_variables.realAngleRB = DataValueDAToRValiIFMObj.angleRB;
        global_variables.realByte65 = DataValueDAToRValiIFMObj.byte65;
        global_variables.realByte67 = DataValueDAToRValiIFMObj.byte67;
        global_variables.realByte68 = DataValueDAToRValiIFMObj.byte68;

    }    

    void UpdateDataConfParaDAToRValiIFMObj()
    {
        global_variables.realSP1SSC1UGT = DataConfParaDAToRValiIFMObj.SP1SSC1UGT;
        global_variables.realSP2SSC1UGT = DataConfParaDAToRValiIFMObj.SP2SSC1UGT;
        global_variables.realSP1SSC2UGT = DataConfParaDAToRValiIFMObj.SP1SSC2UGT;
        global_variables.realSP2SSC2UGT = DataConfParaDAToRValiIFMObj.SP2SSC2UGT;

        global_variables.realSP1SSC1IF = DataConfParaDAToRValiIFMObj.SP1SSC1IF;
        global_variables.realSP2SSC1IF = DataConfParaDAToRValiIFMObj.SP2SSC1IF;
        global_variables.realSP1SSC2IF = DataConfParaDAToRValiIFMObj.SP1SSC2IF;
        global_variables.realSP2SSC2IF = DataConfParaDAToRValiIFMObj.SP2SSC2IF;

        global_variables.realSP1TW2000 = DataConfParaDAToRValiIFMObj.SP1TW2000;
        global_variables.realrP1TW2000 = DataConfParaDAToRValiIFMObj.rP1TW2000;

        global_variables.realrSLTRB3100 = DataConfParaDAToRValiIFMObj.rSLTRB3100;
        global_variables.realcDirRB3100 = DataConfParaDAToRValiIFMObj.cDirRB3100;
        global_variables.realOUTENCRB3100 = DataConfParaDAToRValiIFMObj.OUT_ENCRB;
        Debug.Log("resolution ==========" + global_variables.rSLTRB3100.ToString());
    }

    void UpdateDataDAToRValiPLCObj()
    {
        global_variables.realDI = DataDAToRValiPLCObj.DI;
        global_variables.realDO = DataDAToRValiPLCObj.DO;
        global_variables.realAI = DataDAToRValiPLCObj.AI;
        global_variables.realAO = DataDAToRValiPLCObj.AO;
        global_variables.realVelSP = DataDAToRValiPLCObj.velSP;
        global_variables.realVel = DataDAToRValiPLCObj.vel;
        global_variables.realPosSP = DataDAToRValiPLCObj.posSP;
        global_variables.realPos = DataDAToRValiPLCObj.pos;
        global_variables.realVelEnc = DataDAToRValiPLCObj.velEnc;
        global_variables.realPosEnc = DataDAToRValiPLCObj.posEnc;
        global_variables.realLS1 = DataDAToRValiPLCObj.LS1;
        global_variables.realLS2 = DataDAToRValiPLCObj.LS2;
    }    

    void UpdateDataDAToRInverter()
    {
        global_variables.realOnOffG120 = DataDAToRInverterObj.onOffG120;
        global_variables.realVelSPG120 = DataDAToRInverterObj.velSPG120;
        global_variables.realVelG120 = DataDAToRInverterObj.velG120;

    }   
    
    void UpdateDataDAToInverterObj()
    {
        global_variables.onOffG120 = DataDAToInverterObj.onOffG120;
        global_variables.velSPG120 = DataDAToInverterObj.velSPG120;
        global_variables.velG120 = DataDAToInverterObj.velG120;

    }    
    //
    void UpdateDataInverterToDAObj()
    {
        DataInverterToDAObj.velG120 = global_variables.velWriteG120;
        jsonPublish = JsonUtility.ToJson(DataInverterToDAObj, true);
    }    

    public void SetRealPosVelSP()
    {
        
        DataRValiPLCToDAObj.posSP = global_variables.realSetPosSP;
        DataRValiPLCToDAObj.velSP = global_variables.realSetVelSP;
        pubRealSP = true;
        
    }

    public void SetSimulatePosVelSP()
    {
        DataSetSPValiPLCToDAObj.siPosSP = global_variables.simulateSetPosSP;
        DataSetSPValiPLCToDAObj.siVelSP = global_variables.simulateSetVelSP;
        pubSimulateSP = true;
    }    

    public void SetRealVelSPG120()
    {
        DataSetSPRInverterObj.velSetSPG120 = global_variables.realSetVelSPG120;
        pubRealSPG120 = true;
    }    


    public void SetRealOnG120()
    {
        global_variables.realSetOnOffG120 = 1151;
        DataSetOnOffRInverterObj.onOffSetG120 = global_variables.realSetOnOffG120;
        pubRealOnOffG120 = true;
    }
    public void SetRealOffG120()
    {
        global_variables.realSetOnOffG120 = 1150;
        DataSetOnOffRInverterObj.onOffSetG120 = global_variables.realSetOnOffG120;
        pubRealOnOffG120 = true;
    }
    ////
    public void SetSimulateVelSPG120()
    {
        DataSetSPInverterObj.siVelSetSPG120 = global_variables.setVelSPG120;
        pubSPG120 = true;
    }


    public void SetSimulateOnG120()
    {
        global_variables.setOnOffG120 = 1151;
        DataSetOnOffInverterObj.siOnOffSetG120 = global_variables.setOnOffG120;
        pubOnOffG120 = true;
    }
    public void SetSimulateOffG120()
    {
        global_variables.setOnOffG120 = 1150;
        DataSetOnOffInverterObj.siOnOffSetG120 = global_variables.setOnOffG120;
        pubOnOffG120 = true;
    }


    public void ReadConfigIFM()
    {
        readConfig = 1;
    }    

    public void SubmitID()
    {
        topicARAppToDA = "ARAppToDA: ID = " + inputFieldID.text;
        topicDAtoARApp = "DAToARApp: ID = " + inputFieldID.text;
        Debug.Log(topicARAppToDA);
        SubscribeTopics();
    }

    public void ConnectMQTT()
    {
        if (flagConnect == true)
        {
            txtBtnConnect.text = "KẾT NỐI";
            flagConnect = false;
            Disconnect();
            
        }    
        else
        {
            txtBtnConnect.text = "HỦY";
            this.brokerAddress = addressIF.text;
            this.brokerPort = int.Parse(portIF.text);
            this.mqttUserName = usernameIF.text;
            this.mqttPassword = passwordIF.text;
            flagConnect = true;
            Connect();
            //Debug.Log("Address Broker: " + this.brokerAddress);
            //Debug.Log("Port: " + this.brokerPort);
            //Debug.Log("Username: " + this.mqttUserName);
            //Debug.Log("Password: " + this.mqttPassword);
        }    
    }    
}
