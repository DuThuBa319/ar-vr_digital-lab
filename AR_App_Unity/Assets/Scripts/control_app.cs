using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control_app : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartApp()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("QuitApp!");
    }
}
