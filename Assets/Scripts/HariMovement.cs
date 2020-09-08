using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariMovement : MonoBehaviour {

    [SerializeField] float waitPosY;        //針の初期位置
    [SerializeField] float pullPosY;        //針を引っ張りきった時の位置
    [SerializeField] float pullSpeed;       //針を引っ張る速度
    [SerializeField] float fallSpeed;       //針を落とす速度
    [SerializeField] float waitTimeSecond;  //針を引っ張りきった状態で待つ時間

    public enum HariState {
        wait, pull, fall
    }

    HariState state;

    void Start() {
        state = HariState.wait; 
        transform.position = new Vector3(transform.position.x, waitPosY, 0);
    }

    void Update() {
        if(Input.GetMouseButtonDown(0) && state == HariState.wait){
            StartCoroutine(PullCoroutine());
            
        }
    }

    IEnumerator PullCoroutine() {
        state = HariState.pull;
        var pullFrameCount = Mathf.Abs(waitPosY - pullPosY) / pullSpeed;
        for(int i = 0; i < pullFrameCount; i++){
            transform.position += new Vector3(0, pullSpeed, 0);
            yield return null;
        }

        yield return new WaitForSeconds(waitTimeSecond);

        state = HariState.fall;
        var fallFrameCount = Mathf.Abs(waitPosY - pullPosY) / fallSpeed;
        for(int i = 0; i < fallFrameCount; i++){
            transform.position -= new Vector3(0, fallSpeed, 0);
            yield return null;
        }

        state = HariState.wait;
    }

    public bool isCatchable() {
        return state == HariState.pull;
    }

}
