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
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
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

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Single);
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

    public void CalibrateAcceleration()
    {
        Vector3 baseAcceleration = Input.acceleration;

        PlayerPrefs.SetFloat("ACalX", baseAcceleration.x);
        PlayerPrefs.SetFloat("ACalY", baseAcceleration.y);
        //PlayerPrefs.SetFloat("ACalz", 0.0f);
    }

    public void ResetAccelerationCalibration()
    {
        PlayerPrefs.SetFloat("ACalX", 0.0f);
        PlayerPrefs.SetFloat("ACalY", 0.0f);
    }
}
