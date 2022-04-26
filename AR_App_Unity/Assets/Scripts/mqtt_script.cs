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
    public TextMeshProUGUI notifyConnect;
    public TMP_InputField inputFieldID;


    DataValiIFMToDA DataValiIFMToDAObj = new DataValiIFMToDA();
    DataDAToValiIFM DataDAToValiIFMObj = new DataDAToValiIFM();
    DataValueDAToRValiIFM DataValueDAToRValiIFMObj = new DataValueDAToRValiIFM();
    DataConfParaDAToRValiIFM DataConfParaDAToRValiIFMObj = new DataConfParaDAToRValiIFM();


    string msg_pub;
    float startTime, t;
    bool mqttConnected;
    string topicValiIFMToDA, topicDAtoValiIFM, ID;
    string jsonDataReceive;

    protected override void Start()
    {
        base.Start();
        startTime = Time.time;

        topicValiIFMToDA = "ValiIFMToDA: ID = 0";
        topicDAtoValiIFM = "DAToValiIFM: ID = 0";
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

        UpdateDataValiIFMToDA();
        string jsonValiIFMPub = JsonUtility.ToJson(DataValiIFMToDAObj, true);
        //UpdateDataDAtoValiIFM();
        

        t = Time.time - startTime;
        if (t >= 0.1f)
        {
            if (mqttConnected)
            {
                client.Publish(topicValiIFMToDA, System.Text.Encoding.UTF8.GetBytes(jsonValiIFMPub), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
            }
            startTime = Time.time;
        }


    }

    ////Subscribe Topic + Decode
    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { topicDAtoValiIFM }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
    }

    protected override void DecodeMessage(string topic, byte[] message)
    {
        jsonDataReceive = System.Text.Encoding.UTF8.GetString(message);
        if (jsonDataReceive.Contains("idV1"))
        {
            DataDAToValiIFMObj = JsonUtility.FromJson<DataDAToValiIFM>(jsonDataReceive);
            UpdateDataDAtoValiIFM();
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
        
    }

    //Class
    public class DataValiIFMToDA
    {
        public short w0UGT, w1UGT, w0IF, w0TW, w1TW, w0RB;
        public bool outKT, outO5C;
    }

    public class DataDAToValiIFM
    {
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

        public ushort disUGT = 0;
        public float disIF = 0;
        public float temTW = 0;
        public float angleRB = 0;
        public byte byte65 = 0, byte67 = 0;
    }    

    public class DataValueDAToRValiIFM
    {
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
        public byte cDirRB3100;
        public byte OUT_ENCRB;
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
    }

    public void UpdateDataDAtoValiIFM()
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

    public void SubmitID()
    {
        topicValiIFMToDA = "ValiIFMToDA: ID = " + inputFieldID.text;
        topicDAtoValiIFM = "DAToValiIFM: ID = " + inputFieldID.text;
        Debug.Log(topicValiIFMToDA);
        SubscribeTopics();
    }


}
