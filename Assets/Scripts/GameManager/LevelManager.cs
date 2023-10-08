using Edgar.Unity;
using Edgar.Unity.Examples;
using Edgar.Unity.Examples.Example1;
using UnityEngine;
using System.Collections;

namespace GameManager
{
    public class LevelManager : GameManagerBase<Example1GameManager>
    {
        private void Start()
        {
            LoadNextLevel();
        }

        public override void LoadNextLevel()
        {
            // Find the generator runner
            var generator = GameObject.Find("Dungeon Generator").GetComponent<DungeonGeneratorGrid2D>();

            // Start the generator coroutine
            StartCoroutine(GeneratorCoroutine(generator));
        }


        private IEnumerator GeneratorCoroutine(DungeonGeneratorGrid2D generator)
        {
            generator.Generate();
            yield return null;
        }
    }
}