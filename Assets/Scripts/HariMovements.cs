using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariMovements : MonoBehaviour
{
    bool isPulling;
    bool isFalling;
    public float backPosY;
    float initialPosY;
    public float pullSpeed;
    public float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isPulling = false;   
        initialPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isPulling && !isFalling){
            isPulling = true;
        }

        if(isPulling) {
            transform.position += new Vector3(0, pullSpeed, 0);
            if(transform.localPosition.y >= backPosY) {
                isPulling = false;
                isFalling = true;
            }
        }
        if(isFalling){
            transform.position -= new Vector3(0, fallSpeed, 0);
            if(transform.localPosition.y <= initialPosY) {
                isFalling = false;
            }
        }
    }
}
