using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SendToast
{
    public static void pop(string message)
    {
        Getters.findInactiveObject("PopupPanel").SetActive(true);
        GameObject.Find("Popup Text").GetComponent<TextMeshProUGUI>().text = message;
        log("P: " + message);
    }

    private static ArrayList logs = new ArrayList();
    public static void log(string message)
    {
        logs.Add(message);
        if (logs.Count >= 75)
        {
            logs.RemoveAt(0);
        }
        reloadLog();
    }

    public static void reloadLog()
    {
        GameObject cl = Getters.findInactiveObject("ConsoleLog");
        cl.GetComponent<TextMeshProUGUI>().text = "Console:";
        foreach (string s in logs)
            cl.GetComponent<TextMeshProUGUI>().text += "\n" + s;
    }

    public static void clearLog()
    {
        logs.Clear();
        GameObject.Find("ConsoleLog").GetComponent<TextMeshProUGUI>().text = "Console:";
    }

}
