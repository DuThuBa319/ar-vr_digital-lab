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

    string msg_pub;
    float startTime, t;
    bool mqttConnected;
    string topicValiIFMToDA, topicDAtoValiIFM, ID;
    string jsonDAToValiIFM;

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
        UpdateDataDAtoValiIFM();

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
        jsonDAToValiIFM = System.Text.Encoding.UTF8.GetString(message);
        DataDAToValiIFMObj = JsonUtility.FromJson<DataDAToValiIFM>(jsonDAToValiIFM);
    }

    //Class
    public class DataValiIFMToDA
    {
        //public Int16 valUGT = 0, valIF = 0, valTW = 0, valRB = 0;
        //public bool valKT = false, valO5C = false;
        //public bool out1UGT = false, out2UGT = false, out1IF = false, out2IF = false, outTW = false;
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

        //DataValiIFMToDAObj.valUGT = global_variables.sensorPositionUGT524;
        //DataValiIFMToDAObj.valIF = global_variables.sensorValueIF6123;
        //DataValiIFMToDAObj.valRB = global_variables.pulseRB3100;
        //DataValiIFMToDAObj.valTW = global_variables.sensorValueTW2000;
        //DataValiIFMToDAObj.valO5C = global_variables.sensorO5C500;
        //DataValiIFMToDAObj.valKT = global_variables.clickKT5112;

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

    public void SubmitID()
    {
        topicValiIFMToDA = "ValiIFMToDA: ID = " + inputFieldID.text;
        topicDAtoValiIFM = "DAToValiIFM: ID = " + inputFieldID.text;
        Debug.Log(topicValiIFMToDA);
    }

    

    ////Publish Message 
    /* public void PubMQTT_Btn()
     {
         string START_MQTT_String = "[{\"id\":\"PLC_S71200.Light.Start\",\"v\":\"true\"}]";
         client.Publish("tu.pham1814680@hcmut.edu.vn/Test03", System.Text.Encoding.UTF8.GetBytes(START_MQTT_String), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
         START_MQTT_String = "[{\"id\":\"PLC_S71200.Light.Start\",\"v\":\"false\"}]";

         client.Publish("ARAPP_VPS", System.Text.Encoding.UTF8.GetBytes("ARAPP_TO_VPS_STRING"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

         Debug.Log("Publish_Start_Button");

         msg_pub = Global_variable.Pos_UGT524.ToString();
         client.Publish("ARAPP_VPS", System.Text.Encoding.UTF8.GetBytes(msg_pub), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
     }*/




}
