using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupPanelDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("lmao", 3);

    }

    public void lmao()
    {
        gameObject.SetActive(false);
    }
}
