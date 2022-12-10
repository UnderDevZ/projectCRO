using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPoint;
    public bool ShootLeft;
    public AudioClip clip;
  
    public AudioSource ShootSound;
    public bool isShot;


    public void Update()
    {


        if (isShot == true) 
        {

            ShootSound.Play();


        }

       





    }



    public void Shoot() 
    {
       
        GameObject shotitem = Instantiate(bullet, shootingPoint);
        shotitem.transform.parent = null;
        isShot = true;
        Invoke("ShotRefuse", 0.01f);
       



        if (ShootLeft == true)
        {
            shootingPoint.transform.localPosition = new Vector3(-shootingPoint.transform.localPosition.x, 0f, 0f);


        }
        else if (ShootLeft == false) 
        {


            shootingPoint.transform.localPosition = new Vector3(shootingPoint.transform.localPosition.x, 0f, 0f);

        }
       

        
        


    }

    public void ShotRefuse() 
    {
        isShot = false; 



    }
    
}

