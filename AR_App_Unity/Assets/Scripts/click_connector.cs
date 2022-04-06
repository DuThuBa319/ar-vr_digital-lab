using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_connector : MonoBehaviour
{
    public Material glowMaterial, orangeIFM, metal, blackConnector, blackLight;
    public Renderer conUGT524, conToUGT524, conIF6123, conToIF6123, conRB3100, conToRB3100;
    public Renderer conTW2000, conToTW2000, conKT5112, conToKT5112, conO5C500, conToO5C500;
    public Renderer conToAL1102, conAL2401, conToAL2401, conAL2330, conToAL2330, conPowerAL1102, conPowerAL2330;
    public Renderer powerDN4012, wsMotorRL, wsOLGL;// con den va motor, relay...
    bool glowUGT524, glowIF6123, glowRB3100, glowTW2000, glowO5C500, glowKT5112, glowAL2401, glowAL2330, glowPowerAL2330, glowPowerAL1102;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "UGT524_C")
            {
                GlowConnectorF1(ref glowUGT524, ref conUGT524, ref conToUGT524);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "IF6123_C")
            {
                GlowConnectorF1(ref glowIF6123, ref conIF6123, ref conToIF6123);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "TW2000_C")
            {
                GlowConnectorF1(ref glowTW2000, ref conTW2000, ref conToTW2000);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "O5C500_C")
            {
                GlowConnectorF1(ref glowO5C500, ref conO5C500, ref conToO5C500);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "AL2330_C")
            {
                GlowConnectorF1(ref glowAL2330, ref conAL2330, ref conToAL2330);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "AL2401_C")
            {
                GlowConnectorF1(ref glowAL2401, ref conAL2401, ref conToAL2401);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "AL1102_P")
            {
                GlowConnectorF1(ref glowPowerAL1102, ref conPowerAL1102, ref powerDN4012);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "AL2330_P")
            {
                GlowConnectorF1(ref glowPowerAL2330, ref conPowerAL2330, ref powerDN4012);
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "RB3100_C")
            {
                GlowConnectorRB3100();
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "KT5112_C")
            {
                GlowConnectorKT5112();
            }

        }
    }
    private void GlowConnectorF1(ref bool glow, ref Renderer rendererGlow1, ref Renderer rendererGlow2)
    {
        if (glow == false)
        {
            rendererGlow1.material = glowMaterial;
            rendererGlow2.material = glowMaterial;
            glow = true;
        }    
        else
        {
            rendererGlow1.material = orangeIFM;
            rendererGlow2.material = orangeIFM;
            glow = false;
        }    
    }    
    private void GlowConnectorKT5112()
    {
        if (glowKT5112 == false)
        {
            conKT5112.material = glowMaterial;
            conToKT5112.material = glowMaterial;
            glowKT5112 = true;
        }
        else
        {
            conKT5112.material = blackConnector;
            conToKT5112.material = orangeIFM;
            glowKT5112 = false;
        }
    }    
    private void GlowConnectorRB3100()
    {
        if (glowRB3100 == false)
        {
            conRB3100.material = glowMaterial;
            conToRB3100.material = glowMaterial;
            glowRB3100 = true;
        }
        else
        {
            conRB3100.material = orangeIFM;
            conToRB3100.material = metal;
            glowRB3100 = false;
        }
    }    
}
