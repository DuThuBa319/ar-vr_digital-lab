using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_hide_cube : MonoBehaviour
{
    public GameObject cubeUGT524, cubeIF6123;
    bool showCubeUGT524, showCubeIF6123;
    // Start is called before the first frame update
    void Start()
    {
        cubeUGT524.gameObject.SetActive(false);
        cubeIF6123.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowHideCubeUGT524()
    {
        cubeUGT524.gameObject.SetActive(!showCubeUGT524);
        showCubeUGT524 = !showCubeUGT524;
    }
    public void ShowHideCubeIF6123()
    {
        cubeIF6123.gameObject.SetActive(!showCubeIF6123);
        showCubeIF6123 = !showCubeIF6123;
    }
}
