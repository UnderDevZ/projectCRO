using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
  
    public AudioSource AudioClip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PlayAudioClip() 
    {
       
        AudioClip.Play(); 

    
    }

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))

        {

            AudioClip.Play();
            
            Debug.Log("Player Has Triggered Audio");


        }

    }

}
