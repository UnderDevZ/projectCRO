using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinalBossAI : MonoBehaviour
{
    public int health;
    public Slider HP;
    public Transform spawnPoint;
    public GameObject projectile;
    void Start()


    {

    }


    // Update is called once per frame
    void Update()
    {
        HP.value = health;
        if (health <= 0 ) 
        {
            BossDeath();
            
        
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))

        {
            PlayerMovement.Health = (PlayerMovement.Health - 10);

        }
        if (collision.collider.CompareTag("Bullet"))
        {

            health = (health - 1);
        }

    }
    public void Shoot()
    {

        GameObject shotitem = Instantiate(projectile, spawnPoint);
        shotitem.transform.parent = null;

        Invoke("ShotRefuse", 0.01f);

    }

    public void BossDeath()
    {


        Invoke("NextScene", 5); 

    }

    public void NextScene() 
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

}
