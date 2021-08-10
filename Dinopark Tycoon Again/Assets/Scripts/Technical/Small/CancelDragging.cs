using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelDragging : MonoBehaviour
{
    public void cancelDragging()
    {
        General.setMouseState(MouseState.NORMAL);
        SendToast.log("Stopped dragging");
    }
}