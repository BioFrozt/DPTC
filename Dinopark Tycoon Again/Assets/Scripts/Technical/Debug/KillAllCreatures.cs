using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllCreatures : MonoBehaviour
{
    public void order66()
    {
        SendToast.log("start of resetting game");
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Creature"))
            Destroy(go);

        SendToast.log("after removing creatures");

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Paddock"))
        {
            go.GetComponent<PaddockScript>().setSecurityLevel(0);
        }
        AssetManager am = GameObject.Find("GameLogic").GetComponent<AssetManager>();
        SendToast.log("after resetting paddocks");
        am.setTotalMoney(333);
        am.setFoodByType(FoodType.HERBIVOROUS, 300);
        am.setFoodByType(FoodType.CARNIVOROUS, 200);
        SendToast.pop("end of resetting game");
    }
}
