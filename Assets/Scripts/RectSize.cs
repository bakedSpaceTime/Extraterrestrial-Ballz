using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RectSize : MonoBehaviour
{
    public int pixelCount;
    // Used to make the content rect in the level menu viewport the correct size
    // pixelCount is the number of pixels each level button takes up, including spacing
    void Start()
    {
        int levelCount = SceneManager.sceneCountInBuildSettings - 2;
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, levelCount * pixelCount);
    }
}
