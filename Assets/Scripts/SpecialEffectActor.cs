using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpecialEffectActor : MonoBehaviour {

    public static SpecialEffectActor instance;
    
    List<Action> effectList;

    public Text ui_effectText;

    void Start() {
        instance = this;
        effectList = new List<Action>(){
            Effect_SmallAngel, Effect_MiddleAngel, Effect_BigAngel,
            Effect_SmallDevil, Effect_MiddleDevil, Effect_BigDevil,
        };
        ui_effectText = GetComponent<Text>();
        Debug.Log(ui_effectText);

    }

    public void StartEffect(FishType type, FishSize size) {
        int index = (int)type * 3 + (int)size;
        effectList[index]();
    }

    IEnumerator ShowEffectmessage(string message) {
        Debug.Log(ui_effectText);
        ui_effectText.text = message;
        yield return new WaitForSeconds(2);
        ui_effectText.text = "";
    }


    void Effect_SmallAngel() {
        var container = GameObject.Find("fishes").transform;
        for(int i = 0; i < container.childCount; i++) {
            var fish = container.GetChild(i);
            var param = fish.GetComponent<FishParam>();
            if(param.type == FishType.devil && param.size == FishSize.small) {
                fish.GetComponent<FishAppearance>().Transformation(FishType.angel, FishSize.small);
            }
        }
        StartCoroutine(ShowEffectmessage("小悪魔浄化！"));
    }

    void Effect_MiddleAngel() {
        
        StartCoroutine(ShowEffectmessage("天使得点増加！"));
    }

    void Effect_BigAngel() {
        var container = GameObject.Find("fishes").transform;
        for(int i = 0; i < container.childCount; i++) {
            var fish = container.GetChild(i);
            var param = fish.GetComponent<FishParam>();
            if(param.type == FishType.devil) {
                fish.GetComponent<FishAppearance>().DisAppear();
                ScoreCounter.instance.AddScoreFixed(300);
            }
        }
        StartCoroutine(ShowEffectmessage("悪魔消滅！"));
    }
    
    void Effect_SmallDevil() {
        var container = GameObject.Find("fishes").transform;
        for(int i = 0; i < container.childCount; i++) {
            var fish = container.GetChild(i);
            var param = fish.GetComponent<FishParam>();
            if(param.type == FishType.angel && param.size == FishSize.small) {
                fish.GetComponent<FishAppearance>().Transformation(FishType.devil, FishSize.small);
            }
        }
        StartCoroutine(ShowEffectmessage("小天使堕天！"));
    }

    void Effect_MiddleDevil() {
        var container = GameObject.Find("fishes").transform;
        for(int i = 0; i < container.childCount; i++) {
            var fish = container.GetChild(i);
            var param = fish.GetComponent<FishParam>();
            if(param.type == FishType.devil) {
                fish.GetComponent<FishAppearance>().Transformation(FishType.devil, (FishSize)Mathf.Min(((int)param.size) + 1, (int)FishSize.big));
            }
        }
        StartCoroutine(ShowEffectmessage("悪魔進化！"));
    }
    
    void Effect_BigDevil() {
        FishRushProducer.instance.ProduceRush(FishType.devil, 10);
        StartCoroutine(ShowEffectmessage("悪魔襲来！"));
    }

}
