using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float speed = 2.0f;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal Movement", movement.x);
        anim.SetFloat("Vertical Movement", movement.y);
    }

    void FixedUpdate () {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ffw")
        {
            speed *= 1.5f;
            Destroy(col.gameObject);
        }
        if(col.tag == "bwd")
        {
            speed *= 0.66f;
            Destroy(col.gameObject);
        }
    }

}
