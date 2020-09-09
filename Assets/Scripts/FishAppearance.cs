using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAppearance : MonoBehaviour
{
    FishParam param;
    [SerializeField] List<Sprite> fishSpriteList;

    void Start() {
        param = GetComponent<FishParam>();
    }

    public void DisAppear() {
        Destroy(gameObject);
    }

    public void Transformation(FishType type, FishSize size) {
        param.type = type;
        param.size = size;
        int index = (int)type * 3 + (int)size;
        GetComponent<SpriteRenderer>().sprite = fishSpriteList[index];
    }


}
