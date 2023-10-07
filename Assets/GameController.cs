using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool escaping = false;
    private GameObject[] obs;
    void Start()
    {
        obs = (GameObject[]) Object.FindObjectsOfType(typeof(GameObject));
    }
    void Update()
    {
        obs = (GameObject[]) Object.FindObjectsOfType(typeof(GameObject));
        if(escaping)
        {
            int abilityLayer = LayerMask.NameToLayer("Abilities");
            int enemyLayer = LayerMask.NameToLayer("Enemy");
            int torchLayer = LayerMask.NameToLayer("Torch");
            for(int i = 0; i< obs.Length; i++)
            {
                if((obs[i].layer == abilityLayer || obs[i].layer == enemyLayer))
                {
                    Destroy(obs[i]);
                }
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
        }
        

    }
}
