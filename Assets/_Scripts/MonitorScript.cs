using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class MonitorScript : MonoBehaviour
{
    public AudioSource MonitorSound;
    
    public GameObject HackScreen;
    public Canvas Hack; 

   public void MonitorTouch() 
    {
        MonitorSound.Play();
       
        HackScreen.SetActive(true);

        Hack.enabled = true; 
    
    }
     void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
          
        {

            
            MonitorTouch();
            Debug.Log("Player Is Hacking");


        }
        
        }
   




}














