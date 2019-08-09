using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    //public bool resetPrefs;
    
    public bool createLevelButtons = false;
    public Button prefab;
    public GameObject buttonParent;

    private int nextLevel;
    //private bool isAndroid = Application.isMobilePlatform;

    private void Start()
    {
        //UpdateLevelUnlock();
        //isAndroid = Application.isMobilePlatform;
        PlayerPrefs.SetInt("1", 1);

        if (createLevelButtons)
        {
            CreateLevelButtons();
        }

        //Debug.Log(PlayerPrefs.GetInt("1"));
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

    /*
    private void UpdateLevelUnlock()
    {
        int levelCount = SceneManager.sceneCountInBuildSettings - 2;

        if (Application.isEditor)
        {
            SetLevelUnlock(1, levelCount);
        }
        else if (isAndroid)
        {
           SetLevelUnlock(2, levelCount);
        }
        //Debug.Log(levelCount);

        
    }

    private void SetLevelUnlock(int applicationMode, int levelCount)
    {
        
        if(!(applicationMode == 2 && isAndroid))
        {
            return;
        }
        
        //Level 1 is automatically unklocked
        PlayerPrefs.SetInt("1", applicationMode);

        for (int i = 2; i <= levelCount; i++)
        {
            if (!PlayerPrefs.HasKey(i.ToString()))
            {
                PlayerPrefs.SetInt(i.ToString(), -1);
            }
           }
            else
            {
                PlayerPrefs.SetInt(i.ToString(), applicationMode);
            }
            //
        }
 */

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
        /*
        if ((PlayerPrefs.GetInt(level.ToString()) == 1) || (isAndroid && PlayerPrefs.GetInt(level.ToString()) == 2))
        {
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }
        */
        if(PlayerPrefs.GetInt(level.ToString(), -1) == 1)
        {
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }
    }

    private void CreateLevelButtons()
    {
        int levelCount = SceneManager.sceneCountInBuildSettings - 2;
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
       // button.transform.position = Vector3.zero;

        button.onClick.AddListener(delegate { PlayLevel(levelnum); });
    }
}