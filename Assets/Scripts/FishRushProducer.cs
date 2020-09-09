using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRushProducer : MonoBehaviour
{
    [SerializeField] List<GameObject> angelList, devilList;
    public static FishRushProducer instance;

    [SerializeField] float spawnPointMinY, spawnPointMaxY;

    [SerializeField] float spawnPointX_abs;


    void Start() {
        instance = this;
        StartCoroutine(RushCoroutine());
    }


    void Update() {

    }

    public void ProduceRush(FishType type, int num) {
        List<GameObject> list = type == FishType.angel ? angelList : devilList;
        for(int i = 0; i < num; i++) {
            int index = Random.Range(0, list.Count);
            float posY = (spawnPointMaxY - spawnPointMinY) * ((float)i / num) + spawnPointMinY;
            Vector3 spawnPos = new Vector3(type == FishType.angel ? spawnPointX_abs : -spawnPointX_abs, posY, 0);
            Instantiate(list[index], spawnPos, Quaternion.identity);
        }

    }

    IEnumerator RushCoroutine() {
        while(true) {
            int powerLevel = FishPowerHandler.instance.GetPowerLevel();
            if(powerLevel >= 2) ProduceRush(FishType.devil, 5);
            if(powerLevel <= -2) ProduceRush(FishType.angel, 5);
            yield return new WaitForSeconds(10);
        }
    }





}
