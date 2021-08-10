using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelectedPaddock : MonoBehaviour
{
    public void attemptToUpgradeSelectedPaddock()
    {
        if (General.selectedEntity.tag != "Paddock")
        {
            SendToast.pop("Paddock not selected but tried to upgrade");
            return;
        }

        PaddockScript ps = General.selectedEntity.GetComponent<PaddockScript>();
        AssetManager am = GameObject.Find("GameLogic").GetComponent<AssetManager>();
        if (am.getTotalMoney() < ps.getNextLevelCost())
        {
            SendToast.pop("Not enough money to upgrade paddock");
            return;
        }
        am.adjustMoney(-ps.getNextLevelCost());
        ps.setSecurityLevel(ps.getSecurityLevel() + 1);
        //SaveLoad.saveState("manually upgrading paddock");
    }
}