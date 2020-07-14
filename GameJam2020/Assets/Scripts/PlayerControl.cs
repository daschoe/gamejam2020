using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Interactable focus;
	public float moveSpeed;
    private Animator anim;
    private bool playerMoving; //switch between idle and walking
    private Vector2 lastMove;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //move right or left
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        else if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //move up or down
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMove", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    
        //optional, prevents player from moving while the mouse is
        //hovering over UI
        // if (EventSystem.current.IsPointerOverGameObject())
        //   return;

        //Checks for mouse clicks and whether an object was left-clicked
        if(Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //removes focus on click
            RemoveFocus();
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name + " was left-clicked!");
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) 
                {
                    Debug.Log("Interactable was left-clicked!");
                }
            }
        }

        //Checks for mouse clicks and whether an object was right-clicked
        if(Input.GetMouseButtonUp(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name + " was right-clicked!");
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) 
                {
                    //sets focus on clicked object
                    SetFocus(interactable);
                }
            }
        }
    }

    //Method:SetFocus
    //Sets focus variable to a given parameter
    //single parameter of class Interactable
    void SetFocus(Interactable newFocus) 
    {
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

    void RemoveFocus() 
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
}