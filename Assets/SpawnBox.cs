using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject Box;
    public float radius = 1;


        void Start()
    {
        InvokeRepeating("SpawnObjectRandom", 1f, 3f);
    }

        void Update()
    {
        
    }
    void SpawnObjectRandom() 
    
    {
        Vector3 randomPos = Random.insideUnitCircle * radius;
        Instantiate(Box, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}


