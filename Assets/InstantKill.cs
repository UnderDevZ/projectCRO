using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    public PlayerMovement playerMovement;
 

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
        {

            PlayerMovement.Health = 0f; 
            

        }
    }
}
