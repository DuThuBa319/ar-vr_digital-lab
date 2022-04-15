using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_vr_ar : MonoBehaviour
{
    public GameObject cameraVR, camera, frameVRMode;
    public Sprite spriteAR, spriteVR;
    public Image iconARVR;
    bool modeVR;
    // Start is called before the first frame update
    void Start()
    {
        frameVRMode.gameObject.SetActive(false);
        cameraVR.gameObject.SetActive(false);
        iconARVR.sprite = spriteAR;
        //camera.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void ChangeVRAR()
    {
        if (modeVR == false)
        {
            frameVRMode.gameObject.SetActive(true);
            cameraVR.gameObject.SetActive(true);
            iconARVR.sprite = spriteVR;
            modeVR = true;
        }   
        else
        {
            frameVRMode.gameObject.SetActive(false);
            cameraVR.gameObject.SetActive(false);
            iconARVR.sprite = spriteAR;
            modeVR = false;
        }    
        //frameVRMode.gameObject.SetActive(!modeVR);
        //cameraVR.gameObject.SetActive(!modeVR);
        //camera.gameObject.SetActive(modeVR);
        //modeVR = !modeVR;
    }    
}
