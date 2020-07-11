using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Singleton
    public static Inventory instance;

    void Awake ()
    {
      if (instance != null)
      {
        Debug.LogWarning("More than one instance of Inventory found.");
        return;
      }
      instance = this;
    }
    //Triggers an event every time the inventory changes
    //other classes can subscribe to this to react to inventory changes
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    //inventory space
    public int space = 5;
    //item list
    public List<Item> items = new List<Item>();
    //Method: Add
    //Takes an Item as parameter and appends it to the inventory
    public bool Add (Item item)
    {
      if (!item.isDefaultItem)
      {
        if (items.Count >= space)
        {
          Debug.Log("Not enough room.");
          return false;
        }
        items.Add(item);
        if (onItemChangedCallback != null)
        {
          onItemChangedCallback.Invoke();
        }
        Debug.Log("End of add function reached");
        return true;
      }
      return false;
    }

    //Method: Remove
    //Takes an Item as parameter and removes it from the inventory
    public void Remove(Item item)
    {
      items.Remove(item);
      if (onItemChangedCallback != null)
        onItemChangedCallback.Invoke();
    }

}
