using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    //interaction function, overrides base funktion Interact
    public override void Interact()
    {
      base.Interact();
      PickUp();
    }

    //Method: PickUp
    //Attempts to add item to inventory and destroys gameobjet afterwards
    void PickUp ()
    {
      Debug.Log("Picking up " + item.name);
      //Add item to inventory
      bool wasPickedUp = Inventory.instance.Add(item);
      if (wasPickedUp == true)
        Destroy(gameObject);
      // Destroy(gameObject);
    }
}
