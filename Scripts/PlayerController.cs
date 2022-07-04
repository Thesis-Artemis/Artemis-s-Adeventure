using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;

    public PlayerHealth playerHealth;
    public float maxSpeed;
    public float jumpHeight;
    Rigidbody2D myBody;
    Animator myAnim;

    bool lookRight;
    bool ground;

    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance = this;
        this.playerHealth = GetComponent<PlayerHealth>();
        this.myBody = GetComponent<Rigidbody2D>();
        this.myAnim = GetComponent<Animator>();
        this.myAnim.SetFloat("Speed", -1);
        lookRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        this.myAnim.SetFloat("Speed", Mathf.Abs(move));
        this.myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        if(move > 0 && !lookRight)
        {
            flip();
        }
        else if(move<0 && lookRight)
        {
            flip();
        }
        else if (move == 0)
        {
            this.myAnim.SetFloat("Speed", -1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (ground)
            {
                ground = false;
                this.myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
               
            }
        }

        if (Input.GetAxisRaw("Fire1")>0)
        {
            fireBullet();
        }
    }

    void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (lookRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!lookRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }    
    }

    private void flip()
    {
        lookRight = !lookRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
          
    }
   
}
