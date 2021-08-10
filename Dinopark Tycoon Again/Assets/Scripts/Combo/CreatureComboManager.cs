using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CreatureComboManager
{

    public List<Combo> combos = new List<Combo>();

    public int getMoneyFromCombos()
    {
        int total = 0;
        foreach(Combo c in combos)
        {
            total += c.getCurrentReward();
        }
        return total;
    }

    public void onCreatureUpdate()
    {
        getFilteredByType(ComboType.CREATURE_COUNT).updateOwnProgress();
        getFilteredByType(ComboType.CREATURE_WEIGHT).updateOwnProgress();
        
    }

    public void loadCombos()
    {
        combos.Add(new CreatureCombo(ComboType.CREATURE_COUNT));
        combos.Add(new CreatureCombo(ComboType.CREATURE_WEIGHT));
        foreach (Combo c in combos)
        {
            c.updateOwnProgress();
        }
    }

    public Combo getFilteredByType(ComboType type)
    {
        return combos.Find(c => c.getComboType() == type);
    }
}
class CreatureCombo : Combo
{
    public CreatureCombo(ComboType type) : base(type)
    {
        switch(type)
        {
            case ComboType.CREATURE_COUNT:
                comboLevels.Add(new ComboLevel(1, 1));
                comboLevels.Add(new ComboLevel(10, 100));
                comboLevels.Add(new ComboLevel(15, 500));
                title = Constants.COMBO_CREATURE_COUNT_TITLE;
                description = Constants.COMBO_CREATURE_COUNT_DESCRIPTION;
                break;

            case ComboType.CREATURE_WEIGHT:
                comboLevels.Add(new ComboLevel(500, 15));
                comboLevels.Add(new ComboLevel(1500, 101));
                comboLevels.Add(new ComboLevel(2000, 536));
                title = Constants.COMBO_CREATURE_WEIGHT_TITLE;
                description = Constants.COMBO_CREATURE_WEIGHT_DESCRIPTION;
                break;
        }
    }

    public override void updateOwnProgress()
    {
        switch(type)
        {
            case ComboType.CREATURE_COUNT:
                progress = Getters.getValidCreatures().Length;
            break;

            case ComboType.CREATURE_WEIGHT:
                GameObject[] creatures = Getters.getValidCreatures();
                progress = 0;
                foreach (GameObject go in creatures)
                {
                    progress += go.GetComponent<CreatureScript>().species.weight;
                }
            break;

        }
    }
}
