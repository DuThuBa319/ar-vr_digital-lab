using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_gameobject_qr : MonoBehaviour
{
    public GameObject panelUGT, panelIF, panelRB, panelTW, panelO5C, panelKT, panelAL1102, panelAL2401, panelAL2330;
    public GameObject panelDN4012, panelRS775, panelLight, panelMCB;
    // Start is called before the first frame update
    void Start()
    {
        panelUGT.gameObject.SetActive(true);
        panelIF.gameObject.SetActive(true);
        panelRB.gameObject.SetActive(true);
        panelTW.gameObject.SetActive(true);
        panelO5C.gameObject.SetActive(true);
        panelKT.gameObject.SetActive(true);
        panelAL1102.gameObject.SetActive(true);
        panelAL2401.gameObject.SetActive(true);
        panelAL2330.gameObject.SetActive(true);
        panelDN4012.gameObject.SetActive(true);
        panelRS775.gameObject.SetActive(true);
        panelLight.gameObject.SetActive(true);
        panelMCB.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
