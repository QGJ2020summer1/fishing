using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour {

    public static int score;        //ゲーム終了時のスコア
    public static List<int> catchedFishNum = new List<int>(){0, 0, 0, 0, 0, 0};

    bool isStopped;

    public static MainSceneManager instance;

    void Start() {
        instance = this;
        isStopped = false;
        Invoke("StartGame", 0.1f);
    }

    void Update() {
        if(TimeCounter.instance.GetTime() >= TimeCounter.instance.startTimeSecond - 50) return;
        var power = FishPowerHandler.instance.GetPowerLevel();
        if(power > 0) SoundPlayer.instance.ChangeMainBackGroundMusic(0, 1, 0);
        else if(power < 0) SoundPlayer.instance.ChangeMainBackGroundMusic(0, 0, 1);
    }

    void StartGame() {
        SoundPlayer.instance.PlayMainBackGroundMusic();
    }

    public void FinishGame(int score, List<int> catchedFishNum) {
        MainSceneManager.score = score;
        MainSceneManager.catchedFishNum = catchedFishNum;
        StartCoroutine(FinishGameCoroutine());
    }

    IEnumerator FinishGameCoroutine() {
        PauseGame();
        SoundPlayer.instance.PlaySoundEffect(SoundEffectType.gameEnd);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("result");
    }

    public void PauseGame() {
        isStopped = true;
    }

    public void RestartGame() {
        isStopped = false;
    }

    public bool isPausedGame() {
        return isStopped;
    }

    public void StopGame() {
        SceneManager.LoadScene("title");
    }
}
