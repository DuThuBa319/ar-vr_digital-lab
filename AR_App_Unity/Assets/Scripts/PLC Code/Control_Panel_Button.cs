using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Panel_Button : MonoBehaviour
{
    public GameObject panelDatasheet, panelDatasheetTemp1, panelDatasheetTemp2, panelMain, panelData, panelWiring;

    void Start()
    {
        panelMain.SetActive(true);
        panelDatasheet.SetActive(false);
        panelDatasheetTemp1.SetActive(false);
        panelDatasheetTemp2.SetActive(false);
        panelData.SetActive(false);
        panelWiring.SetActive(false);
    }

    public void OpenPanelDatasheet()
    {
        panelMain.SetActive(false);
        panelDatasheet.SetActive(true);
        panelDatasheetTemp1.SetActive(true);
    }

    public void OpenPanelDatasheetDown()
    {
        panelDatasheetTemp1.SetActive(false);
        panelDatasheetTemp2.SetActive(true);
    }

    public void OpenPanelDatasheetUp()
    {
        panelDatasheetTemp2.SetActive(false);
        panelDatasheetTemp1.SetActive(true);
    }

    public void OpenPanelData()
    {
        panelMain.SetActive(false);
        panelData.SetActive(true);
    }

    public void OpenPanelWiring()
    {
        panelMain.SetActive(false);
        panelWiring.SetActive(true);
    }

    public void BackButton()
    {
        panelMain.SetActive(true);
        panelDatasheet.SetActive(false);
        panelDatasheetTemp1.SetActive(false);
        panelDatasheetTemp2.SetActive(false);
        panelData.SetActive(false);
        panelWiring.SetActive(false);
    }
}


