using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class test_json : MonoBehaviour
{
    public DataPublishARAppToDA DataPub = new DataPublishARAppToDA();
    // Start is called before the first frame update
    void Start()
    {
         

        
    }

    // Update is called once per frame
    void Update()
    {
        //string json = JsonUtility.ToJson(cus);
        string json = JsonUtility.ToJson(DataPub, true);
        Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbb");
        Debug.Log("aaaaaaaaaaaaaaa" + json);

        UpdateData();


    }


    public class DataPublishARAppToDA
    {
        public float valUGT524;
        public float valIF6123;

    }

    public void UpdateData()
    {
        DataPub.valUGT524 = global_variables.sensorPositionUGT524;
        DataPub.valIF6123 = global_variables.sensorValueIF6123;
    }    
}


