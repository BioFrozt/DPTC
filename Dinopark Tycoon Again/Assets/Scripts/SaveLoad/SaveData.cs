using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveData
{
    public double money;
    public int herbivorousFood;
    public int carnivorousFood;
    public CreatureSaveData[] packagedCreatures;
    public PaddockSaveData[] packagedPaddocks;
    public Egg[] eggs;

    public long lastTimeSave;

    public SaveData()
    {
        //SendToast.log("start of savedata constructor");
        AssetManager am = GameObject.Find("GameLogic").GetComponent<AssetManager>();
        money = am.getTotalMoney();
        herbivorousFood = am.getFoodByType(FoodType.HERBIVOROUS);
        carnivorousFood = am.getFoodByType(FoodType.CARNIVOROUS);

        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        packagedCreatures = new CreatureSaveData[creatures.Length];

        GameObject[] paddocks = GameObject.FindGameObjectsWithTag("Paddock");
        packagedPaddocks = new PaddockSaveData[paddocks.Length];

        eggs = new Egg[GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs.Count];

        for (int i = 0; i < packagedCreatures.Length; i++)
        {
            packagedCreatures[i] = creatures[i].GetComponent<CreatureScript>().getCreatureSaveData();
        }
        for (int i = 0; i < packagedPaddocks.Length; i++)
        {
            packagedPaddocks[i] = paddocks[i].GetComponent<PaddockScript>().getPaddockSaveData();
        }
        for (int i = 0; i < GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs.Count; i++)
        {
            eggs[i] = (Egg)GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs[i];
            //SendToast.log("egg saved: " + eggs[i].speciesNumber + ", " + eggs[i].startTime);
        }

        lastTimeSave = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        //SendToast.log("end of savedata constructor");
    }
}
