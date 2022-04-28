using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Object : MonoBehaviour
{
    public GameObject gameObjectPLCMaster, gameObjectPLCSlave, gameObjectHMI;
    public GameObject gameObjectEncoder, gameObjectStepperMotor, gameObjectStepperMotorDriver, gameObjectPanelSwitch, gameObjectMCB, gameObjectScalance;

    bool showMCB, showHMI, showScalance, showPanelSwitch, showEncoder;
    bool showPLCMaster, showPLCSlave, showStepperMotorDriver, showStepperMotor;


    // Start is called before the first frame update
    void Start()
    {
        gameObjectEncoder.SetActive(false);
        gameObjectHMI.SetActive(false);
        gameObjectMCB.SetActive(false);
        gameObjectPanelSwitch.SetActive(false);
        gameObjectPLCMaster.SetActive(false);
        gameObjectPLCSlave.SetActive(false);
        gameObjectScalance.SetActive(false);
        gameObjectStepperMotor.SetActive(false);
        gameObjectStepperMotorDriver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("MCB")))
            {
                ShowPanel(ref showMCB, gameObjectMCB);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("HMI"))
            {
                ShowPanel(ref showHMI, gameObjectHMI);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Scalance"))
            {
                ShowPanel(ref showScalance, gameObjectScalance);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Panel_Switch"))
            {
                ShowPanel(ref showPanelSwitch, gameObjectPanelSwitch);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Encoder"))
            {
                ShowPanel(ref showEncoder, gameObjectEncoder);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("PLC_Master"))
            {
                ShowPanel(ref showPLCMaster, gameObjectPLCMaster);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("PLC_Slave"))
            {
                ShowPanel(ref showPLCSlave, gameObjectPLCSlave);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Stepper_Motor"))
            {
                ShowPanel(ref showStepperMotor, gameObjectStepperMotor);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Stepper_Motor_Driver"))
            {
                ShowPanel(ref showStepperMotorDriver, gameObjectStepperMotorDriver);
            }
        }
    }

    private void ShowPanel(ref bool showPanel, GameObject gameObjectPanel)
    {
        if (showPanel == false)
        {
            gameObjectPanel.SetActive(true);
            showPanel = true;
        }
        else
        {
            gameObjectPanel.SetActive(false);
            showPanel = false;
        }
    }
}


