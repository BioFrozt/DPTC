using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class HatchPanelScript : MonoBehaviour
{
    public GameObject eggPrefab;
    public GameObject hatchPanel;
    public TextMeshProUGUI currentEggType;
    public TextMeshProUGUI currentEggTime;
    public GameObject eggInfoPanel;
    public Button placeCreatureButton;

    private void OnEnable()
    {
        setEggs();
        eggInfoPanel.SetActive(false);
        placeCreatureButton.interactable = false;
    }

    public void Update()
    {
        //Debug.Log("in update before");
        if (General.selectedEntity == null) return;
        //Debug.Log("in update");
        if (General.selectedEntity.GetComponent<EggScript>() == null)
        {
            //SendToast.log("selected entity name:" + General.selectedEntity.name);
            //SendToast.pop("Selected entity has no eggscript");
            return;
        }
        long now = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        int hatchTimeSeconds = SpeciesManager.getSpeciesByNumber(General.selectedEntity.GetComponent<EggScript>().egg.speciesNumber).hatchTimeSeconds;
        long remainingTimeSeconds = hatchTimeSeconds - (now - General.selectedEntity.GetComponent<EggScript>().egg.startTime);

        if (remainingTimeSeconds > 0)
        {
            currentEggTime.text = "Remaining time: " + remainingTimeSeconds;
        }
        else
        {
            currentEggTime.text = "Ready to hatch!";
            placeCreatureButton.interactable = true;
        }


    }

    private void setEggs()
    {
        foreach(GameObject egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            Destroy(egg);
        }

        Debug.Log("opening hatch script");
        Debug.Log("size: " + GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs.Count);

        int x = 0;
        int spacing = 250;
        int y = 800;

        foreach (Egg e in GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs)
        {
            Debug.Log("spawning an egg");
            GameObject instantiatedImage = Instantiate(eggPrefab);
            instantiatedImage.GetComponent<EggScript>().egg = e;
            instantiatedImage.GetComponent<EggScript>().setProperties();
            instantiatedImage.GetComponent<RectTransform>().SetParent(hatchPanel.transform);
            instantiatedImage.transform.localPosition = new Vector3(-500+x, y, 0);
            float scale = 0.5f;
            instantiatedImage.transform.localScale = new Vector3(0.6f*scale, 1*scale, 1);
            instantiatedImage.transform.rotation = Camera.main.transform.rotation;
            x += spacing;

            if (x >= 5 * spacing)
            {
                y -= spacing;
                x = 0;
            }
            
        }
    }

    public void setSelectedEgg(GameObject e)
    {
        eggInfoPanel.SetActive(true);
        Debug.Log("selected egg: " + e.name);
        General.selectedEntity = e;
        currentEggType.text = "Type: " + SpeciesManager.getSpeciesByNumber(e.GetComponent<EggScript>().egg.speciesNumber).speciesName;
    }

}