using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightTorch : MonoBehaviour
{
    public bool lit = false;
    public UnityEngine.Rendering.Universal.Light2D light;
    public Animator anim;

    void Start()
    {
        //light = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
        light.intensity = 0;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if(col.tag == "Player")
        {

            if(Input.GetKey(KeyCode.E))
            {
                lit = true;
                light.intensity = 1;
                anim.SetBool("lit", true);
            }
                
        }
    }
}
