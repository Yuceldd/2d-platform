using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AnaMenuKontrol : MonoBehaviour
{
    GameObject Level1, Level2, Level3;
    GameObject Levels1;
    GameObject Sound1,Sound, Sound2;
    GameObject Nickname;
    public InputField Nickname1;
    string Nick;
    public string snickname;
    void Start()
    {   
        Level1 = GameObject.Find("Level1");
        Level2 = GameObject.Find("Level2");
        Level3 = GameObject.Find("Level3");
        Sound1 = GameObject.Find("Sound/on");
        Sound2 = GameObject.Find("Sound/off");
        Sound = GameObject.FindGameObjectWithTag("Sound");
        Nickname = GameObject.Find("Nickname");
        Levels1 = GameObject.Find("Levels1");
      
        

        PlayerPrefs.SetInt("sesKontrol", 0);
       




        for (int i =0;i<PlayerPrefs.GetInt("whichLevel");i++)
        {
            Levels1.transform.GetChild(i).GetComponent<Button>().interactable = true;
           
        }


    }
    public void ButtonSelect(int ButtonVal)
    {
        if (ButtonVal == 1)
        {
            SceneManager.LoadScene(1);
            
        }

        else if (ButtonVal == 2)
        {
            Level1.SetActive(true);
            Level2.SetActive(true);
            Level3.SetActive(true);

        }
        else if (ButtonVal == 3)
        {
            Debug.Log("exit");
            Application.Quit();
            Debug.Log("exit1");
        }
        else if (ButtonVal == 4)
        {
            Debug.Log("settings");
            Sound1.SetActive(true);
            Sound2.SetActive(true);
        }

        else if (ButtonVal == 5)
        {
            PlayerPrefs.SetInt("sesKontrol", 1);
            Debug.Log("seson");

            Sound.SetActive(true);


        }
        else if (ButtonVal == 6)
        {

            PlayerPrefs.SetInt("sesKontrol", 0);
            Debug.Log("sesoff");
            Sound.SetActive(false);
            

        }
        else if (ButtonVal == 7)
        {

            PlayerPrefs.DeleteAll();
            

        }



    }
    public void LevelSecim(int gelenlw)
    {
        SceneManager.LoadScene(gelenlw);
    }
    
}
