using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    private bool open = false;
    public Animator anim;
    public WeightedRandomList<Transform> loot;

    private Transform location;

    void Start()
    {
        location = this.gameObject.transform.GetChild(0);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player" && Input.GetKey(KeyCode.E) && !open)
        {
            open = true;
            anim.SetBool("Open", true);
            StartCoroutine(SpawnItem());
        }
    }

    private IEnumerator SpawnItem()
    {
        yield return new  WaitForSeconds(0.3f);
        Transform item = loot.GetRandom();
        
        var obj = Instantiate(item, location);
        obj.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        
        if(obj.gameObject.tag != "Burn")
            InventoryManager.Instance.Add(item.GetComponent<ItemController>().Item);
        else
            CharacterController.Instance.burns++;

        yield break;
        yield return new  WaitForSeconds(1.5f);
        Destroy(obj.gameObject);

    }
}
