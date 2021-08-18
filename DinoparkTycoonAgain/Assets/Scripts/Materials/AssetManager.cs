using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssetManager : MonoBehaviour
{
    public GameObject ticketPriceText;
    public GameObject totalMoneyText;

    public GameObject herbivorousFoodText;
    public GameObject carnivorousFoodText;

    private double totalMoney = 111;
    private Dictionary<FoodType, int> food;

    public void myStart()
    {
        food = new Dictionary<FoodType, int>();
        food.Add(FoodType.LEAVES, 200);
        food.Add(FoodType.MEAT, 300);

        InvokeRepeating("showTicketPrice", 0, 1);
        InvokeRepeating("reloadFoodText", 0, 1);
        InvokeRepeating("buyTicket", 0, 3);

    }

    public void adjustFood(FoodType ft, int amount)
    {
        food[ft] = food[ft] + amount;
        reloadFoodText();
        //SaveLoad.saveState("Adjusting food");
    }

    public void reloadFoodText()
    {
        herbivorousFoodText.GetComponent<TextMeshProUGUI>().text = "Plants: " + food[FoodType.LEAVES];
        carnivorousFoodText.GetComponent<TextMeshProUGUI>().text = "Meat: " + food[FoodType.MEAT];
    }
    
    public int getFoodByType(FoodType ft)
    {
        return food[ft];
    }
    public void setFoodByType(FoodType ft, int amount)
    {
        food[ft] = amount;
    }
    public void showTicketPrice()
    {
        ticketPriceText.GetComponent<TextMeshProUGUI>().text = "PPT: " + System.Math.Round((float)getPricePerTicket(), 1);
    }
    private void showTotalMoney()
    {
        totalMoneyText.GetComponent<TextMeshProUGUI>().text = "Total: " + System.Math.Round(totalMoney, 1);
    }
    public double getTotalMoney()
    {
        return totalMoney;
    }
    public void setTotalMoney(double d)
    {
        totalMoney = d;
    }

    public void buyTicket()
    {
        adjustMoney(getPricePerTicket());
    }
    public void adjustMoney(double d)
    {
        totalMoney += d;
        showTotalMoney();
        //SaveLoad.saveState("Money changed");
    }

    public float getPricePerTicket()
    {
        GameObject[] creatures = Getters.getValidCreatures();
        float ppt = 0;

        foreach (GameObject go in creatures)
        {
            ppt += go.GetComponent<CreatureScript>().species.moneyPerTicket;
        }
        ppt += GameObject.Find("GameLogic").GetComponent<ComboManager>().getMoneyFromCombos();
        return ppt;
    }
}
public enum FoodType
{
    LEAVES, WOOD, FRUITS,
    MEAT, INSECTS, FISH
}
public enum Area
{
    EUROPE,
    ASIA,
    AMERICA,
    AFRICA
}
public enum Era
{
    JURRASIC,
    TRIASSIC
}




