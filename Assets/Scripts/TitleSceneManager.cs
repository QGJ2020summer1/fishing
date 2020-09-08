using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            StartCoroutine(GoToMaincoroutine());
        }
    }

    IEnumerator GoToMaincoroutine() {
        SoundPlayer.instance.PlaySoundEffect(SoundEffectType.gameStart);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("main");
    }
}
