using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialChest : MonoBehaviour
{
    private bool open = false;
    public GameObject text;
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player" && Input.GetKey(KeyCode.E) && !open)
        {
            StartCoroutine(ShowText());
        }
    }

    private IEnumerator ShowText()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(4f);
        Destroy(text);
        yield break;
    }
}
