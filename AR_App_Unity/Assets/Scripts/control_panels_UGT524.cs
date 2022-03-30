using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_panels_UGT524 : MonoBehaviour
{
    public GameObject panelDatasheet, panelDatasheetTemp1, panelDatasheetTemp2, panelMain, panelData, panelWiring;
    // Start is called before the first frame update
    void Start()
    {
        panelMain.gameObject.SetActive(true);
        panelDatasheet.gameObject.SetActive(false);
        panelDatasheetTemp1.gameObject.SetActive(false);
        panelDatasheetTemp2.gameObject.SetActive(false);
        panelData.gameObject.SetActive(false);
        panelWiring.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanelDatasheet()
    {
        panelMain.gameObject.SetActive(false);
        panelDatasheet.gameObject.SetActive(true);
        panelDatasheetTemp1.gameObject.SetActive(true);
    }    

    public void OpenPanelDatasheetDown()
    {
        panelDatasheetTemp1.gameObject.SetActive(false);
        panelDatasheetTemp2.gameObject.SetActive(true);
    }

    public void OpenPanelDatasheetUp()
    {
        panelDatasheetTemp2.gameObject.SetActive(false);
        panelDatasheetTemp1.gameObject.SetActive(true);
    }

    public void OpenPanelData()
    {
        panelMain.gameObject.SetActive(false);
        panelData.gameObject.SetActive(true);
    }    

    public void OpenPanelWiring()
    {
        panelMain.gameObject.SetActive(false);
        panelWiring.gameObject.SetActive(true);
    }    

    public void BackButton()
    {
        panelMain.gameObject.SetActive(true);
        panelDatasheet.gameObject.SetActive(false);
        panelDatasheetTemp1.gameObject.SetActive(false);
        panelDatasheetTemp2.gameObject.SetActive(false);
        panelData.gameObject.SetActive(false);
        panelWiring.gameObject.SetActive(false);
    }    
}
