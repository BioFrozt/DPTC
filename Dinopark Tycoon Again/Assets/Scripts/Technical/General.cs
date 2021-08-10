using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General 
{
    private static MouseState mouseState = MouseState.NORMAL;
    public static GameObject selectedEntity = null;
    public static GameObject draggedEntity = null;

    public static bool isBlocked(Vector2 pos)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("BlockTouch");
        foreach (GameObject go in gos)
        {
            RectTransform rt = go.GetComponent<RectTransform>();
            Vector2 anchor = rt.anchoredPosition + new Vector2(Screen.width, Screen.height) / 2 ;
            Vector2 maxes = new Vector2(rt.rect.xMax, rt.rect.yMax) + anchor;
            Vector2 mins = new Vector2(rt.rect.xMin, rt.rect.yMin) + anchor;
            if (pos.x > mins.x && pos.x < maxes.x && pos.y > mins.y && pos.y < maxes.y)
            {
                return true;
            }
        }
        return false;
    }

    

    public static void setSelectedEntity(GameObject go)
    {
        selectedEntity = go;
    }

    public static GameObject getSelectedEntity()
    {
        return selectedEntity;
    }

    public static void setDraggedEntity(GameObject go)
    {
        draggedEntity = go;
    }

    public static GameObject getDraggedEntity()
    {
        return draggedEntity;
    }

    public static void setMouseState(MouseState s)
    {
        mouseState = s;
        switch (mouseState)
        {
            case MouseState.NORMAL:
                GameObject btn = Getters.findInactiveObject("CancelDraggingButton");
                if (btn == null) break;
                btn.SetActive(false);
                break;
            case MouseState.DRAGGINGCREATURE:
                GameObject btn1 = Getters.findInactiveObject("CancelDraggingButton");
                if (btn1 == null) break;
                btn1.SetActive(true);
                break;
        }
    }

    public static MouseState getMouseState()
    {
        return mouseState;
    }

    public static string getNiceTimestamp(bool wantDate = false)
    {
        if (!wantDate) return System.DateTime.Now.ToString("HH:mm:ss");
        else return System.DateTime.Now.ToString("MM/dd    HH:mm:ss");
    }

}

public enum MouseState
{
    NORMAL,
    DRAGGINGCREATURE
}