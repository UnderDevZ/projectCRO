using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject Heart; 

    void Start()
    {
        
    }

   
    void Update()



    {
        


    }
    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
        {

            PlayerMovement.Health = 100f;


            Invoke("HeartEnd",0.01f);


        }
    }

    void HeartEnd() 
    
    {

        Heart.SetActive(false); 
    }
}

