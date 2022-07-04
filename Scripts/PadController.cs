using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour
{
    private Rigidbody2D pad;
    public bool checkMarkUp;

    // Start is called before the first frame update
    void Start()
    {
        pad = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = 0f;
        if(checkMarkUp)
        {
            moveY = -2f;
        }
        else
        {
            moveY = 2f;
        }
        pad.velocity = new Vector2(0, transform.localScale.y)*moveY;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="markup")
        {
            checkMarkUp = false;
        }
        if (collision.gameObject.tag == "Markdown")
        {
            checkMarkUp = true;
        }
    }
}
