using System.Collections;
using System.Collections.Generic;
using Edgar.Unity;
using UnityEngine;
using Pathfinding;

namespace GameManager
{
    public class LevelManager : MonoBehaviour
    {
        private DungeonGeneratorGrid2D _generator;
        private LevelInfoGrid2D _levelInfo;
        public GameObject player;
        public AstarPath _pathfinder;

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

            // start calculation A*
            _pathfinder.Scan();

            yield break;
        }
    }
}