using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPassword : MonoBehaviour
{
    public GameObject zeroSeq;
    public GameObject oneSeq;
    public GameObject twoSeq;
    public GameObject threeSeq;
    private bool once = true;
    void Update()
    {
        if(this.GetComponent<passwordSequence>().exited && once)
        {
            if(this.GetComponent<passwordSequence>().finished == 0)
                zeroSeq.SetActive(true);
            if(this.GetComponent<passwordSequence>().finished == 1)
                oneSeq.SetActive(true);
            if(this.GetComponent<passwordSequence>().finished == 2)
                twoSeq.SetActive(true);
            if(this.GetComponent<passwordSequence>().finished == 3)
                threeSeq.SetActive(true);
            
            once = false;
        }

    }
}
