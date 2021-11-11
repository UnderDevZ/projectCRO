using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPoint;
    public bool ShootLeft;




   


    public void Shoot() 
    {
        GameObject shotitem = Instantiate(bullet, shootingPoint);
        shotitem.transform.parent = null;

        if (ShootLeft == true)
        {
            shootingPoint.transform.localPosition = new Vector3(-shootingPoint.transform.localPosition.x, 0f, 0f);


        }
        else if (ShootLeft == false) 
        {


            shootingPoint.transform.localPosition = new Vector3(shootingPoint.transform.localPosition.x, 0f, 0f);

        }

        


    }
    
}

