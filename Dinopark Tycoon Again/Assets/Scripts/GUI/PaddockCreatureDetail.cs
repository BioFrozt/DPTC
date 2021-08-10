using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PaddockCreatureDetail : MonoBehaviour
{
    private GameObject creature;
    private CreatureScript cs;

    public Image profilePicture;
    public TextMeshProUGUI speciesName;
    public TextMeshProUGUI id;
    public TextMeshProUGUI foodLevel;

    public void setCreature(GameObject go)
    {
        creature = go;
        cs = go.GetComponent<CreatureScript>();
        if (cs == null)
        {
            SendToast.pop("attempted to set creature without CS to paddockcreature lmao");
            return;
        }
        //Debug.Log("pp: " + Resources.Load("Assets/baba2"));
        profilePicture.sprite = Resources.Load<Sprite>("Sprites/dinosaur_profile_pictures/D"+ cs.species.speciesNumber);

        id.text = cs.id;
        speciesName.text = cs.species.speciesName;
    }

    private void Update()
    {
        if (cs == null)
        {
            SendToast.pop("creature not set for paddockcreature");
            return;
        }
        foodLevel.text = ""+cs.foodLevel;
    }



}
