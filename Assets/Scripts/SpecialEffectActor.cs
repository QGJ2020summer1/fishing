using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialEffectActor : MonoBehaviour {

    public static SpecialEffectActor instance;
    
    List<Action> effectList;

    void Start() {
        instance = this;
        effectList = new List<Action>(){
            Effect_SmallAngel, Effect_MiddleAngel, Effect_BigAngel,
            Effect_SmallDevil, Effect_MiddleDevil, Effect_BigDevil,
        };
    }

    public void StartEffect(FishType type, FishSize size) {
        int index = (int)type * 3 + (int)size;
        effectList[index]();
    }


    void Effect_SmallAngel() {
        Debug.Log("small angel");
    }

    void Effect_MiddleAngel() {
        Debug.Log("middle angel");
    }

    void Effect_BigAngel() {
        Debug.Log("big angel");
    }
    
    void Effect_SmallDevil() {
        Debug.Log("small devil");
    }

    void Effect_MiddleDevil() {
        Debug.Log("middle devil");
    }
    
    void Effect_BigDevil() {
        Debug.Log("big devil");
    }

}
