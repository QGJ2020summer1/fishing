using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWindowViewer : MonoBehaviour {

    [SerializeField] GameObject window;

    public void ChangeWindowActiveMode(bool isActive) {
        window.SetActive(isActive);
        if(isActive) {
            MainSceneManager.instance.PauseGame();
        }
        else {
            MainSceneManager.instance.RestartGame();
        }
    }
    public void BackToTitle() {
        MainSceneManager.instance.StopGame();
    }

}
