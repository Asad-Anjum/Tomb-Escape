using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passTorch : MonoBehaviour
{
    public bool lit = false;
    public UnityEngine.Rendering.Universal.Light2D light;
    public Animator anim;

    void Start()
    {
        light.intensity = 0;
    }

    public void Light()
    {
        StartCoroutine(Set());
    }

    private IEnumerator Set()
    {
        lit = true;
        light.intensity = 1;
        anim.SetBool("lit", true);
        yield return new WaitForSeconds(0.8f);

        lit = false;
        light.intensity = 0;
        anim.SetBool("lit", false);

        yield break;

    }
}
