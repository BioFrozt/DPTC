using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public GameObject entity;
    public TextMeshProUGUI dispText;
    [HideInInspector]
    public Vector2 singleTouchBeginPoint;
    public GameObject paddockPanel;
    public GameObject creaturePanel;
    public GameObject plotPanel;


    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (General.isBlocked(t.position)) return;
            if (t.phase == TouchPhase.Began)
            {
                singleTouchBeginPoint = t.position;
                //SendToast.log("touched at: " + t.position.x + "/" + t.position.y); /////////////////////
            }
            if (t.position.y > Screen.height * 0.9f) return;
            if (t.phase == TouchPhase.Ended && (t.position - singleTouchBeginPoint).sqrMagnitude < 1000)
            {
                //if (General.isBlocked(t.position)) return;
                Ray raycast = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hit;

                if (Physics.Raycast(raycast, out hit))
                {
                    GameObject go = hit.transform.gameObject;
                    handleTouch(go);
                }
            }

        }
    }
    public void handleTouch(GameObject go)
    {
        switch(go.tag)
        {
            case "Paddock":
                touchPaddock(go);
                break;
            case "Creature":
                touchCreature(go);
                break;
            case "Plot":
                touchPlot(go);
                break;
        }    
    }

    private void touchPlot(GameObject plot)
    {
        PlotScript ps = plot.GetComponent<PlotScript>();
        if (ps == null)
        {
            SendToast.pop("error in touchplot - PS is null");
            return;
        }

        switch(General.getMouseState())
        {
            case MouseState.NORMAL:
                General.setSelectedEntity(plot);
                plotPanel.SetActive(true);
                SendToast.pop(General.selectedEntity.name);
                break;
        }


    }

    private void touchCreature(GameObject creature)
    {
        SendToast.log("creature touched");
        General.setSelectedEntity(creature);
        creaturePanel.SetActive(true);
        switch (General.getMouseState())
        {
            case MouseState.NORMAL:
                creature.GetComponent<CreatureScript>().updatePanel();

                break;
        }
    }

    private void touchPaddock(GameObject paddock)
    {
        switch (General.getMouseState())
        {
            case MouseState.DRAGGINGCREATURE:
                placeDraggedCreatureToPaddock(paddock);
                break;

            case MouseState.NORMAL:
                General.setSelectedEntity(paddock);
                paddockPanel.SetActive(true);
                break;
        }
    }

    public void placeDraggedCreatureToPaddock(GameObject paddock)
    {

        if (General.draggedEntity == null)
        {
            SendToast.pop("ERROR: attempted to place dragged entity = null");
            return;
        }
        if (paddock == null)
        {
            SendToast.pop("ERROR: attempted to place dragged entity, paddock = null");
            return;
        }

        SendToast.pop("wanting to place creature at paddock: " + paddock.name);

        GameObject de = General.draggedEntity;
        CreatureScript cs = de.GetComponent<CreatureScript>();
        cs.species = SpeciesManager.getSpeciesByNumber(cs.getSpeciesNumber());

        if (paddock.GetComponent<PaddockScript>().getSecurityLevel() < cs.species.securityLevel)
        {
            SendToast.pop("Attempted to place creature/paddock; security level too low: " + de.name + "/" + paddock.name);
            return;
        }

        GameObject newEntity = Instantiate(General.draggedEntity);
        CreatureSaveData csd = new CreatureSaveData(cs.species.speciesNumber, 69, paddock.transform.position.x, paddock.transform.position.z);
        newEntity.GetComponent<CreatureScript>().loadFromCreatureSaveData(csd);

        SendToast.log("selected entity in touch handler: " + General.selectedEntity.name);

        GameObject.Find("GameLogic").GetComponent<EggDatabase>().eggs.Remove(General.selectedEntity.GetComponent<EggScript>().egg);

        General.setDraggedEntity(null);
        General.setMouseState(MouseState.NORMAL);
        SendToast.pop("placed creature to paddock");
        GameObject.Find("GameLogic").GetComponent<ComboManager>().creatureComboManager.onCreatureUpdate();
    }

    private void LateUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Moved)
            {
                Camera.main.transform.Translate(-t.deltaPosition.x / 300, 0, -t.deltaPosition.y / 300, Space.World);
            }
        }


        else if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            if (t0.phase == TouchPhase.Moved && t1.phase == TouchPhase.Moved)
            {
                double dB = (t1.position - t0.position).sqrMagnitude;
                Vector2 t0a = t0.position + t0.deltaPosition;
                Vector2 t1a = t1.position + t1.deltaPosition;
                double dA = (t1a - t0a).sqrMagnitude;

                Camera.main.fieldOfView += (float)(dB - dA) / 30000;

                if (Camera.main.fieldOfView > 130) Camera.main.fieldOfView = 130;
                if (Camera.main.fieldOfView < 10)  Camera.main.fieldOfView = 10;
            }


        }

    }
}
