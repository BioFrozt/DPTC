using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSelectedCreature : MonoBehaviour
{
    public void feedSelectedCreature(int amount)
    {
        if (General.selectedEntity.tag != "Creature")
        {
            SendToast.log("attempted to feed, but selected entity is not a creature");
            return;
        }

        CreatureScript cs = General.selectedEntity.GetComponent<CreatureScript>();
        AssetManager am = GameObject.Find("GameLogic").GetComponent<AssetManager>();

        if (am.getFoodByType(cs.species.foodType) < amount)
        {
            SendToast.log("not enough food to feed; wanted: " + amount + ", remaining: " 
                + am.getFoodByType(cs.species.foodType) + ", type: " + cs.species.foodType);
            return;
        }

        if (cs.foodLevel + amount > cs.species.maxFoodLevel)
        {
            SendToast.pop("Cannot overfeed this creature!");
            return;
        }

        cs.adjustFoodLevel(amount);
        cs.updatePanel();
        am.adjustFood(cs.species.foodType, -amount);
    }

    public void completelyFeedSelectedCreature()
    {
        if (General.selectedEntity.tag != "Creature")
        {
            SendToast.log("attempted to feed, but selected entity is not a creature");
            return;
        }
        CreatureScript cs = General.selectedEntity.GetComponent<CreatureScript>();
        int amount = cs.species.maxFoodLevel - cs.foodLevel;

        feedSelectedCreature(amount);

    }
}
