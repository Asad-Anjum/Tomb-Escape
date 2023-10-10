using UnityEngine;
using UnityEngine.SceneManagement;

public class winButton : MonoBehaviour
{
    private GameController gc;

    void Start()
    {
        gc = Camera.main.GetComponent<GameController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && gc.escaping)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
