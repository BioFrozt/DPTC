using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeciesManager
{
    private static Dictionary<int, Species> speciesList = new Dictionary<int, Species>();

    public static Species getSpeciesByNumber(int i)
    {
        return speciesList[i];
    }

    public static void myStart()
    {
        SendToast.log("start of game");
        Species triceratops = new Species();
        triceratops.speciesNumber = 1;
        triceratops.speciesName = "Triceratops";
        triceratops.cost = 10;
        triceratops.moneyPerTicket = 1;
        triceratops.securityLevel = 0;
        triceratops.foodType = FoodType.HERBIVOROUS;
        triceratops.weight = 1000;
        triceratops.era = Era.JURRASIC;
        triceratops.area = Area.ASIA;
        triceratops.foodTypeName = "Herbivorous";
        triceratops.eraName = "jurrascic?";
        triceratops.areaName = "asia?";
        triceratops.maxFoodLevel = 100;
        speciesList.Add(triceratops.speciesNumber, triceratops);

        Species species2 = new Species();
        species2.speciesNumber = 2;
        species2.speciesName = "Species Two";
        species2.cost = 50;
        species2.moneyPerTicket = 5;
        species2.securityLevel = 3;
        species2.foodType = FoodType.CARNIVOROUS;
        species2.weight = 125;
        species2.era = Era.TRIASSIC;
        species2.area = Area.ASIA;
        species2.foodTypeName = "Carnivorous";
        species2.eraName = "triassic?";
        species2.areaName = "europe?";
        species2.maxFoodLevel = 100;
        speciesList.Add(species2.speciesNumber, species2);

        Species species3 = new Species();
        species3.speciesNumber = 3;
        species3.speciesName = "Jezek";
        species3.cost = 100;
        species3.moneyPerTicket = 5;
        species3.securityLevel = 4;
        species3.foodType = FoodType.HERBIVOROUS;
        species3.weight = 15;
        species3.era = Era.TRIASSIC;
        species3.area = Area.AFRICA;
        species3.foodTypeName = "Herbivorous";
        species3.eraName = "triassic?";
        species3.areaName = "Africa?";
        species3.maxFoodLevel = 100;
        speciesList.Add(species3.speciesNumber, species3);
    }

}
public class Species
{
    public int speciesNumber;
    public string speciesName;
    public int cost;
    public float moneyPerTicket;
    public int securityLevel;
    public FoodType foodType;
    public int weight;
    public Era era;
    public Area area;
    public string foodTypeName;
    public string eraName;
    public string areaName;
    public int maxFoodLevel = 100;
    public int hatchTimeSeconds = 50;
}