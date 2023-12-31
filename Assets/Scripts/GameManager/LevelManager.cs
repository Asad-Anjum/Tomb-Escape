﻿using System.Collections;
using Edgar.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace GameManager
{
    public class LevelManager : MonoBehaviour
    {
        public GameObject loadingCanvas;
        private DungeonGeneratorGrid2D _generator;
        private LevelInfoGrid2D _levelInfo;


        private void Start()
        {
            LoadLevel();
        }


        void LoadLevel()
        {
            // Show loading screen
            ShowLoadingScreen("Dungeon", "loading...");
            StartCoroutine(GenerateLevel());
        }


        private IEnumerator GenerateLevel()
        {
            yield return new WaitForSeconds(0.1f);
            _generator = transform.GetComponent<DungeonGeneratorGrid2D>();
            bool success = true;
            try
            {
                _generator.Generate();
            }
            catch (TimeoutException)
            {
                Destroy(GameObject.Find("Generated Level"));
                success = false;
            }
            finally
            {
                if (!success)
                {
                    StartCoroutine(GenerateLevel());
                }
            }


            if (success)
            {
                // GameObject.Find("Golbal Light").GetComponent<Light2D>();
                // change layername of walls... Why does this have to be a pain?
                GameObject generatedLevel = GameObject.Find("Generated Level");
                GameObject wallsGameObject =
                    generatedLevel.transform.Find("Tilemaps").transform.Find("Walls").gameObject;
                wallsGameObject.layer = LayerMask.NameToLayer("Walls");
                Debug.Log("walls layer applied");

                // start calculation A* WHY IS IT NOT SCANNING>??????
                //AstarPath.active.Scan();
                //Debug.Log("scanned...");

                yield return null;
                HideLoadingScreen();
            }
        }


        /// <summary>
        /// Hide loading screen.
        /// </summary>
        protected void HideLoadingScreen()
        {
            var canvas = loadingCanvas;
            canvas.SetActive(false);
            var loadingImage = canvas.transform.Find("LoadingImage")?.gameObject;

            if (loadingImage != null)
            {
                loadingImage.SetActive(false);
            }
        }

        /// <summary>
        /// Show loading screen with primary and secondary text.
        /// </summary>
        /// <param name="primaryText"></param>
        /// <param name="secondaryText"></param>
        protected void ShowLoadingScreen(string primaryText, string secondaryText)
        {
            var canvas = loadingCanvas;
            canvas.SetActive(true);
            var loadingImage = canvas.transform.Find("LoadingImage")?.gameObject;
            var primaryTextComponent =
                loadingImage?.transform.Find("PrimaryText")?.gameObject.GetComponent<TextMeshProUGUI>();
            var secondaryTextComponent = loadingImage?.transform.Find("SecondaryText")?.gameObject
                .GetComponent<TextMeshProUGUI>();

            if (loadingImage != null)
            {
                loadingImage.SetActive(true);
            }

            if (primaryTextComponent != null)
            {
                primaryTextComponent.text = primaryText;
            }

            if (secondaryTextComponent != null)
            {
                secondaryTextComponent.text = secondaryText;
            }
        }
    }
}