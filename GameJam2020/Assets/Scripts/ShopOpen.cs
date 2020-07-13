using UnityEngine;

public class ShopOpen : Interactable
{
    public GameObject shopUI;
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
      shopUI.SetActive(true);
      //shopUI.enabled = true;
    }
}
