using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        LevelLoader.instance.LoadLevel();
        AudioManager.instance.Play("Click");
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.instance.Play("Click");
    }

}
