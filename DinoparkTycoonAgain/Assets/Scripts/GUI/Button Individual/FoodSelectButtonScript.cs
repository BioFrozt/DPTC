using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSelectButtonScript : MonoBehaviour
{
    public void setFoodToPlot(string whichFood)
    {
        GameObject selectedPlot = General.selectedEntity;
        if (selectedPlot.tag != "Plot")
        {
            SendToast.pop("food select button: selected entity isnt a plot");
            return;
        }

        SendToast.pop("food selected:: " + whichFood);

        selectedPlot.GetComponent<PlotScript>().setCurrentResource(PlotResourceTypeList.getPlotResourceTypeByString(whichFood));


    }

}
