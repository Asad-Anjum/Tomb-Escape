using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject[] EnemiesToSpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for (int i = 0; i < EnemiesToSpawn.Length; i++)
            {
                //Instantiate(EnemiesToSpawn[i]);
                EnemiesToSpawn[i].SetActive(true);
                EnemiesToSpawn[i].transform.parent = null;
            }
        }

    }
}
