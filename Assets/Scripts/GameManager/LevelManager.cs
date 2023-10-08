using Edgar.Unity;
using UnityEngine;

namespace GameManager
{
    public class LevelManager : MonoBehaviour
    {
        private DungeonGeneratorGrid2D _generator;
        
        private void Awake()
        {
            _generator = GameObject.Find("Dungeon Generator").GetComponent<DungeonGeneratorGrid2D>();
        }

        private void Start()
        {
            // GenerateLevel();
        }

        private void GenerateLevel()
        {
            // Start the generator coroutine
            StartCoroutine(_generator.GenerateCoroutine());
        }
    }
}