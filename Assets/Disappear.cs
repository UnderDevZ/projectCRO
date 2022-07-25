using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
    
{
    public GameObject self; 




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Vanish", 0.5f);
    }

    void Vanish() 
    {
        self.SetActive(false); 
    
    }
}
