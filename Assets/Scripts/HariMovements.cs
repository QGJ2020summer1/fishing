using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariMovements : MonoBehaviour {

    [SerializeField] float pullPosY;
    [SerializeField] float waitPosY;
    [SerializeField] float pullSpeed;
    [SerializeField] float fallSpeed;
    [SerializeField] float waitTimeSecond;

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

}
