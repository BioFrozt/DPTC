using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveLoad
{

    public static void saveState(string saveMessage)
    {
        //SendToast.log("start of savestate: " + General.getNiceTimestamp());

            SaveData data = new SaveData();
            saveSaveData(data);
    }

    public static SaveData getSaveData()
    {
        SendToast.log("start of getSaveData");
        string path = Application.persistentDataPath + "/save.fun";
        if (!File.Exists(path))
        {
            SendToast.pop("ERROR: Unable to retrieve SaveData in getSaveDataMethod");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        SaveData data = formatter.Deserialize(stream) as SaveData;
        stream.Close();
        SendToast.log("end of getSaveData (before return)");
        return data;

    }

    public static void saveSaveData(SaveData sd)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, sd);
        stream.Close();
    }

    public static void loadState()
    {
        SendToast.log("start of loadstate " + General.getNiceTimestamp());
        SaveData data = getSaveData();

        AssetManager am = GameObject.Find("GameLogic").GetComponent<AssetManager>();
        am.setTotalMoney(data.money);
        am.setFoodByType(FoodType.HERBIVOROUS, data.herbivorousFood);
        am.setFoodByType(FoodType.CARNIVOROUS, data.carnivorousFood);


        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Creature")) // shouldnt trigger
            GameObject.Destroy(go);

        //SendToast.log("Before unpacking creatures");
        foreach (CreatureSaveData csd in data.packagedCreatures)
        {
            GameObject newCreature = GameObject.Instantiate(GameObject.Find("GameLogic").
                GetComponent<CreatureList>().getCreatureByID(csd.speciesNumber));
            newCreature.GetComponent<CreatureScript>().loadFromCreatureSaveData(csd);
        }
        //SendToast.log("Before unpacking paddocks");

        foreach (PaddockSaveData psd in data.packagedPaddocks)
        {

            foreach (GameObject paddock in GameObject.FindGameObjectsWithTag("Paddock"))
                if (paddock.transform.position.x == psd.xPos && paddock.transform.position.z == psd.zPos)
                {
                    paddock.GetComponent<PaddockScript>().loadFromPaddockSaveData(psd);
                }
        }
        foreach (Egg e in data.eggs)
        {
            GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs.Add(e);
        }

        checkForInactivity(data);

        SendToast.log("End of loadState method");
    }

    public static void checkForInactivity(SaveData data)
    {

        if (data.lastTimeSave == 0)
        {
            SendToast.pop("lasttimesave =  0");
        }
        else
        {
            long currentTime = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            long timeAway = currentTime - data.lastTimeSave;
            if (timeAway > 10)
                handleTimeAway((int)timeAway);
        }

    }

    public static void handleTimeAway(int timeAway)
    {
        AssetManager am = GameObject.Find("GameLogic").GetComponent<AssetManager>();
        SendToast.pop("You were away for " + timeAway + " seconds, adding " +timeAway * am.getPricePerTicket() + " money");
        am.adjustMoney(timeAway * am.getPricePerTicket());
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Creature"))
        {
            go.GetComponent<CreatureScript>().adjustFoodLevel(-1 * timeAway);
        }
    }
}
