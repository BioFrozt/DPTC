using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class CreatureScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject species_text;
    [HideInInspector]
    public GameObject foodLevel_text;
    [HideInInspector]
    public GameObject weight_text;
    [HideInInspector]
    public GameObject area_text;
    [HideInInspector]
    public GameObject foodType_text;

    [SerializeField]
    private int speciesNumber;
    [HideInInspector]
    public string id;
    [HideInInspector]
    public Species species;
    [HideInInspector]
    public int foodLevel = 69;
    [HideInInspector]
    private GameObject belongingPaddock;



    public void Start() // musi bejt start, je to runtime
    {
        species_text    = Getters.findInactiveObject("Species_text");
        foodLevel_text  = Getters.findInactiveObject("Food Level_text");
        weight_text     = Getters.findInactiveObject("Weight_text");
        area_text       = Getters.findInactiveObject("Area_text");
        foodType_text   = Getters.findInactiveObject("Food Type_text");
        species = SpeciesManager.getSpeciesByNumber(speciesNumber);
        id = Guid.NewGuid().ToString();

        InvokeRepeating("loseOneFood", 0, 1);
    }


    public CreatureSaveData getCreatureSaveData()
    {
        return new CreatureSaveData(speciesNumber, foodLevel, belongingPaddock.transform.position.x, belongingPaddock.transform.position.z);
    }

    public void loadFromCreatureSaveData(CreatureSaveData csd)
    {
        speciesNumber = csd.speciesNumber;
        species = SpeciesManager.getSpeciesByNumber(speciesNumber);
        foodLevel = csd.foodLevel;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Paddock"))
        {
            if (go.transform.position.x == csd.belongingPaddockX && go.transform.position.z == csd.belongingPaddockZ)
                setBelongingPaddock(go);
        }
    }

    public void setBelongingPaddock(GameObject paddock)
    {
        float x = paddock.transform.position.x;
        float y = paddock.transform.position.y;
        float z = paddock.transform.position.z;
        gameObject.transform.position = 
            new Vector3(x +(float) new System.Random().NextDouble() * 0.8f - 0.4f, y + 0.5f, z + (float)new System.Random().NextDouble() * 0.8f-0.4f);
        gameObject.GetComponent<MoveAroundScript>().xCenter = x;
        gameObject.GetComponent<MoveAroundScript>().zCenter = z;
        belongingPaddock = paddock;
    }

    public GameObject getBelongingPaddock()
    {
        return belongingPaddock;
    }

    public void updatePanel()
    {
        species_text.GetComponent<TextMeshProUGUI>().text   = "Species: " + species.speciesName;
        foodLevel_text.GetComponent<TextMeshProUGUI>().text = "Food Level: " + foodLevel;
        foodType_text.GetComponent<TextMeshProUGUI>().text  = "Food Type: " + species.foodTypeName;
        weight_text.GetComponent<TextMeshProUGUI>().text    = "Weight: " + species.weight;
        area_text.GetComponent<TextMeshProUGUI>().text      = "Area: " + species.areaName;
    }

    public void loseOneFood()
    {
        adjustFoodLevel(-1);
    }

    public void adjustFoodLevel(int amount)
    {
        foodLevel += amount;
        if (foodLevel <= 0) foodLevel = 0;
        if (gameObject == General.selectedEntity) updatePanel();
        GameObject.Find("GameLogic").GetComponent<ComboManager>().creatureComboManager.onCreatureUpdate();
    }

    public void setFoodLevel(int amount)
    {
        foodLevel = amount;
    }

    public float getFoodPercentage()
    {
        return (int)(foodLevel / species.maxFoodLevel * 100);
    }

    public int getSpeciesNumber()
    {
        return speciesNumber;
    }
}

[System.Serializable]
public class CreatureSaveData
{
    public int speciesNumber;
    public int foodLevel;
    public float belongingPaddockX;
    public float belongingPaddockZ;

    public CreatureSaveData(int sn, int fl, float bpx, float bpz )
    {
        speciesNumber = sn;
        foodLevel = fl;
        belongingPaddockX = bpx;
        belongingPaddockZ = bpz;
    }
}