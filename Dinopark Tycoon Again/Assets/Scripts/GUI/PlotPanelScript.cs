using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlotPanelScript : MonoBehaviour
{
    public TextMeshProUGUI currentResource;
    public TextMeshProUGUI timeToFinish;
    public TextMeshProUGUI harvestAmount;

    private void OnEnable()
    {

        GameObject currentPlot = General.selectedEntity;
        if (currentPlot.tag != "Plot")
        {
            SendToast.pop("Selected entity should be a plot, but it isnt");
            return;
        }
        PlotScript ps = currentPlot.GetComponent<PlotScript>();

        currentResource.text = "Currently farming: " + ps.currentResource.title;
        harvestAmount.text = "You will receive: " + ps.currentResource.harvestAmount + " " + ps.currentResource.foodType;
    }


}
