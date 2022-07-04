using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNewLevel : MonoBehaviour
{
   

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene("GameComplete");
            }    
        }
    }
   
}
