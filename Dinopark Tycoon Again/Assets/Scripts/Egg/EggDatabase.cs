using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EggDatabase : MonoBehaviour
{
    public ArrayList eggs = new ArrayList();
    public Egg selectedEgg = null;
    public const int MAX_EGGS = 8;
    public void myStart()
    {
        SendToast.pop(""+Guid.NewGuid().ToString());
    }

}

[System.Serializable]
public class Egg
{
    public int speciesNumber { get; }
    public long startTime { get; }

    public Egg(int speciesNumber, long startTime)
    {
        this.speciesNumber = speciesNumber;
        this.startTime = startTime;
        SendToast.pop("egg created with startTIme:" + startTime);
    }


}
