using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("OpeningCinematic");
    }

    public void Replay()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Back2MainMenu()
    {
        SceneManager.LoadScene("MainMenu(Finished");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
