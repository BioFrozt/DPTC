using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureList : MonoBehaviour
{
    public GameObject creature1;
    public GameObject creature2;
    public GameObject creature3;
    public GameObject creature4;
    public GameObject creature5;
    public GameObject creature6;
    public GameObject creature7;
    public GameObject creature8;
    public GameObject creature9;
    public GameObject creature10;
    public GameObject getCreatureByID(int i)
    {
        switch(i)
        {
            case 1: return creature1;
            case 2: return creature2;
            case 3: return creature3;
            case 4: return creature4;
            case 5: return creature5;
            case 6: return creature6;
            case 7: return creature7;
            case 8: return creature8;
            case 9: return creature9;
            case 10: return creature10;
            default:
                SendToast.log("ERROR: getCreatureByNumber failed");
                return null;
        }
    }
}
