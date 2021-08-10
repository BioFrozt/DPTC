using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combo
{
    public int progress = 0;
    public ComboType type;
    public string description;
    public string title;
    public List<ComboLevel> comboLevels = new List<ComboLevel>();

    public Combo(ComboType type)
    {
        this.type = type;
        comboLevels.Add(new ComboLevel(0, 0));
    }

    public ComboLevel getCurrentComboLevel()
    {
        ComboLevel output = null;
        foreach (ComboLevel cl in comboLevels)
        {
            if (progress >= cl.goal) output = cl;
            else break;
        }
        return output;
    }

    public int getCurrentReward()
    {
        return getCurrentComboLevel().reward;
    }
    public int getCurrentLevelIndex()
    {
        return comboLevels.IndexOf(getCurrentComboLevel());
    }

    public ComboType getComboType()
    {
        return type;
    }

    public abstract void updateOwnProgress();
}

public class ComboLevel
{
    public int goal;
    public int reward;

    public ComboLevel(int goal, int reward)
    {
        this.goal = goal;
        this.reward = reward;
    }
}

public enum ComboType
{
    CREATURE_COUNT, CREATURE_WEIGHT
}


public class ComboGeneric
{

}