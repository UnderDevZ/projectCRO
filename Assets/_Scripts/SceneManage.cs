using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class SceneManage : MonoBehaviour
{


    int SavedScene;
    int SceneIndex;

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
    public void LoadHell() 
    {
        SceneManager.LoadScene("Hell");
        
    }

    public void LoadPuzzle2() 
    {

        SceneManager.LoadScene("Puzzle2");
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            NextLevel(); 
        
        }
    }


    public void LoadSavedScene() 
    {
        SavedScene = PlayerPrefs.GetInt("Saved");

        if (SavedScene != 0)
            SceneManager.LoadSceneAsync(SavedScene);
        else
            return; 
       
    
    }

    public void SaveScene() 
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Saved", SceneIndex);
        PlayerPrefs.Save();
      
    
    
    }

    public void LoadCredits() 
    {
        SceneManager.LoadScene("Credits"); 

    
    
    }
   



}
