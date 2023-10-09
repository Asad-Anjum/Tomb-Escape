using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInitialPosition : MonoBehaviour
    {
        private void Start()
        {
            GameObject player = GameObject.Find("Player");
            player.transform.position = transform.position;
        }
    }
}