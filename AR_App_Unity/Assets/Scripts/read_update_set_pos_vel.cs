using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class read_update_set_pos_vel : MonoBehaviour
{

    public Slider realPosSPSlider, realVelSPSlider, simulatePosSPSlider, simulateVelSPSlider;
    public TextMeshProUGUI realPosSPText, realVelSPText, simulatePosSPText, simulateVelSPText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        global_variables.realSetPosSP = (float)Math.Round(realPosSPSlider.value * 100.0f, 2);
        global_variables.realSetVelSP = (float)Math.Round(realVelSPSlider.value * 50.0f, 2);
        realPosSPText.text = (global_variables.realSetPosSP).ToString("0.00") + " mm";
        realVelSPText.text = (global_variables.realSetVelSP).ToString("0.00") + " mm/s";

        global_variables.simulateSetPosSP = (float)Math.Round(simulatePosSPSlider.value * 100.0f,2);
        global_variables.simulateSetVelSP = (float)Math.Round(simulateVelSPSlider.value * 50.0f, 2);
        simulatePosSPText.text = (global_variables.simulateSetPosSP).ToString("0.00") + " mm";
        simulateVelSPText.text = (global_variables.simulateSetVelSP).ToString("0.00") + " mm/s";
    }
}
