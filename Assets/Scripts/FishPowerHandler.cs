using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishPowerHandler : MonoBehaviour {

    public static FishPowerHandler instance;
    int power;      // + -> 天使    - -> 悪魔
    [SerializeField] int powerMaxValue; // powerの絶対値の最大

    Text ui_powerLevelText;

    void Start() {
        instance = this;
        ui_powerLevelText = GetComponent<Text>();
    }

    public void ChangeFishPower() {
        if(Mathf.Abs(power) < powerMaxValue) {
            power++;
        }
        UpdateView();
    }

    void UpdateView() {
        int powerLevel = GetPowerLevel();
        ui_powerLevelText.text = powerLevel.ToString();        
    }

    public int GetPowerLevel() {
        return power / 5;
    }

}
