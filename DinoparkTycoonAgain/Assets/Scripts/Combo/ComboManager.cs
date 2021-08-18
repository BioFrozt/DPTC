using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public CreatureComboManager creatureComboManager = new CreatureComboManager();
    public int getMoneyFromCombos()
    {
        int total = 0;
        total += creatureComboManager.getMoneyFromCombos();
        return total;
    }

    public List<Combo> getAllCombos()
    {
        List<Combo> output = new List<Combo>();
        output.AddRange(creatureComboManager.combos);
        return output;
    }

    public void myStart()
    {
        creatureComboManager.loadCombos();
    }

}
