using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_kt5112 : MonoBehaviour
{
    public GameObject clickKT5112, notClickKT5112;
    public Material whiteClickKT5112, redClickKT5112;
    public Renderer btnKT5112;
    // Start is called before the first frame update
    void Start()
    {
        clickKT5112.gameObject.SetActive(false);
        notClickKT5112.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (global_variables.clickKT5112 == true)
        {
            clickKT5112.gameObject.SetActive(true);
            notClickKT5112.gameObject.SetActive(false);
            btnKT5112.material = redClickKT5112;
        }    
        else
        {
            clickKT5112.gameObject.SetActive(false);
            notClickKT5112.gameObject.SetActive(true);
            btnKT5112.material = whiteClickKT5112;
        }    
    }
}
