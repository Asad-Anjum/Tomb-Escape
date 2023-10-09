using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;

    public TMP_Text burnText;
    public float speed = 2.0f;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 direction;
    public GameController gc;
    public int burns;

    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        burnText.text = "Burns: " + burns.ToString();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
            anim.SetFloat("Vertical Movement", 1f);
        else
            anim.SetFloat("Vertical Movement", 0f);


        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        transform.up = direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Artifact")
        {
            gc.activate = true;
            gc.escaping = true;
            Destroy(col.gameObject);
        }

        if (col.tag == "Burn")
        {
            burns++;
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
        Debug.Log("enrage"); // CHANGE ENEMY SPEED WITH THIS
    }

    public void Trap()
    {
        Debug.Log("Trap"); // STOP ENEMY FOR 2 SECONDS WHEN HE STEPS ON THIS
    }

    public void Map()
    {
        Debug.Log("Map"); //ACTIVATE MINIMAP
    }

    public void Marker()
    {
        Debug.Log("Marker"); //SHOW YOUR LOCATION ON THE MINIMAP
    }

    public void Brighter()
    {
        gameObject.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius *= 2f;
        gameObject.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius *= 1.3f;
    }

    public void BurnOut()
    {
        Debug.Log("Burn Out");
    }
}