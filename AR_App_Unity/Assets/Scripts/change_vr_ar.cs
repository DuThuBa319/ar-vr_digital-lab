using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_vr_ar : MonoBehaviour
{
    public GameObject cameraVR, camera, frameVRMode;
    bool modeVR;
    // Start is called before the first frame update
    void Start()
    {
        //frameVRMode.gameObject.SetActive(false);
        cameraVR.gameObject.SetActive(false);
        camera.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void ChangeVRAR()
    {
        //frameVRMode.gameObject.SetActive(!modeVR);
        cameraVR.gameObject.SetActive(!modeVR);
        camera.gameObject.SetActive(modeVR);
        modeVR = !modeVR;
    }    
}
