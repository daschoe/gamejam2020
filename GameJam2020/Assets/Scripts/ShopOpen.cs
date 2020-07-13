using UnityEngine;

public class ShopOpen : Interactable
{
    public Canvas shopUI;
    //interaction function, overrides base funktion Interact
    public override void Interact()
    {
      base.Interact();
      Debug.Log("Interacting!!");
      OpenShop();
    }

    //Method: PickUp
    //Attempts to add item to inventory and destroys gameobjet afterwards
    void OpenShop ()
    {
      Debug.Log("Opening Shop");
      //shopUI = GameObject.Find("Shop").GetComponent<Canvas>();
      shopUI.enabled = true;
    }
}
