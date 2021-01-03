using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;


public class ButtonControl : MonoBehaviour
{ GameObject Sound;

    void Start()
    {
        Sound = GameObject.FindGameObjectWithTag("Sound");
        
    }
    public void ButtonSelect1(int ButtonVal)
    {
        if (ButtonVal == 1)
        {
            Application.Quit();
        }

        else if (ButtonVal == 2)
        {
            PlayerPrefs.SetInt("sesKontrol", 1);
            

            Sound.SetActive(true); 


        }
        else if (ButtonVal == 3)
        {
            PlayerPrefs.SetInt("sesKontrol", 0);
           
            Sound.SetActive(false);
        }


    }
}

