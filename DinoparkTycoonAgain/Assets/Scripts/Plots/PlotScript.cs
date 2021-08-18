using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotScript : MonoBehaviour
{
    //int level = 0;
    long resourcePlacedTime = -1;
    public PlotResourceType currentResource;
    
    public void setCurrentResource(PlotResourceType prt)
    {
        currentResource = prt;
        resourcePlacedTime = Getters.getCurrentTime();
        SendToast.pop("current resource set: " + prt.title);
    }



}

public class PlotResourceType
{
    public FoodType foodType { get; private set; }
    public int harvestAmount{ get; private set; }
    public int harvestTime{ get; private set; }
    public string title{ get; private set; }
    public string description{ get; private set; }

    public PlotResourceType(FoodType foodType, int harvestAmount, int harvestTime, string title, string description)
    {
        this.foodType = foodType;
        this.harvestAmount = harvestAmount;
        this.harvestTime = harvestTime;
        this.title = title;
        this.description = description;
    }
}

public static class PlotResourceTypeList
{
    static Dictionary<string, PlotResourceType> types = new Dictionary<string, PlotResourceType>();
    static PlotResourceTypeList()
    {
            types.Add("chicken", new PlotResourceType(FoodType.MEAT, 100, 50, "Chicken title", "Chicken description"));
            types.Add("pork", new PlotResourceType(FoodType.MEAT, 250, 50, "Pork title", "Pork description"));
            types.Add("beef", new PlotResourceType(FoodType.MEAT, 500, 50, "Beef title", "Beef description"));

            types.Add("grass", new PlotResourceType(FoodType.LEAVES, 101, 50, "Grass leaves title", "Grass leaves description"));
            types.Add("bush", new PlotResourceType(FoodType.LEAVES, 251, 50, "Bush leaves title", "Bush leaves description"));
            types.Add("flower", new PlotResourceType(FoodType.LEAVES, 501, 50, "Flower leaves title", "Flower leaves description"));
    }

    public static PlotResourceType getPlotResourceTypeByString(string type)
    {
        return types[type.ToLower()];
    }
}