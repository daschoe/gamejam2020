using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
  public Image icon;
  public Button RemoveButton;
  public Text AmountLabel;
  Item item;
  public void AddItem( Item newItem)
  {
    item = newItem;
    icon.sprite = item.icon;
    icon.enabled = true;
    RemoveButton.interactable = true;
    AmountLabel.enabled = true;
    AmountLabel.text = "" + item.amount;
  }

  public void ClearSlot ()
  {
    item = null;
    icon.sprite = null;
    icon.enabled = false;
    RemoveButton.interactable = false;
    AmountLabel.enabled = false;
    AmountLabel.text = "";
  }
  public void OnRemoveButton ()
  {
    Debug.Log("Removing "+ item.name);
    Inventory.instance.Remove(item);
  }
  public void UseItem ()
  {
    if (item != null)
    {
      item.Use();
    }
  }
}
