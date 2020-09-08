using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariFishRendo : MonoBehaviour
{
    public FishSize size;
    public FishType type;
    public bool isRare;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        string tagName = collision.gameObject.tag;
        if (tagName == "Hari")
        {
            GameObject obj = collision.gameObject;
            transform.parent = obj.transform;
            GetComponent<FishMovement>().enabled = false;
        
            Invoke("AddScore", 1.0f);

            
            //Debug.Log("接触");
        }
    }
    

    void AddScore()
    {
        ScoreCounter.instance.AddScore(size, isRare);
            FishPowerHandler.instance.ChangeFishPower(type, size);
            Destroy (this.gameObject);

    }


    
}