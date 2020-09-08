using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishPowerHandler : MonoBehaviour {

    public static FishPowerHandler instance;
    int power;      // + -> 天使    - -> 悪魔
    [SerializeField] int powerMaxValue; // powerの絶対値の最大

    static int[] powerValueArray = {1, 3, 5};
    Text ui_powerLevelText;

    void Start() {
        instance = this;
        ui_powerLevelText = GetComponent<Text>();
    }

    public void ChangeFishPower(FishType type, FishSize size) {
        int value = DecideScoreValue(type, size);
        power = Mathf.Min(Mathf.Max(power + value, -powerMaxValue), powerMaxValue);
        UpdateView();
    }

    void UpdateView() {
        int powerLevel = GetPowerLevel();
        ui_powerLevelText.text = powerLevel.ToString();        
    }

    public int GetPowerLevel() {
        return power / 5;
    }

    int DecideScoreValue(FishType type, FishSize size) {
        int index = (int)size;
        return powerValueArray[index] * (type == FishType.angel ? 1 : -1);
    }

}
