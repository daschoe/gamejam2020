using UnityEngine;

public class Interactable : MonoBehaviour
{
  //the radius the player needs to be in to interact or focus
  public float radius = 3f;
  //Interaction position, this sets the point at which the player is able to interact with an Object
  //example: for a house, the interaction position would be in front of the door
  public Transform interactionTransform;

  bool isFocus = false;
  bool hasInteracted = false;
  Transform player;

  //this is where the interaction magic happens
  public virtual void Interact ()
  {
    //This method is meant to be overwritten
    Debug.Log("Interacting with " + transform.name);
  }
  public virtual void LostFocus ()
  {
    //This method is meant to be overwritten
    Debug.Log(transform.name + "Lost focus");
  }
  void Update ()
  {
    //if within interaction distance and clicked, do interact
    if (isFocus && !hasInteracted) {
      float distance = Vector2.Distance(player.position, interactionTransform.position);
      if (distance <= radius)
      {
        Interact();
        hasInteracted = true;
        isFocus = false;
      }
    }
  }
  public void OnFocused (Transform playerTransform)
  {
    isFocus = true;
    player = playerTransform;
    hasInteracted = false;
  }

  public void OnDefocused ()
  {
    isFocus = false;
    player = null;
    hasInteracted = false;
    LostFocus();
  }

  //Method: OnDrawGizmosSelected
  //draws a yellow circle oround the object to see the interaction radius
  void OnDrawGizmosSelected ()
  {
    if (interactionTransform == null)
    {
      interactionTransform = transform;
    }
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(interactionTransform.position, radius);
  }
}
