using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void EndGame()
    {
        Time.timeScale = 0;
    }

    public void TryAgain()
    {
        // TODO: RESTART SCENE
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
