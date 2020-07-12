using UnityEngine;
//item class, items should be of this class or derive from it
[CreateAssetMenu(fileName = "NewItemObject", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
  new public string name = "New Item";
  public Sprite icon = null;
  //For items the player has from the start
  public bool isDefaultItem = false;
  //how much money the item is wort
  public int worth = 0;
  //type of item, default, crop, tool
  public string type = "default";
  public int amount = 1;
  //what happens when you click this items
  //must be overwritten
  public virtual void Use()
  {
    Debug.Log("Using " + name);
  }
}
