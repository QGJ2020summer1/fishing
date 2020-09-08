using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    Text ui_scoreText;

    void Start()
    {
        ui_scoreText = GetComponent<Text>();
        ui_scoreText.text = MainSceneManager.score.ToString();
        Debug.Log(string.Join(",", MainSceneManager.catchedFishNum));
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            ResetParam();
            SceneManager.LoadScene("title");
        }
    }

    void ResetParam() {
        MainSceneManager.score = 0;
    }
}
