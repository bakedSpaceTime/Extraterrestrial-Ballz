using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject gameOverlay;
    public GameObject pauseMenu;
   
    public void MainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("level1", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        gameOverlay.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        gameOverlay.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
