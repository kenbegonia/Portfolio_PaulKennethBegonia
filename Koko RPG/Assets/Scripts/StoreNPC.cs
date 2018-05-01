using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreNPC : NPC {

    public GameObject storeScreen;

    // Use this for initialization
    //void Start () {
    //    storeScreen.SetActive(false);
    //}

    public override void Interact()
    {
        base.Interact();
        OpenStore();
    }

    void OpenStore()
    {
        Debug.Log("Stooooooore");
        storeScreen.SetActive(true);
    }

    public void OnRemoveButton()
    {
        storeScreen.SetActive(false);
    }
}
