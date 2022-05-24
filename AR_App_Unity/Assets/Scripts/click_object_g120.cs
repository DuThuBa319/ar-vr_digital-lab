using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_object_g120 : MonoBehaviour
{
    public GameObject gameObjectG120, gameObjectControlBox, gameObjectMotor, gameObjectMCB;
    
    bool showG120, showControlBox, showMotor, showMCB;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectG120.gameObject.SetActive(false);
        gameObjectControlBox.gameObject.SetActive(false);
        gameObjectMotor.gameObject.SetActive(false);
        gameObjectMCB.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("G120")))
            {
                ShowPanel(ref showG120, gameObjectG120);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("ControlBox"))
            {
                ShowPanel(ref showControlBox, gameObjectControlBox);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("MotorG120"))
            {
                ShowPanel(ref showMotor, gameObjectMotor);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("MCBG120"))
            {
                ShowPanel(ref showMotor, gameObjectMCB);
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

