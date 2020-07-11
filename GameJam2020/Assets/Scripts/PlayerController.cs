using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      //Checks for mouse clicks and whether an object was left-clicked
      if(Input.GetMouseButtonDown(0))
      {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        //removes focus on click
        RemoveFocus();
        if (hit.collider != null)
        {
          Debug.Log("Something was clicked!");
          Debug.Log(hit.collider.gameObject.name);
          Interactable interactable = hit.collider.GetComponent<Interactable>();
          if (interactable != null) {
            Debug.Log("Something was clicked!");
          }
        }
      }

        //Checks for mouse clicks and whether an object was right-clicked
        if(Input.GetMouseButtonDown(1))
        {
          Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
          RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
          if (hit.collider != null)
          {
            Debug.Log("Something was clicked!");
            Debug.Log(hit.collider.gameObject.name);
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null) {
              //sets focus on clicked object
              SetFocus(interactable);
            }
          }
        }
    }
    //Method:SetFocus
    //Sets focus variable to a given parameter
    //single parameter of class Interactable
    void SetFocus(Interactable newFocus) {
      if (newFocus != focus)
      {
        if (focus != null)
        {
          focus.OnDefocused();
        }
        focus = newFocus;
        newFocus.OnFocused(transform);
      }
    }

    void RemoveFocus() {
      if (focus != null)
      {
          focus.OnDefocused();
      }
      focus = null;
    }
}
