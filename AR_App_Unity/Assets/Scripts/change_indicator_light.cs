using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_indicator_light : MonoBehaviour
{
    //[SerializeField] private Material redLightGlow, redLightOff, redLightOn, blackPng;
    //public GameObject redLightIN1, redLightIN2, redLightOut;
    [SerializeField] private Material redLightGlow, redLightOff, redLightOn, blackPng;
    [SerializeField] private Renderer redLightIN1, redLightIN2, redLightOut;

    [SerializeField] private Material greenLightGlow, greenLightOff, greenLightOn;
    [SerializeField] private Renderer greenLightIN1, greenLightIN2, greenLightOut;

    [SerializeField] private Material orangeLightGlow, orangeLightOff, orangeLightOn;
    [SerializeField] private Renderer orangeLightIN1, orangeLightIN2, orangeLightOut;

    int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        redLightIN1.material = redLightOff;
        redLightIN2.material = redLightOff;
        redLightOut.material = blackPng;

        greenLightIN1.material = greenLightOff;
        greenLightIN2.material = greenLightOff;
        greenLightOut.material = blackPng;

        orangeLightIN1.material = orangeLightOff;
        orangeLightIN2.material = orangeLightOff;
        orangeLightOut.material = blackPng;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GlowLight()
    {
        if (flag == 0)
        {
            redLightIN1.material = redLightGlow;
            redLightIN2.material = redLightGlow;
            redLightOut.material = redLightOn;
            flag++;
        }
        else if (flag == 1)
        {
            orangeLightIN1.material = orangeLightGlow;
            orangeLightIN2.material = orangeLightGlow;
            orangeLightOut.material = orangeLightOn;
            flag++;
        }
        else if (flag == 2)
        {
            greenLightIN1.material = greenLightGlow;
            greenLightIN2.material = greenLightGlow;
            greenLightOut.material = greenLightOn;
            flag++;
        }
        else
        {
            redLightIN1.material = redLightOff;
            redLightIN2.material = redLightOff;
            redLightOut.material = blackPng;

            greenLightIN1.material = greenLightOff;
            greenLightIN2.material = greenLightOff;
            greenLightOut.material = blackPng;

            orangeLightIN1.material = orangeLightOff;
            orangeLightIN2.material = orangeLightOff;
            orangeLightOut.material = blackPng;
            flag = 0;
        }
    }
}
