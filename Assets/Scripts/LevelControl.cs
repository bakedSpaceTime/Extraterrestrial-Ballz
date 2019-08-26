using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    public bool createLevelButtons = false;
    public Button prefab;
    public GameObject buttonParent;

    private int nextLevel;
    private int MenuScenes = 3;
   
    private void Start()
    {
        PlayerPrefs.SetInt("1", 1);

        if (createLevelButtons)
        {
            CreateLevelButtons();
        }
    }

    private void OnApplicationQuit()
    {
        if (Application.isEditor)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void OnTriggerEnter(Collider obj)
    {
        PlayNextLevel(obj);
    }

    private void PlayNextLevel(Collider obj)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevel = currentLevel + 1;

        if (obj.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(nextLevel.ToString(), 1);
            PlayLevel(nextLevel);
        }
    }

    public void PlayLevel(int level)
    {
        if(PlayerPrefs.GetInt(level.ToString(), -1) == 1)
        {
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }
    }

    private void CreateLevelButtons()
    {
        int levelCount = SceneManager.sceneCountInBuildSettings - MenuScenes;
        int i;

        for (i = 1; i <= levelCount; i++)
        {
            AddLevelButton(i);
        }

        prefab.gameObject.SetActive(false);
    }

    private void AddLevelButton(int levelnum)
    {
        string name = "Level " + levelnum.ToString();
        Button button = Instantiate(prefab);
        button.name = name;

        Text text = button.GetComponentInChildren<Text>();
        if (text)
            text.text = name;

        button.transform.SetParent(buttonParent.transform, false);
       
        button.onClick.AddListener(delegate { PlayLevel(levelnum); });
    }
}