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

    bool isBuffed;


    void Start() {
        ui_scoreText = GetComponent<Text>();
        instance = this;
        score = 0;
        isBuffed = false;
        UpdateView();
    }

    public void AddScore(FishType type, FishSize size, bool isRare) {
        score += DecideScoreValue(size, isRare);
        if(isBuffed && type == FishType.angel) {
            score += 300;
        }
        UpdateView();
    }

    public void AddScoreFixed(int score) {
        score += score;
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

    IEnumerator ScoreBuffCoroutine() {
        isBuffed = true;
        yield return new WaitForSeconds(10);
        isBuffed = false;
    }

}
