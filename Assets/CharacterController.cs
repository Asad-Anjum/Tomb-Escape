using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;


    public float speed = 2.0f;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 direction;
    public GameController gc;

    private void Awake()
    {
        Instance = this;
    }

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
        if(col.tag == "Artifact")
        {
            gc.escaping = true;
            Destroy(col.gameObject);
        }
    }

    public void FastForward()
    {
        speed *= 1.25f;
    }
    public void Rewind()
    {
        speed *= 0.8f;
    }
    public void Enrage()
    {
        Debug.Log("Enrage");
    }
    public void Trap()
    {
        Debug.Log("Trap");
    }
    public void Map()
    {
        Debug.Log("Map");
    }
    public void Marker()
    {
        Debug.Log("Marker");
    }
    public void Burn()
    {
        Debug.Log("Burn");
    }
    public void Brighter()
    {
        Debug.Log("Brighter");
    }
    public void BurnOut()
    {
        Debug.Log("Burn Out");
    }



}
