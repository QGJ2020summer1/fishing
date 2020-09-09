using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int startTimeSecond;       //ゲームの時間（秒）
    int timeLimit;
    Text ui_timeLimitText;

    public static TimeCounter instance;

    void Start() {
        ui_timeLimitText = GetComponent<Text>();
        timeLimit = startTimeSecond;
        UpdateView();
        StartCoroutine(TimeCountCoroutine());
        instance = this;
    }


    IEnumerator TimeCountCoroutine() {
        while(timeLimit > 0) {
            yield return new WaitForSeconds(1);
            if(MainSceneManager.instance.isPausedGame()) continue;
            timeLimit--;
            UpdateView();
        }
        MainSceneManager.instance.FinishGame(ScoreCounter.instance.GetScore(), FishPowerHandler.instance.GetCatchedFishNum());
    }

    void UpdateView() {
        ui_timeLimitText.text = timeLimit.ToString();
    }

    public int GetTime() {
        return timeLimit;
    }
}
