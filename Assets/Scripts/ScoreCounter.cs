using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour {

    public static ScoreCounter instance;
    Text ui_scoreText;

    int score;

    void Start() {
        ui_scoreText = GetComponent<Text>();
        instance = this;
        score = 0;
        UpdateView();
    }

    public void AddScore(FishSize size) {

        score++;
        UpdateView();
    }

    void UpdateView() {
        ui_scoreText.text = string.Format("{0:000}", score);
    }

}
