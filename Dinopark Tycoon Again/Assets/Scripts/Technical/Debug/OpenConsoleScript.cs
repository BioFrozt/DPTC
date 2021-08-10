using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenConsoleScript : MonoBehaviour
{
    public GameObject panel;
    
    public void buttonPress()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
            SendToast.reloadLog();
        }
        else 
        {
            panel.SetActive(false);
        }
    }

    public void clearConsole()
    {
        if (!panel.activeSelf) return;
        SendToast.clearLog();
    }
}
