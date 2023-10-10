using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pathfinding;
using Random = UnityEngine.Random;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;
    public List<LightTorch> lt = new List<LightTorch>();

    public TMP_Text burnText;
    public float speed = 2.0f;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 direction;
    public GameController gc;
    public int burns;

    public GameObject map;
    private GameObject _marker;

    private bool mapScanned;
    public bool hasMap = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        map.SetActive(false);
        _marker = transform.Find("Circle").gameObject;
        _marker.SetActive(false);
    }


    void Update()
    {
        burnText.text = "Burns: " + burns.ToString();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetFloat("Vertical Movement", 1f);
            if (!mapScanned) // this is a very shitty solution to the pathfinder not scanning issue.
            {
                AstarPath.active.Scan();
                mapScanned = true;
            }
        }
        else
        {
            anim.SetFloat("Vertical Movement", 0f);
        }


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
    }

    public void FastForward()
    {
        speed *= 1.15f;
    }

    public void Rewind()
    {
        speed *= 0.87f;
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
        map.SetActive(true);
        hasMap = true;
    }

    public void Marker()
    {
        _marker.SetActive(true);
    }

    public void Brighter()
    {
        gameObject.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius *= 2f;
        gameObject.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius *= 1.3f;
    }

    public void BurnOut()
    {
        if (lt != null && lt.Count > 2)
        {
            int first = Random.Range(0, lt.Count);
            int second = Random.Range(0, lt.Count);
            lt[first].lit = false;
            lt[first].light.intensity = 0;
            lt[first].anim.SetBool("lit", false);

            lt[second].lit = false;
            lt[second].light.intensity = 0;
            lt[second].anim.SetBool("lit", false);
            lt.Remove(lt[first]);
            lt.Remove(lt[second]);
        }
    }
}