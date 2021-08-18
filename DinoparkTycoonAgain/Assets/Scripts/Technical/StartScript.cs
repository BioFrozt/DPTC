using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("start in startscript");
        GameObject gameLogic = GameObject.Find("GameLogic");

        //tady je jedno order of execution, na nicem nazavisi
        gameLogic.GetComponent<AssetManager>().myStart();
        gameLogic.GetComponent<ComboManager>().myStart();

        // tady jsou starty zavisly na dalsich startech
        SpeciesManager.myStart();
        gameLogic.GetComponent<EggDatabase>().myStart();

        gameLogic.GetComponent<SaveLoadPlaceholder>().myStart();
    }
}
