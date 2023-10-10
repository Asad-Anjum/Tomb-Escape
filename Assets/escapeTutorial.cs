using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeTutorial : MonoBehaviour
{
    public GameObject explore;
    public GameObject escape;
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(explore);
        escape.SetActive(true);
    }
}
