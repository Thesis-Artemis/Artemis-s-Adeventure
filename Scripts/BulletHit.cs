using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    BulletController myPC;
    public GameObject explosion;
    public float bulletDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        myPC = GetComponentInParent<BulletController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Shoot")
        {
            myPC.removeBullet();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if(collision.gameObject.layer ==LayerMask.NameToLayer("enemy"))
            {
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamge(bulletDamage);
            }    
        }    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shoot")
        {
            myPC.removeBullet();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
