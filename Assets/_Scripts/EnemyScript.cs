﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class EnemyScript : MonoBehaviour
{

    public int EnemyHealth;
    public SpriteRenderer sprite;

    public Animator FoxAnim; 


    
    public void Death() 
    {

        gameObject.SetActive(false);
       
    }
    public void TurnRed() 
    {
       
        sprite.color = new Color(118f,11f,11f);
        
        





    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        FoxAnim = GetComponent<Animator>();
    }


        void Update()
        {

        


        if (EnemyHealth == 0 || EnemyHealth < 0)

        {
            FoxAnim.Play("FoxDeath");
            Invoke("TurnRed", 2);
            Invoke("Death", 1);



        }
    }

   
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            
        {
            PlayerMovement.Health = (PlayerMovement.Health - 10);
            
        }
        if (collision.collider.CompareTag("Bullet"))
        {

            EnemyHealth = (EnemyHealth - 1);
        }

       

    }
}
