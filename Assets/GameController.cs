using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    

    public bool escaping = false;
    public bool activate = false;
    private GameObject[] obs;
    public int burns;

    public AudioSource normalTheme;



    void Start()
    {
        obs = (GameObject[]) Object.FindObjectsOfType(typeof(GameObject));
    }
    void Update()
    {
        burns = CharacterController.Instance.burns;
        obs = (GameObject[]) Object.FindObjectsOfType(typeof(GameObject));
        if(activate)
        {
            int abilityLayer = LayerMask.NameToLayer("Abilities");
            int enemyLayer = LayerMask.NameToLayer("Enemy");
            int torchLayer = LayerMask.NameToLayer("Torch");
            normalTheme.Stop();
            for(int i = 0; i< obs.Length; i++)
            {
                // if((obs[i].layer == abilityLayer || obs[i].layer == enemyLayer))
                // {
                //     Destroy(obs[i]);
                // }
                if(obs[i].tag == "Global Light")
                {
                    obs[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 0;
                }
                if(obs[i].tag == "Player Torch")
                {
                    obs[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1f;
                    obs[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 0f;
                    obs[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 2f;
                }
                if(obs[i].layer == torchLayer)
                {
                    obs[i].GetComponent<Collider2D>().enabled = false;
                } 

            }
            activate = false;
        }

        if(Input.GetMouseButtonDown(1) && escaping)
        {
            List<Item> Items = InventoryManager.Instance.Items;
            UseItem(Items[Items.Count - 1]);
            InventoryManager.Instance.Remove(Items[Items.Count - 1]);
            //Destroy(InventoryManager.Instance.InventoryItems[0].gameObject);
        }

        if(Input.GetKeyDown(KeyCode.Q) && escaping && burns > 0)
        {
            List<Item> Items = InventoryManager.Instance.Items;
            InventoryManager.Instance.Remove(Items[Items.Count - 1]);
            CharacterController.Instance.burns--;
        }
        


    }

    public void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.ffd:
                CharacterController.Instance.FastForward();
                break;
            case Item.ItemType.bwd:
                CharacterController.Instance.Rewind();
                break;
            case Item.ItemType.enrage:
                CharacterController.Instance.Enrage();
                break;
            case Item.ItemType.trap:
                CharacterController.Instance.Trap();
                break;
            case Item.ItemType.map:
                CharacterController.Instance.Map();
                break;
            case Item.ItemType.marker:
                CharacterController.Instance.Marker();
                break;
            case Item.ItemType.brighter:
                CharacterController.Instance.Brighter();
                break;
            case Item.ItemType.burnOut:
                CharacterController.Instance.BurnOut();
                break;
        }
    }
}
