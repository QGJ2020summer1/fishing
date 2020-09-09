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
            SoundPlayer.instance.PlaySoundEffect(SoundEffectType.hari);
            Invoke("AddScore", 1.0f);

            
            //Debug.Log("接触");
        }
    }
    
    void AddScore()
    {
        var param = GetComponent<FishParam>();
        ScoreCounter.instance.AddScore(param.type, param.size, param.isRare);
            SoundPlayer.instance.PlaySoundEffect(SoundEffectType.getScore);
            FishPowerHandler.instance.ChangeFishPower(param.type, param.size);
            if(param.isRare) {
                SpecialEffectActor.instance.StartEffect(param.type, param.size);
            }
            Destroy (this.gameObject);

    }


    
}