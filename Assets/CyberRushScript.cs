using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberRushScript : MonoBehaviour
{
    public GameObject Cog; 
    public PlayerMovement playerMovement;
    private Vector2 rotation;
    public SpriteRenderer cogSprite;
    public AudioSource RushSound;
    public AudioSource RushEnd; 
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime); 
        
    }


    void ResetRush() 
    {

        playerMovement.moveSpeed = playerMovement.moveSpeed / 2f;
        RushEnd.Play();

    }

    void CogEnd() 
    {
        Cog.SetActive(false);
    
    }



    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
        {

            RushSound.Play(); 

            playerMovement.moveSpeed = playerMovement.moveSpeed * 2f;
            cogSprite.enabled = false;




            Invoke("CogEnd", 1.5f);
            Invoke("ResetRush", 30f);
            


        }
    }
}
