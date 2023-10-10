using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCollide : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "Player")
        {
            if(this.tag == "Button1")
                this.GetComponentInParent<passTorch>().GetComponentInParent<passwordSequence>().hit = 0;
            else if(this.tag == "Button2")
                this.GetComponentInParent<passTorch>().GetComponentInParent<passwordSequence>().hit = 1;
            else if(this.tag == "Button3")
                this.GetComponentInParent<passTorch>().GetComponentInParent<passwordSequence>().hit = 2;
            else if(this.tag == "Button4")
                this.GetComponentInParent<passTorch>().GetComponentInParent<passwordSequence>().hit = 3;
            else if(this.tag == "Button5")
                this.GetComponentInParent<passTorch>().GetComponentInParent<passwordSequence>().hit = 4;
        }
   }
}
