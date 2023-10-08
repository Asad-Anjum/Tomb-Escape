using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 2.0f;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 direction;
    public GameController gc;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x != 0 || movement.y != 0)
            anim.SetFloat("Vertical Movement", 1f);
        else
            anim.SetFloat("Vertical Movement", 0f);



        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
    }

    void FixedUpdate () {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        transform.up = direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ffw")
        {
            speed *= 1.25f;
            Destroy(col.gameObject);
        }
        if(col.tag == "bwd")
        {
            speed *= 0.8f;
            Destroy(col.gameObject);
        }
        if(col.tag == "Artifact")
        {
            gc.escaping = true;
            Destroy(col.gameObject);
        }
    }



}
