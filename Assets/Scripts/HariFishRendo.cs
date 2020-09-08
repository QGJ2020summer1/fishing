using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariFishRendo : MonoBehaviour
{
    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        string tagName = collision.gameObject.tag;
        if (tagName == "Hari")
        {
            GameObject obj = collision.gameObject;
            transform.parent = obj.transform;
            GetComponent<FishMovement>().enabled = false;
            //Debug.Log("接触");
        }
    }


    
}