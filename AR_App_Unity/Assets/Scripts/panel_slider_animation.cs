using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel_slider_animation : MonoBehaviour
{
    public GameObject PanelSliderMenu;
    public Sprite btnSlideOut, btnSlideIn;
    public Image iconBtnSlide;

    bool flagIconBtnSlide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideMenu()
    {
        if (PanelSliderMenu != null)
        {
            Animator animator = PanelSliderMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("showPanelSlider");
                animator.SetBool("showPanelSlider", !isOpen);
            }    
        }  

        if (flagIconBtnSlide == false)
        {
            iconBtnSlide.sprite = btnSlideIn;
            flagIconBtnSlide = true;
        }    
        else
        {
            iconBtnSlide.sprite = btnSlideOut;
            flagIconBtnSlide = false;
        }    
    }    

}
