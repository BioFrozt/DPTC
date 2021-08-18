using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighlightSelectedShopCreature : MonoBehaviour
{
    public GameObject creatureHighlightPanel;

    public Button buyButton;
    public TextMeshProUGUI speciesName;
    public TextMeshProUGUI moneyPerTicket;
    public TextMeshProUGUI foodType;
    public TextMeshProUGUI securityLevel;
    public TextMeshProUGUI area;
    public TextMeshProUGUI cost;

    public int selectedSpeciesNumber;
    public void buttonClicked(int speciesNumber)
    {
        creatureHighlightPanel.SetActive(true);
        setCreatureAsSelected(SpeciesManager.getSpeciesByNumber(speciesNumber));
        selectedSpeciesNumber = speciesNumber;
        if (GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs.Count > Constants.MAX_EGG_COUNT)
        {
            buyButton.interactable = false;
        }
    }

    public void setCreatureAsSelected(Species species)
    {

        speciesName.text = species.speciesName;
        moneyPerTicket.text = "MPT: " + species.moneyPerTicket;
        foodType.text = "FT: " + species.foodType;
        securityLevel.text = "Security Level: " + species.securityLevel;
        area.text = "Area: " + species.area;
        cost.text = "Cost: " + species.cost;
    }


    
}
