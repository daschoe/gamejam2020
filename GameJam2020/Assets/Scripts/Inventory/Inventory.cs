﻿using System.Collections;
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
        int index = items.IndexOf(items.Find(i => i.name == item.name));
        if (index > -1)
        {
          items[index].amount += item.amount;
        }
        else
        {
          if (items.Count >= space)
          {
            Debug.Log("Not enough room.");
            return false;
          }
          items.Add(item);
        }
        if (onItemChangedCallback != null)
        {
          onItemChangedCallback.Invoke();
        }
        return true;
      }
      return false;
    }

    //Method: Remove
    //Takes an Item as parameter and removes it from the inventory
    public bool Remove(Item item)
    {
      if (!item.isDefaultItem)
      {
        int index = items.IndexOf(items.Find(i => i.name == item.name));
        if (index > -1)
        {
          items[index].amount -= item.amount;
          if (items[index].amount == 0)
            items.Remove(item);
        }
        else
        {
          items.Remove(item);
        }
        if (onItemChangedCallback != null)
        {
          onItemChangedCallback.Invoke();
        }
        return true;
      }
      return false;
    }

}
