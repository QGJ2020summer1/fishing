using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour {

    public static int score;        //ゲーム終了時のスコア
    public List<int> catchedFishNum = new List<int>(){0, 0, 0, 0, 0, 0};

    bool isStopped;

    public static MainSceneManager instance;

    void Start() {
        instance = this;
        isStopped = false;
    }

    public void FinishGame(int score) {
        MainSceneManager.score = score;
        
        StartCoroutine(FinishGameCoroutine());
    }

    IEnumerator FinishGameCoroutine() {
        PauseGame();
        yield return new WaitForSeconds(2);
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
