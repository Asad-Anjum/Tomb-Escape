using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenFunction : MonoBehaviour
{
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
