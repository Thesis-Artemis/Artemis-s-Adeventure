using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject dieEffect;
    Animator anim;

    public Slider playerHealthSlider;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamge(float damge)
    {
        if(damge<=0)
        {
            return;
        }
        currentHealth -= damge;
        playerHealthSlider.value = currentHealth;
        if(isDead())
        {
            makeDead();
        }    
    }

    public void addHealth(float health)
    {
        currentHealth += health;
        playerHealthSlider.value = currentHealth;
        
    }

    void makeDead()
    {
        anim.SetTrigger("Die");
        Vector3 positionCharacter = new Vector3(transform.position.x, transform.position.y, -10);
        Instantiate(dieEffect, positionCharacter, transform.rotation);
           
    }
    public virtual bool isDead()
    {
        if(currentHealth<=0)
        {
            return true;
        }
        return false;
    }    
    void changeSence()
    { SceneManager.LoadScene("GameOver"); }    
    
}
