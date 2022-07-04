using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBossHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addDamge(float damage)
    {

        currentHealth -= damage;
        if (isDead())
        {
            makeDead();
        }
    }

    private void makeDead()
    {
        Destroy(gameObject);
    }

    bool isDead()
    {
        if (currentHealth <= 0)
        { return true; }
        return false;
    }
}
