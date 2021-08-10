using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (General.isBlocked(Input.mousePosition)) return;
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(raycast, out hit))
            {
                GameObject go = hit.transform.gameObject;
                GameObject.Find("Main Camera").GetComponent<TouchHandler>().handleTouch(go);
            }
        }

        if (Input.GetKey("w"))
            Camera.main.transform.Translate(0, 0, 0.1f, Space.World);
        if (Input.GetKey("s"))
            Camera.main.transform.Translate(0, 0, -0.1f, Space.World);
        if (Input.GetKey("a"))
            Camera.main.transform.Translate(-0.1f, 0, 0, Space.World);
        if (Input.GetKey("d"))
            Camera.main.transform.Translate(0.1f, 0, 0, Space.World);
        if (Input.GetKey("q"))
            Camera.main.fieldOfView += 5;
        if (Input.GetKey("e"))
            Camera.main.fieldOfView -= 5;

        if (Camera.main.fieldOfView > 130) Camera.main.fieldOfView = 130;
        if (Camera.main.fieldOfView < 10) Camera.main.fieldOfView = 10;

    }
}
