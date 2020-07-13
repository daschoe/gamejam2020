using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class CloseByClick : Interactable
{
  public override void LostFocus()
  {
    base.LostFocus();
    gameObject.SetActive(false);
  }
}
