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
    //
    public DataValiIFMToDA DataValiIFMToDAObj = new DataValiIFMToDA();
    public DataValiPLCToDA DataValiPLCToDAObj = new DataValiPLCToDA();

    public DataValueDAToRValiIFM DataValueDAToRValiIFMObj = new DataValueDAToRValiIFM();
    public DataConfParaDAToRValiIFM DataConfParaDAToRValiIFMObj = new DataConfParaDAToRValiIFM();
    //
    public DataDAToRValiPLC DataDAToRValiPLCObj = new DataDAToRValiPLC();
    public DataRValiPLCToDA DataRValiPLCToDAObj = new DataRValiPLCToDA();


    float startTime, t;
    bool mqttConnected, flagConnect = true;
    string topicARAppToDA, topicDAtoARApp;
    string jsonDataReceive, jsonPublish;

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
        //public float velSP, vel, posSP, pos;
    }
    //
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
        //Stepper Motor
    }
    //
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
        public float velSP, vel, posSP, pos;
        public bool LS1, LS2;
    }
    //
    public class DataRValiPLCToDA
    {
        public byte idR5;
        //public float velSP = 0, vel = 0, posSP = 0, pos = 0;

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
        base.Update();

        
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
        //DataDAToValiIFMObj = JsonUtility.FromJson<DataDAToValiIFM>(jsonDataReceive);
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
    }


    //Function 
    public void UpdateDataValiIFMToDA()
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

    public void UpdateDataValiPLCToDA()
    {
        DataValiPLCToDAObj.DI = global_variables.DI;
        DataValiPLCToDAObj.AI = global_variables.AI;

        jsonPublish = JsonUtility.ToJson(DataValiPLCToDAObj, true);
    }    
    public void UpdateDataValiPLCToDA_MCBOff()
    {
        DataValiPLCToDAObj.DI = 0;
        DataValiPLCToDAObj.AI = 0;

        jsonPublish = JsonUtility.ToJson(DataValiPLCToDAObj, true);
    }    
    // 
    public void UpdateDataDAtoValiIFMObj()
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
                
    public void UpdateDataDAtoValiPLCObj()
    {
        global_variables.DO = DataDAToValiPLCObj.DO;
        global_variables.AO = DataDAToValiPLCObj.AO;
    }    

    public void UpdateDataValueDAToRValiIFMObj()
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

    public void UpdateDataConfParaDAToRValiIFMObj()
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

    public void UpdateDataDAToRValiPLCObj()
    {
        global_variables.realDI = DataDAToRValiPLCObj.DI;
        global_variables.realDO = DataDAToRValiPLCObj.DO;
        global_variables.realAI = DataDAToRValiPLCObj.AI;
        global_variables.realAO = DataDAToRValiPLCObj.AO;
        global_variables.realVelSP = DataDAToRValiPLCObj.velSP;
        global_variables.realVel = DataDAToRValiPLCObj.vel;
        global_variables.realPosSP = DataDAToRValiPLCObj.posSP;
        global_variables.realPos = DataDAToRValiPLCObj.pos;
        global_variables.realLS1 = DataDAToRValiPLCObj.LS1;
        global_variables.realLS2 = DataDAToRValiPLCObj.LS2;
        //Debug.Log(global_variables.realAI);
        //Debug.Log(global_variables.realAO);
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
            Debug.Log("Address Broker: " + this.brokerAddress);
            Debug.Log("Port: " + this.brokerPort);
            Debug.Log("Username: " + this.mqttUserName);
            Debug.Log("Password: " + this.mqttPassword);
        }    
    }    
}
