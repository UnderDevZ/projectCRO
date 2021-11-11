using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{




    void Start()
    {

    }


        void Update()
        {
            
        }
    

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.collider.CompareTag("Player"))
            
        {
            PlayerMovement.Health = (PlayerMovement.Health - 10);
        }

    }
}
