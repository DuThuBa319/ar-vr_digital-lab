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
    //public GameObject inputFieldID;
    public TMP_InputField inputFieldID;


    public DataValiIFMPublish DataValiIFM = new DataValiIFMPublish();

    string msg_pub;
    float startTime, t;
    bool mqttConnected;
    string topicValiIFMPubToDA, ID;

    protected override void Start()
    {
        base.Start();
        startTime = Time.time;

        topicValiIFMPubToDA = "ValiIFMToDA: ID = 0";
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

        UpdateValueValiIFMPub();
        string jsonValiIFMPub = JsonUtility.ToJson(DataValiIFM, true);

        t = Time.time - startTime;
        if (t >= 0.1f)
        {
            if (mqttConnected)
            {
                client.Publish(topicValiIFMPubToDA, System.Text.Encoding.UTF8.GetBytes(jsonValiIFMPub), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
            }
            startTime = Time.time;
        }
    }

    public class DataValiIFMPublish
    {
        public Int16 valUGT = 0, valIF = 0, valTW = 0, valRB = 0;
        public bool valKT = false, valO5C = false;
        public bool out1UGT = false, out2UGT = false, out1IF = false, out2IF = false, outTW = false;
    }

    public void UpdateValueValiIFMPub()
    {
        DataValiIFM.valUGT = global_variables.sensorPositionUGT524;
        DataValiIFM.valIF = global_variables.sensorValueIF6123;
        DataValiIFM.valRB = global_variables.pulseRB3100;
        DataValiIFM.valTW = global_variables.sensorValueTW2000;
        DataValiIFM.valO5C = global_variables.sensorO5C500;
        DataValiIFM.valKT = global_variables.clickKT5112;

    }    
    
    ////Subscribe Topic
    protected override void SubscribeTopics()
    {
        //client.Subscribe(new string[] { "VPS_ARAPP" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

        //client.Subscribe(new string[] { "tu.pham1814680@hcmut.edu.vn/Test02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
    }
    //void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    //{

    //    string msg_receive = System.Text.Encoding.UTF8.GetString(e.Message);
    //    //textBox_Rev.Invoke((MethodInvoker)(() => textBox_Rev.Text = msg_receive));
    //    text1.text = "nhan";
    //}
    protected override void DecodeMessage(string topic, byte[] message)
    {

        //string msg = System.Text.Encoding.UTF8.GetString(message);
        //Debug.Log(msg);
        //Data jsondata = Data.CreateFromJSON(msg);
        string msg_receive = System.Text.Encoding.UTF8.GetString(message);
        //Global_variable.Pos_UGT524_str = msg_receive;
        //string[] msg_split = System.Text.Encoding.UTF8.GetString(message).Split(':');
        //Debug.Log(jsondata1);
        //Debug.Log(jsondata.tagName + ":" + jsondata.tagValue);


    }

    public void SubmitID()
    {
        topicValiIFMPubToDA = "ValiIFMToDA: ID = " + inputFieldID.text;
        Debug.Log(topicValiIFMPubToDA);
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
