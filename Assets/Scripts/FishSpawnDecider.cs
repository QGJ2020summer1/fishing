using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnDecider : MonoBehaviour
{
    public static FishSpawnDecider instance;




    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public int DecideFishIndex() {
        int type = Random.Range(0, 2);
        int timeRest = TimeCounter.instance.GetTime();
        int timeMax = TimeCounter.instance.startTimeSecond;
        int size;
        if(timeRest >= timeMax - 10) size = 0;
        else if(timeRest >= timeMax - 50) size = Random.Range(0, 2);
        else size = Random.Range(0, 3);
        return type * 3 + size;
    }

}
