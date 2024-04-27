using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Awake()
    {
        GameData.Instance.OnDeath.AddListener(EndGame2);
        gameObject.SetActive(false);
    }

    public void EndGame2()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
