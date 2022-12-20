using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadPyramid : MonoBehaviour
{

    public void LoadPyramidScene()
    {

        SceneManager.LoadScene("Pyramid");

    }
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

            LoadPyramidScene();

        }
    }



}
