using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseScript : MonoBehaviour
{

    bool isPaused = false;
    public GameObject Resume;
    public GameObject Controls;
    public Canvas ControlCanvas; 



    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            Resume.SetActive(false);
            

        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            Resume.SetActive(true);
            Controls.SetActive(false);
          


            
        }



    }


    public void ResumeGame() 
    {
        Time.timeScale = 1;
        isPaused = false;
        Resume.SetActive(false);
        Controls.SetActive(true);
        Resume.SetActive(false);

    
    }
}
