using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPlaceholder : MonoBehaviour
{
    public void myStart()
    {
        InvokeRepeating("save", 2, 2);
        Invoke("load", 0.5f);

    }
    public void save()
    {
        SaveLoad.saveState("In SaveLoadPlaceholder");
    }
    public void load() 
    {
        SaveLoad.loadState();
    }
}
