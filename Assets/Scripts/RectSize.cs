using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RectSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int levelCount = SceneManager.sceneCountInBuildSettings - 2;
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, levelCount * 215);
    }
}
