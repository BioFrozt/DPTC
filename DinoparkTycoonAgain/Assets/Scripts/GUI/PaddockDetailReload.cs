using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaddockDetailReload : MonoBehaviour
{
    public GameObject selectedPaddockText;
    public GameObject currentlevelDuo;
    public GameObject upgradeCostDuo;

    public GameObject creaturePrefab;
    public GameObject scrollContent;

    private ArrayList children = new ArrayList();

    private void OnEnable()
    {
        reloadPaddockPanel();
    }

    public void reloadPaddockPanel()
    {
        selectedPaddockText.GetComponent<TextMeshProUGUI>().text = General.selectedEntity.name;
        currentlevelDuo.GetComponent<TextMeshProUGUI>().text =
            "Current Security Level: " + General.selectedEntity.GetComponent<PaddockScript>().getSecurityLevel();
        upgradeCostDuo.GetComponent<TextMeshProUGUI>().text =
            "Upgrade Cost: " + General.selectedEntity.GetComponent<PaddockScript>().getNextLevelCost();

        foreach (GameObject child in children)
        {
            Destroy(child);
        }
        children.Clear();

        int spacing = 300;
        int y = spacing;
        
        GameObject[] creatures = Getters.getCreaturesByPaddock(General.selectedEntity);
        foreach (GameObject go in creatures)
        {
            SendToast.pop("found a creature in this paddock");
            GameObject newPanel = Instantiate(creaturePrefab);
            newPanel.transform.SetParent(scrollContent.transform);
            newPanel.transform.localScale = new Vector3(1, 1, 1);
            newPanel.transform.rotation = scrollContent.transform.rotation;
            newPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, y -= spacing, 0);
            newPanel.GetComponent<PaddockCreatureDetail>().setCreature(go);
            children.Add(newPanel);
        }

        RectTransform rectTransform = scrollContent.GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, 0);
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, creatures.Length > 3 ? 100-(creatures.Length-3)*spacing : 100);


    }

}
