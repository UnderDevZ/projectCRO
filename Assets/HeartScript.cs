using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject Heart;
    public AudioSource HeartSound;

    public SpriteRenderer HeartSprite; 
    void Start()
    {

        HeartSprite = GetComponent<SpriteRenderer>(); 

    }

   
    void Update()



    {
        
        

    }
    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
        {
            HeartSprite.enabled = false;
            HeartSound.Play();

            PlayerMovement.Health = 100f;
            

          
            
            Invoke("HeartEnd",1.5f);


        }
    }

    void HeartEnd() 
    
    {
        HeartSound.Play(); 
        Heart.SetActive(false);
        
        
    }
}

