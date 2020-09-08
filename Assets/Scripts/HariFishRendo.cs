using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariFishRendo : MonoBehaviour
{
    public GameObject parent;
    public GameObject child;
    
    public void OnTriggerEnter2d(Collider collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Cube")
        {
            child = collision.gameObject;
            child.transform.parent = parent.transform;
            //Debug.Log("接触");
        }
    }
  void OnTriggerEnter(Collider other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Hari"))
        {
            True1.GetComponent<FishMovement>().enabled = false;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        child.transform.parent = null;
    }
}