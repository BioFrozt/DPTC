using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Getters
{
    public static GameObject[] getValidCreatures() // NOT TESTED
    {

        ArrayList validCreatures = new ArrayList();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Creature"))
        {
            if (go.GetComponent<CreatureScript>().foodLevel <= 0) continue;
            validCreatures.Add(go);
        }

        return (GameObject[])validCreatures.ToArray(typeof(GameObject));
    }   

    public static GameObject[] getCreaturesByPaddock(GameObject paddock)
    {
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        ArrayList relevantCreatures = new ArrayList();

        foreach (GameObject go in creatures)
        {
            if (go.GetComponent<CreatureScript>().getBelongingPaddock() == paddock)
            {
                relevantCreatures.Add(go);
            }
        }

        return relevantCreatures.ToArray(typeof(GameObject)) as GameObject[];
    }

    public static GameObject findInactiveObject(string name)
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.name == name) return go;
        }

        return null;
    }

}
