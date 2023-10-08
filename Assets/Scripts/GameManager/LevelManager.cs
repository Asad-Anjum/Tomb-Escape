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
            _levelInfo = GameObject.Find("Generated Level").GetComponent<LevelInfoGrid2D>();
            
            // find the correct position to place the player
            List<RoomInstanceGrid2D> roomInstances = _levelInfo.RoomInstances;
            player.transform.position = roomInstances[1].RoomTemplateInstance.transform.position;
            yield break;
        }
    }
}