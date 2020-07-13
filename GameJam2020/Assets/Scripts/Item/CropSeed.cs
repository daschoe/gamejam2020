using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItemObject", menuName ="Inventory/Item/Crop Seed")]
public class CropSeed : Item
{
    [Range(1,5)]
    public int GrowthTime;
    //when used on plot, spawn plant
    public override void Use()
    {
      Debug.Log("Planting " + name);
      Inventory.instance.Remove(this);
    }

}
