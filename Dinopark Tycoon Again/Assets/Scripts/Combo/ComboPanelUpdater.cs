using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboPanelUpdater : MonoBehaviour
{
    public GameObject comboDetailPrefab;
    public GameObject scrollContent;

    List<GameObject> children = new List<GameObject>();

    private void OnEnable()
    {
        //GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        ComboManager cm = GameObject.Find("GameLogic").GetComponent<ComboManager>();
        SendToast.log("enabled ");

        List<Combo> combos = cm.getAllCombos();

        foreach(GameObject child in children) Destroy(child);
        children.Clear();
        
        int y = 0;
        int spacing = 350;
        foreach(Combo c in combos)
        {
            SendToast.log("Combo: " + c.title + ", progress: " + c.progress + ", level: " + c.getCurrentLevelIndex());
            GameObject newPanel = Instantiate(comboDetailPrefab);
            ComboDetailScript cds = newPanel.GetComponent<ComboDetailScript>();

            newPanel.transform.SetParent(scrollContent.transform);
            newPanel.transform.localScale = new Vector3(1, 1, 1);
            newPanel.transform.rotation = scrollContent.transform.rotation;
            newPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, y -= spacing, 0);
            children.Add(newPanel);

            cds.title.text = c.title;
            cds.description.text = c.description;
            cds.progress.text = "Progress: " + c.progress;
            cds.reward.text = "$" + c.getCurrentReward();
        }






        /*
        if (cm.getCombo1(creatures, true) > 0)
            text1.GetComponent<TextMeshProUGUI>().text = "Complete; reward: " + cm.getCombo1(creatures, false);
        else
            text1.GetComponent<TextMeshProUGUI>().text = "Not complete; possible reward: " + cm.getCombo1(creatures, false);

        if (cm.getCombo2(creatures, true) > 0)
            text2.GetComponent<TextMeshProUGUI>().text = "Complete; reward: " + cm.getCombo2(creatures, false);
        else
            text2.GetComponent<TextMeshProUGUI>().text = "Not complete; possible reward: " + cm.getCombo2(creatures, false);

        if (cm.getCombo3(creatures, true) > 0)
            text3.GetComponent<TextMeshProUGUI>().text = "Complete; reward: " + cm.getCombo3(creatures, false);
        else
            text3.GetComponent<TextMeshProUGUI>().text = "Not complete; possible reward: " + cm.getCombo3(creatures, false);*/

    }
}
