using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) {
            var container = GameObject.Find("fishes").transform;
            for(int i = 0; i < container.childCount; i++) {
                var fish = container.GetChild(i);
                var param = fish.GetComponent<FishParam>();
                if(param.type == FishType.devil && param.size == FishSize.small) {
                    fish.GetComponent<FishAppearance>().Transformation(FishType.angel, FishSize.small);
                }
            }
        }
    }
}
