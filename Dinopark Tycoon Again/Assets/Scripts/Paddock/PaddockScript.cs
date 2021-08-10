using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaddockScript : MonoBehaviour
{

    private int securityLevel = 0;
    public GameObject cube;

    public PaddockSaveData getPaddockSaveData()
    {
        return new PaddockSaveData(transform.position.x, transform.position.z, securityLevel);
    }

    public void loadFromPaddockSaveData(PaddockSaveData psd)
    {
        setSecurityLevel(psd.securityLevel);
    }


    public void setSecurityLevel(int level) 
    {
        securityLevel = level;
        switch (level)
        {
            case 0:
                cube.GetComponent<MeshRenderer>().material.color = Color.grey;
                break;
            case 1:
                cube.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case 2:
                cube.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 3:
                cube.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            case 4:
                cube.GetComponent<MeshRenderer>().material.color = Color.magenta;
                break;
            case 5:
                cube.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            default:
                cube.GetComponent<MeshRenderer>().material.color = Color.black;
                break;
        }
    }

    public int getNextLevelCost()
    {
        switch(securityLevel)
        {
            case 0: return 1;
            case 1: return 10;
            case 2: return 50;
            case 3: return 75;
            case 4: return 100;
            case 5: return 1000;
            default: return -1;
        }

    }

    public int getSecurityLevel()
    {
        return securityLevel;
    }

}

[System.Serializable]
public class PaddockSaveData
{
    public float xPos;
    public float zPos;
    public int securityLevel;

    public PaddockSaveData(float x, float z, int sl)
    {
        xPos = x;
        zPos = z;
        securityLevel = sl;
    }
}
