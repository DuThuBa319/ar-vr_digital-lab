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

    public GameObject diskMotor;
    public float rotSpeechDiskMotor;   //5000

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
        //Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + global_variables.byte67);
        if (global_variables.onMCB)
        {
            if (global_variables.byte65 == 0)
            {
                redLightIN1.material = redLightOff;
                redLightIN2.material = redLightOff;
                redLightOut.material = blackPng;

                greenLightIN1.material = greenLightOff;
                greenLightIN2.material = greenLightOff;
                greenLightOut.material = blackPng;
            }
            else if (global_variables.byte65 == 1)
            {
                redLightIN1.material = redLightGlow;
                redLightIN2.material = redLightGlow;
                redLightOut.material = redLightOn;

                greenLightIN1.material = greenLightOff;
                greenLightIN2.material = greenLightOff;
                greenLightOut.material = blackPng;
            }
            else if (global_variables.byte65 == 2)
            {
                redLightIN1.material = redLightOff;
                redLightIN2.material = redLightOff;
                redLightOut.material = blackPng;

                greenLightIN1.material = greenLightGlow;
                greenLightIN2.material = greenLightGlow;
                greenLightOut.material = greenLightOn;
            }
            else if (global_variables.byte65 == 3)
            {
                redLightIN1.material = redLightGlow;
                redLightIN2.material = redLightGlow;
                redLightOut.material = redLightOn;

                greenLightIN1.material = greenLightGlow;
                greenLightIN2.material = greenLightGlow;
                greenLightOut.material = greenLightOn;
            }

            if (global_variables.byte67 == 0)
            {
                orangeLightIN1.material = orangeLightOff;
                orangeLightIN2.material = orangeLightOff;
                orangeLightOut.material = blackPng;
            }
            else if (global_variables.byte67 == 1)
            {
                orangeLightIN1.material = orangeLightOff;
                orangeLightIN2.material = orangeLightOff;
                orangeLightOut.material = blackPng;

                diskMotor.transform.Rotate(0f, 1f * rotSpeechDiskMotor * Time.deltaTime, 0f);
            }
            else if (global_variables.byte67 == 2)
            {
                orangeLightIN1.material = orangeLightGlow;
                orangeLightIN2.material = orangeLightGlow;
                orangeLightOut.material = orangeLightOn;
            }
            else if (global_variables.byte67 == 3)
            {
                orangeLightIN1.material = orangeLightGlow;
                orangeLightIN2.material = orangeLightGlow;
                orangeLightOut.material = orangeLightOn;

                diskMotor.transform.Rotate(0f, 1f * rotSpeechDiskMotor * Time.deltaTime, 0f);
            }
        }    
        
        

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
