using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
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

}
