using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using System;
using TMPro;
[Serializable]

public class mqtt_script : M2MqttUnity.M2MqttUnityClient
{
    string msg_pub;
    float StartTime, t;
    bool MQTTConnected;


    
    
    
    protected override void Start()
    {
        base.Start();
        StartTime = Time.time;
    }
    protected override void Update()
    {
        base.Update();

        
        

        


        t = Time.time - StartTime;
        if (t >= 0.1f)
        {
            //msg_pub = Global_variable.Pos_UGT524.ToString();
            if (MQTTConnected)
            {
                //client.Publish("ARAPP_VPS", System.Text.Encoding.UTF8.GetBytes(msg_pub), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
            }

            StartTime = Time.time;

        }
    }
    protected override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Connected");
        MQTTConnected = true;
        //Luu y cmt dong 313 trong file M2MqttUnityClient de ko bi bao loi khi ko ket noi duoc Broker

    }
    protected override void OnDisconnected()
    {
        base.OnDisconnected();
        MQTTConnected = false;
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
