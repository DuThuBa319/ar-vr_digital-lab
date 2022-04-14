using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class rotate_o5c500 : MonoBehaviour
{
    public GameObject colourPipe, diskMotor;
    public float rotSpeechDiskMotor;   //100
    public float rotSpeechColourPipe; //10

    public GameObject gameObjectParent, gameObjectRotate;
    float a1, a2, angle, localAngleO5C500;

    public TextMeshProUGUI statusO5C500;
    public Sprite spriteTrueColorO5C500, spriteFalseColorO5C500;
    public Image colorO5C500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diskMotor.transform.Rotate(0f, 1f * rotSpeechDiskMotor * Time.deltaTime, 0f);

        a1 = gameObjectRotate.transform.eulerAngles.z;
        a2 = gameObjectParent.transform.parent.eulerAngles.z;
        angle = a1 - a2;
        //Debug.Log("Angle 05C500 = " + angle.ToString());

        if (angle < 0)
        {
            localAngleO5C500 = angle + 360;
        }
        else
        {
            localAngleO5C500 = angle;
        }

        if (localAngleO5C500 >= 345 || localAngleO5C500 <= 26)
        {
            global_variables.sensorO5C500 = true;
            statusO5C500.text = "TRUE";
            colorO5C500.sprite = spriteTrueColorO5C500;
        }    
        else if (localAngleO5C500 >= 165 && localAngleO5C500 <=  207)
        {
            global_variables.sensorO5C500 = true;
            statusO5C500.text = "TRUE";
            colorO5C500.sprite = spriteTrueColorO5C500;
        }    
        else
        {
            global_variables.sensorO5C500 = false;
            statusO5C500.text = "FALSE";
            colorO5C500.sprite = spriteFalseColorO5C500;
        }
    }
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeechColourPipe;
        transform.Rotate(Vector3.forward, -rotX);
    }
}
