using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonitorScript : MonoBehaviour
{
    public AudioSource MonitorSound;
    public GameObject HackProceed; 


    void MonitorTouch() 
    {
        MonitorSound.Play();
        HackProceed.SetActive(true); 
    
    }
     void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
          
        {
            Debug.Log("Player Is Hacking");

        
        }
        
        }
   




}














