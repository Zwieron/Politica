using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : UIElement
    {
        protected bool isHold = false;
        protected BoxCollider2D boxCollider;
        public Vector2 colliderSize;
        ButtonAction buttonAction;
    void Awake()
        {
            create();
            buttonAction = gameObject.GetComponent<ButtonAction>();
        }
    void Update()
        { 
            if(!blocked)
    {
    checkState();

    if (isMouseOver && Input.GetMouseButtonDown(0))
    {
        onClick();
        isHold = true;
    }
    if(!isMouseOver && Input.GetMouseButtonDown(0))
    {
        onUnclick();
    }

    if (Input.GetMouseButtonUp(0))
    {
        if (isHold)
        {
            onMouseUp();
        }
        isHold = false;
    }
    }
        }
    protected override void create()
        {
        base.create();
        if(boxCollider==null)
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        if(boxCollider==null)
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = colliderSize;
        }
public override void checkState()
{
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0;
    RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

    if (hit.collider != null && hit.collider.gameObject.GetComponent<UIElement>() != null && hit.collider.gameObject.GetComponent<UIElement>().Equals(this))
    {
        if (!isMouseOver)
        {
            onHover();
            isMouseOver = true;
        }
    }
    else
    {
        if (isMouseOver)
        {
            onMouseExit();
            isMouseOver = false;
        }
    }
}
        public override void onClick()
        {
        }
        public override void onUnclick()
        {
        }
        public override void onHover()
        {
            buttonAction.tooltip();
        } 
        public override void onMouseUp()
        {
            buttonAction.action();
        }
        public override void onMouseExit()
        {

        }
        
    }
    

