using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenFunction : MonoBehaviour
{
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("Title");
    }
}