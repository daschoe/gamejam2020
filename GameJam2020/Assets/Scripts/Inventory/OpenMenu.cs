using UnityEngine;

public class OpenMenu : Interactable
{
    public GameObject menu;
    //interaction function, overrides base funktion Interact
    public override void Interact()
    {
      base.Interact();
      Debug.Log("Opening " + menu.name);
      Open();
    }
    void Open()
    {
      menu.SetActive(true);
    }
}
