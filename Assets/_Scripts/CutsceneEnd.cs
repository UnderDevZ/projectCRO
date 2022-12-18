using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEnd : MonoBehaviour
{
    

    
    void Update()
    {
        Invoke("LoadAfterCutscene", 50);
    }



    public void LoadAfterCutscene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    
    
    
    }
}
