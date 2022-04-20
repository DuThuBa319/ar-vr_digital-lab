using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_sensor : MonoBehaviour
{
    public GameObject gameObjectUGT524, gameObjectIF6123, gameObjectRB3100, gameObjectTW2000, gameObjectO5C500, gameObjectKT5112;
    public GameObject gameObjectAL1102, gameObjectAL2401, gameObjectAL2330, gameObjectDN4012;
    public GameObject gameObjectRS775, gameObjectLight, gameObjectCB, gameObjectRelay, gameObjectToggleSwitch;

    bool showUGT524, showIF6123, showRB3100, showTW2000, showO5C500, showKT5112;
    bool showAL1102, showAL2401, showAL2330, showDN4012;
    bool showRS775, showLight, showCB, showRelay, showToggleSwitch;

    bool startTimerKT5112, startTimerCB, startTimerToggleSwitch;
    float timerKT5112CV, timerCBCV, timerToggleSwitchCV, timerClickKT5112;
    int countClickKT5112, countClickCB, countClickToggleSwitch;

    Vector3 vector3Position1O5C500 = new Vector3(-21.3f, 2.7f, 2.6f);
    Vector3 vector3Position2O5C500 = new Vector3(-21.6f, 3.3f, 7.44f);
    // Start is called before the first frame update
    void Start()
    {
        gameObjectUGT524.gameObject.SetActive(false);
        gameObjectIF6123.gameObject.SetActive(false);
        gameObjectRB3100.gameObject.SetActive(false);
        gameObjectTW2000.gameObject.SetActive(false);
        gameObjectO5C500.gameObject.SetActive(false);
        gameObjectKT5112.gameObject.SetActive(false);

        gameObjectAL1102.gameObject.SetActive(false);
        gameObjectAL2401.gameObject.SetActive(false);
        gameObjectAL2330.gameObject.SetActive(false);
        gameObjectDN4012.gameObject.SetActive(false);

        gameObjectRS775.gameObject.SetActive(false);
        gameObjectLight.gameObject.SetActive(false);
        gameObjectCB.gameObject.SetActive(false);
        gameObjectRelay.gameObject.SetActive(false);
        gameObjectToggleSwitch.gameObject.SetActive(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        # region KT5112
        if (startTimerKT5112)
        {
            timerKT5112CV += Time.deltaTime;
        }

        if (timerKT5112CV >= 0.3f)
        {
            if (countClickKT5112 == 1)
            {
                //Press KT5112
                global_variables.clickKT5112 = true;
            }
            else if (countClickKT5112 >= 2)
            {
                ShowPanel(ref showKT5112, gameObjectKT5112);
            }

            startTimerKT5112 = false;
            timerKT5112CV = 0;
            countClickKT5112 = 0;
        }

        if (global_variables.clickKT5112 == true)
        {

            timerClickKT5112 += Time.deltaTime;
            if (timerClickKT5112 >= 0.7f)
            {
                global_variables.clickKT5112 = false;
                timerClickKT5112 = 0;
            }
        }    
        

        #endregion

       /* #region CB 
        if (startTimerCB)
        {
            timerCBCV += Time.deltaTime;
        }

        if (timerCBCV >= 0.3f)
        {
            if (countClickCB == 1)
            {
                //Press CB
            }
            else if (countClickCB >= 2)
            {
                ShowPanel(ref showCB, gameObjectCB);
            }

            startTimerCB = false;
            timerCBCV = 0;
            countClickCB = 0;
        } 
        #endregion */

        #region ToggleSwitch
        if (startTimerToggleSwitch)
        {
            timerToggleSwitchCV += Time.deltaTime;
        }

        if (timerToggleSwitchCV >= 0.3f)
        {
            if (countClickToggleSwitch == 1)
            {
                //Press ToggleSwitch
            }
            else if (countClickToggleSwitch >= 2)
            {
                ShowPanel(ref showToggleSwitch, gameObjectToggleSwitch);
            }

            startTimerToggleSwitch = false;
            timerToggleSwitchCV = 0;
            countClickToggleSwitch = 0;
        }
        #endregion ToggleSwitch

        if (global_variables.clickDataO5C500 == true)
        {
            gameObjectO5C500.transform.localPosition = vector3Position2O5C500;
        }
        else
        {
            gameObjectO5C500.transform.localPosition = vector3Position1O5C500;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "UGT524")
            {
                ShowPanel(ref showUGT524, gameObjectUGT524);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "IF6123")
            {
                ShowPanel(ref showIF6123, gameObjectIF6123);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "RB3100")
            {
                ShowPanel(ref showRB3100, gameObjectRB3100);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "TW2000")
            {
                ShowPanel(ref showTW2000, gameObjectTW2000);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "O5C500")
            {
                ShowPanel(ref showO5C500, gameObjectO5C500);
                global_variables.clickGameObjectO5C500 = !global_variables.clickGameObjectO5C500;
                
               
            }
            
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "KT5112")
            {
                startTimerKT5112 = true;
                countClickKT5112++;
            }


            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "AL1102")
            {
                ShowPanel(ref showAL1102, gameObjectAL1102) ;
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "AL2401")
            {
                ShowPanel(ref showAL2401, gameObjectAL2401);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "AL2330")
            {
                ShowPanel(ref showAL2330, gameObjectAL2330);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "DN4012")
            {
                ShowPanel(ref showDN4012, gameObjectDN4012);
            }


            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "RS775")
            {
                ShowPanel(ref showRS775, gameObjectRS775);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Light")
            {
                ShowPanel(ref showLight, gameObjectLight);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "CB")
            {
                //startTimerCB = true;
                //countClickCB++;
                ShowPanel(ref showCB, gameObjectCB);
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ToggleSwitch")
            {
                startTimerToggleSwitch = true;
                countClickToggleSwitch++;
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Relay")
            {
                ShowPanel(ref showRelay, gameObjectRelay);
            }
        }
    }
    private void ShowPanel(ref bool showPanel, GameObject gameObjectPanel)
    {
        if (showPanel == false)
        {
            gameObjectPanel.gameObject.SetActive(true);
            showPanel = true;
        }
        else
        {
            gameObjectPanel.gameObject.SetActive(false);
            showPanel = false;
        }
    }    

    #region Temp
    /*
    private void ShowPanelUGT524()
    {
        if (showUGT524 == false)
        {
            gameObjectUGT524.gameObject.SetActive(true);
            showUGT524 = true;
        } 
        else
        {
            gameObjectUGT524.gameObject.SetActive(false);
            showUGT524 = false;
        }   
    }

    private void ShowPanelIF6123()
    {
        if (showIF6123 == false)
        {
            gameObjectIF6123.gameObject.SetActive(true);
            showIF6123 = true;
        }
        else
        {
            gameObjectIF6123.gameObject.SetActive(false);
            showIF6123 = false;
        }
    }

    private void ShowPanelRB3100()
    {
        if (showRB3100 == false)
        {
            gameObjectRB3100.gameObject.SetActive(true);
            showRB3100 = true;
        }
        else
        {
            gameObjectRB3100.gameObject.SetActive(false);
            showRB3100 = false;
        }
    }

    private void ShowPanelTW2000()
    {
        if (showTW2000 == false)
        {
            gameObjectTW2000.gameObject.SetActive(true);
            showTW2000 = true;
        }
        else
        {
            gameObjectTW2000.gameObject.SetActive(false);
            showTW2000 = false;
        }
    }

    private void ShowPanelO5C500()
    {
        if (showO5C500 == false)
        {
            gameObjectO5C500.gameObject.SetActive(true);
            showO5C500 = true;
        }
        else
        {
            gameObjectO5C500.gameObject.SetActive(false);
            showO5C500 = false;
        }
    }

    private void ShowPanelKT5112()
    {
        if (showKT5112 == false)
        {
            gameObjectKT5112.gameObject.SetActive(true);
            showKT5112 = true;
        }
        else
        {
            gameObjectKT5112.gameObject.SetActive(false);
            showKT5112 = false;
        }
    }

    private void ShowPanelAL1102()
    {
        if (showAL1102 == false)
        {
            gameObjectAL1102.gameObject.SetActive(true);
            showAL1102 = true;
        }
        else
        {
            gameObjectAL1102.gameObject.SetActive(false);
            showAL1102 = false;
        }
    }

    private void ShowPanelAL2401()
    {
        if (showAL2401 == false)
        {
            gameObjectAL2401.gameObject.SetActive(true);
            showAL2401 = true;
        }
        else
        {
            gameObjectAL2401.gameObject.SetActive(false);
            showAL2401 = false;
        }
    }

    private void ShowPanelAL2330()
    {
        if (showAL2330 == false)
        {
            gameObjectAL2330.gameObject.SetActive(true);
            showAL2330 = true;
        }
        else
        {
            gameObjectAL2330.gameObject.SetActive(false);
            showAL2330 = false;
        }
    }

    private void ShowPanelRS775()
    {
        if (showRS775 == false)
        {
            gameObjectRS775.gameObject.SetActive(true);
            showRS775 = true;
        }
        else
        {
            gameObjectRS775.gameObject.SetActive(false);
            showRS775 = false;
        }
    }

    private void ShowPanelLight()
    {
        if (showLight == false)
        {
            gameObjectLight.gameObject.SetActive(true);
            showLight = true;
        }
        else
        {
            gameObjectLight.gameObject.SetActive(false);
            showLight = false;
        }
    }

    private void ShowPanelDN4012()
    {
        if (showDN4012 == false)
        {
            gameObjectDN4012.gameObject.SetActive(true);
            showDN4012 = true;
        }
        else
        {
            gameObjectDN4012.gameObject.SetActive(false);
            showDN4012 = false;
        }
    }
    */

    #endregion
}
