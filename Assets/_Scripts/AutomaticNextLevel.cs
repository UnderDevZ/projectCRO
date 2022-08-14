using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AutomaticNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("NextLevelNow", 5); 
    }


    void NextLevelNow() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 

    
    }
}
