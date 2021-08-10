using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySelectedCreature : MonoBehaviour
{
    public GameObject shopPanel;
    public void buySelectedCreature()
    {
        int speciesNumber = shopPanel.GetComponent<HighlightSelectedShopCreature>().selectedSpeciesNumber;
        Species s = SpeciesManager.getSpeciesByNumber(speciesNumber);
        if (s == null)
        {
            SendToast.pop("No species selected; error in BuySelectedCreature");
            return;
        }
        AssetManager am = GameObject.Find("GameLogic").GetComponent<AssetManager>();
        if (s.cost > am.getTotalMoney())
        {
            SendToast.pop("Not enough money to buy " + s.speciesName);
            return;
        }
        EggDatabase ed = GameObject.Find("GameLogic").GetComponent<EggDatabase>();

        ed.eggs.Add(new Egg(speciesNumber, (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds));
        am.adjustMoney(-s.cost);

    }
}
