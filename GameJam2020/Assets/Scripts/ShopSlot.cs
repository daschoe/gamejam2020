using UnityEngine;
using UnityEngine.UI;
public class ShopSlot : MonoBehaviour
{
  public Item item;
  public Image icon;
  public Text PriceLabel;
  public Text NameLabel;
  Currency currencyScript;
  //initialize slot and set labels to item properties
  void Start ()
  {
    currencyScript = GameObject.FindWithTag("GameController").GetComponent<Currency>();
    if (item != null)
    {
      icon.sprite = item.icon;
      NameLabel.text = item.name;
      PriceLabel.text = item.worth.ToString();
    }

  }
  //Add Item to player Inventory
  //remove item price from currency
  public void BuyItem ()
  {
    if (item != null)
    {
      Debug.Log("Buying "+item.name);
      Debug.Log(currencyScript.currency);
      if (currencyScript.currency >= item.worth)
      {
        currencyScript.currency -= item.worth;
        Inventory.instance.Add(item);
      }
      else
      {
        Debug.Log("Not enough money to buy item.");
      }
    }
  }
}
