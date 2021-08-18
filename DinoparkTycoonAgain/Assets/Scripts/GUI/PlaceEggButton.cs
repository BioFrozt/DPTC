using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEggButton : MonoBehaviour
{
    public void onClick()
    {
        int id = General.selectedEntity.GetComponent<EggScript>().egg.speciesNumber;
        GameObject.Find("HatchPanel").SetActive(false);
        SendToast.pop("placing creature with id: " + id);
        GameObject chosenCreature = GameObject.Find("GameLogic").GetComponent<CreatureList>().getCreatureByID(id);
        General.setDraggedEntity(chosenCreature);
        General.setMouseState(MouseState.DRAGGINGCREATURE);
        SendToast.log("dragged entity: " + General.draggedEntity.name); 
    }
}
