using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Control : MonoBehaviour
{
    public GameObject switch0On, switch0Off;
    public GameObject switch1On, switch1Off;
    public GameObject switch2On, switch2Off;
    public GameObject switch3On, switch3Off;
    public GameObject switch4On, switch4Off;
    public GameObject switch5On, switch5Off;
    public GameObject switch6On, switch6Off;
    public GameObject switch7On, switch7Off;
    public Renderer rendererSwitch0, rendererSwitch1, rendererSwitch2, rendererSwitch3, rendererSwitch4, rendererSwitch5, rendererSwitch6, rendererSwitch7;
    public Material materialSwitchOn, materialSwitchOff;
    bool state0On, state1On, state2On, state7On, state3On, state4On, state5On, state6On;
    // Start is called before the first frame update
    void Start()
    {
        SetState(ref state0On, switch0On, switch0Off, rendererSwitch0);

        SetState(ref state1On, switch1On, switch1Off, rendererSwitch1);

        SetState(ref state2On, switch2On, switch2Off, rendererSwitch2);

        SetState(ref state3On, switch3On, switch3Off, rendererSwitch3);

        SetState(ref state4On, switch4On, switch4Off, rendererSwitch4);

        SetState(ref state5On, switch5On, switch5Off, rendererSwitch5);

        SetState(ref state6On, switch6On, switch6Off, rendererSwitch6);

        SetState(ref state7On, switch7On, switch7Off, rendererSwitch7);
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_0")))
            {
                ChangeState(ref state0On, switch0On, switch0Off, rendererSwitch0);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_1")))
            {
                ChangeState(ref state1On, switch1On, switch1Off, rendererSwitch1);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_2")))
            {
                ChangeState(ref state2On, switch2On, switch2Off, rendererSwitch2);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_3")))
            {
                ChangeState(ref state3On, switch3On, switch3Off, rendererSwitch3);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_4")))
            {
                ChangeState(ref state4On, switch4On, switch4Off, rendererSwitch4);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_5")))
            {
                ChangeState(ref state5On, switch5On, switch5Off, rendererSwitch5);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_6")))
            {
                ChangeState(ref state6On, switch6On, switch6Off, rendererSwitch6);
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Switch_7")))
            {
                ChangeState(ref state7On, switch7On, switch7Off, rendererSwitch7);
            }
        }
    }
    void ChangeState(ref bool state, GameObject switchOn, GameObject switchOff, Renderer rendererSwitch)
    {
        if(state == false)
        {
            switchOn.SetActive(true);
            switchOff.SetActive(false);
            rendererSwitch.material = materialSwitchOn;
            state = true;
        }
        else
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);
            rendererSwitch.material = materialSwitchOff;
            state = false;
        }
    }
    void SetState(ref bool state, GameObject switchOn, GameObject switchOff, Renderer rendererSwitch)
    {
        state = false;
        switchOn.SetActive(false);
        switchOff.SetActive(true);
        rendererSwitch.material.color = materialSwitchOff.color;
    }
}
