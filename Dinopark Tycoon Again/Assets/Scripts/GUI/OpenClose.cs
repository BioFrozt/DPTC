using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public GameObject go;

    public void open()
    {
        go.SetActive(true);
    }

    public void close()
    {
        go.SetActive(false);
    }

    public void toggle()
    {
        go.SetActive(!go.activeSelf);
    }
}
