using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishPowerHandler : MonoBehaviour {

    public static FishPowerHandler instance;
    int power;      // + -> 天使    - -> 悪魔
    [SerializeField] int powerMaxValue; // powerの絶対値の最大

    static int[] powerValueArray = {1, 3, 5};
    List<int> catchedFishNum;
    int prevPower;

    [SerializeField] List<Sprite> sp_tenbinList;
    [SerializeField] SpriteRenderer tenbinImage; 

    void Start() {
        instance = this;
        catchedFishNum = new List<int>(){0, 0, 0, 0, 0, 0};
    }

    public void ChangeFishPower(FishType type, FishSize size) {
        int value = DecideScoreValue(type, size);
        power = Mathf.Min(Mathf.Max(power + value, -powerMaxValue), powerMaxValue);
        if(prevPower != power) OnChangedPower(prevPower, power);
        prevPower = power;
        UpdateView();
        int index = (int)type * 3 + (int)size;
        catchedFishNum[index]++;
    }

    void UpdateView() {
        int powerLevel = GetPowerLevel();
        tenbinImage.sprite = sp_tenbinList[powerLevel + 3];
    }

    public int GetPowerLevel() {
        return power / 5;
    }

    int DecideScoreValue(FishType type, FishSize size) {
        int index = (int)size;
        return powerValueArray[index] * (type == FishType.angel ? 1 : -1);
    }

    public List<int> GetCatchedFishNum() {
        return catchedFishNum;
    }

    void OnChangedPower(int prevPower, int power) {
    }

}
