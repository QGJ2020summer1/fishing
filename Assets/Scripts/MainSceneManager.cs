using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour {

    public static int score;        //ゲーム終了時のスコア

    public static MainSceneManager instance;

    void Start() {
        instance = this;
    }

    public void FinishGame(int score) {
        MainSceneManager.score = score;
        StartCoroutine(FinishGameCoroutine());
    }

    IEnumerator FinishGameCoroutine() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("result");
    }

}
