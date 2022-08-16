using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class SceneManage : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "W1_Level2")
            BGMusic.instance.GetComponent<AudioSource>().Pause();

        if(SceneManager.GetActiveScene().name == "GameOver" )
            BGMusic.instance.GetComponent<AudioSource>().Pause();
        
        
        if (SceneManager.GetActiveScene().name == "MainMenu")
            BGMusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "TestScene")
            BGMusic.instance.GetComponent<AudioSource>().Play();


    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            NextLevel(); 
        
        }
    }



}
