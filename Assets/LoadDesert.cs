using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadDesert : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadDesert2();


        }
    }

    public void LoadDesert2() 
    {
        
        SceneManager.LoadScene("Wrld4_Lvl2");

        Debug.Log("Working Transition");
    
    }
}
