using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationMarkBehaviour : MonoBehaviour
{
    public GameObject entity;
    public GameObject longer;
    public GameObject shorter;

    private void Update()
    {
        if (entity.GetComponent<CreatureScript>().foodLevel <= 0)
        {
            longer.GetComponent<MeshRenderer>().enabled = true;
            shorter.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            longer.GetComponent<MeshRenderer>().enabled = false;
            shorter.GetComponent<MeshRenderer>().enabled = false;

        }
    }
}
