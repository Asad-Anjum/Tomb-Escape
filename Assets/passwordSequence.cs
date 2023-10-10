using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passwordSequence : MonoBehaviour
{
    bool seq1 = false;
    bool seq2 = false;
    bool seq3 = false;
    public List<int> seq = new List<int>();
    public int hit = 10;
    private int check = 0;
    public Transform enrage;
    public Transform chest;
    public Transform specialChest;
    public Transform dropLocation1;
    public Transform dropLocation2;
    private int finished = 0;

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player") 
        {
            StartCoroutine(Sequence1());
            seq1 = true;
            this.GetComponent<Collider2D>().enabled = false;
        }
    }

    private IEnumerator Sequence1()
    {
        for(int i = 0; i < 3; i++)
        {
            int current = Random.Range(0,5);
            seq.Add(current);
            this.transform.GetChild(current).GetComponent<passTorch>().Light();
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }
    
    private IEnumerator Sequence2()
    {
        yield return new WaitForSeconds(3f);
        seq.Clear();
        for(int i = 0; i < 4; i++)
        {
            int current = Random.Range(0,5);
            seq.Add(current);
            this.transform.GetChild(current).GetComponent<passTorch>().Light();
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    private IEnumerator Sequence3()
    {
        yield return new WaitForSeconds(3f);
        seq.Clear();
        for(int i = 0; i < 5; i++)
        {
            int current = Random.Range(0,5);
            seq.Add(current);
            this.transform.GetChild(current).GetComponent<passTorch>().Light();
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }
    


    void Update()
    {
        if(seq1 && hit < 5)
        {
            if(seq[check] == hit){
                check++;
                this.transform.GetChild(hit).GetComponent<passTorch>().Light();
                hit = 10;
                
            }
            else
            {
                InventoryManager.Instance.Add(enrage.GetComponent<ItemController>().Item);
                var obj = Instantiate(enrage, dropLocation1);
                obj.parent = null;
                Destroy(gameObject);
            }
                
            
            if(check > 2) {
                seq1 = false;
                seq2 = true;
                finished++;
                check = 0;
                StartCoroutine(Sequence2());
            }
        }

        if(seq2 && hit < 5)
        {
            if(seq[check] == hit){
                check++;
                this.transform.GetChild(hit).GetComponent<passTorch>().Light();
                hit = 10;
                
            }
            else
            {
                var obj = Instantiate(chest, dropLocation1);
                obj.parent = null;
                Destroy(gameObject);
            }
                
            
            if(check > 3) {
                seq2 = false;
                seq3 = true;
                finished++;
                check = 0;
                StartCoroutine(Sequence3());
            }
        }

        if(seq3 && hit < 5)
        {
            if(seq[check] == hit){
                check++;
                this.transform.GetChild(hit).GetComponent<passTorch>().Light();
                hit = 10;
                
            }
            else
            {
                var obj = Instantiate(specialChest, dropLocation1);
                obj.parent = null;
                Destroy(gameObject);
            }
                
            
            if(check > 4) {
                seq3 = false;
                finished++;
                var obj = Instantiate(chest, dropLocation1);
                obj.parent = null;
                var obj2 = Instantiate(specialChest, dropLocation2);
                obj2.parent = null;
                Destroy(gameObject);
            }
        }
    }

}
