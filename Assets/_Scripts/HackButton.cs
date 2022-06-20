using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HackButton : MonoBehaviour
{

    public void Puzzle1() 
    {
        SceneManager.LoadScene("Puzzle1st");
    
    }
    public void NextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
