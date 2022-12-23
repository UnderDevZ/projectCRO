using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEnd : MonoBehaviour
{
   public int CutSceneTimer;

    
    void Update()
    {
        Invoke("LoadAfterCutscene", CutSceneTimer);
    }



    public void LoadAfterCutscene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    
    
    
    }
}
