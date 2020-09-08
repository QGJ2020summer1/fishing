using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour {

    public static ScoreCounter instance;
    Text ui_scoreText;

    static int[] normalScoreArray = {200, 500, 1000};
    static int[] rareScoreArray = {500, 800, 1500};

    int score;


    void Start() {
        ui_scoreText = GetComponent<Text>();
        instance = this;
        score = 0;
        UpdateView();
    }

    public void AddScore(FishSize size, bool isRare) {
        score += DecideScoreValue(size, isRare);
        UpdateView();
    }

    void UpdateView() {
        ui_scoreText.text = string.Format("{0:000}", score);
    }

    int DecideScoreValue(FishSize size, bool isRare) {
        int index = (int)size;
        return isRare ? rareScoreArray[index] : normalScoreArray[index];
    }

    public int GetScore() {
        return score;
    }

}
