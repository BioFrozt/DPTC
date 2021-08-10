using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class EggScript : MonoBehaviour
{
    public Egg egg;

    public void Start()
    {
        Debug.Log("in egg start");
    }

    public void setProperties()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/eggs/egg" + egg.speciesNumber);
        if (gameObject.GetComponent<Image>().sprite == null) { SendToast.pop("error in selecting sprite"); return; }
    }

    public void setSelfAsSelected()
    {
        GameObject.Find("HatchPanel").GetComponent<HatchPanelScript>().setSelectedEgg(gameObject);
    }

    public void ping()
    {
        SendToast.pop("pinged");
    }
}
