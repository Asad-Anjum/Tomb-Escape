using System.Collections;
using System.Collections.Generic;
using Edgar.Unity;
using UnityEngine;

namespace GameManager
{
    public class LevelManager : MonoBehaviour
    {
        private DungeonGeneratorGrid2D _generator;
        private LevelInfoGrid2D _levelInfo;
        public GameObject player;

        private void Awake()
        {
            _generator = GameObject.Find("Dungeon Generator").GetComponent<DungeonGeneratorGrid2D>();
        }

        private void Start()
        {
            StartCoroutine(GenerateLevel());
        }


        private IEnumerator GenerateLevel()
        {
            // Start the generator coroutine
            _generator.Generate();

            // change layername of walls... Why does this have to be a pain?
            GameObject generatedLevel = GameObject.Find("Generated Level");
            GameObject wallsGameObject = generatedLevel.transform.Find("Tilemaps").transform.Find("Walls").gameObject;
            wallsGameObject.layer = LayerMask.NameToLayer("Walls");
            Debug.Log("walls layer applied");

            // start calculation A* WHY IS IT NOT SCANNING>??????
            //AstarPath.active.Scan();
            //Debug.Log("scanned...");

            yield break;
        }
    }
}