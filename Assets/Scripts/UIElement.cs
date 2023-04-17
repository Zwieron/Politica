using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIElement : MonoBehaviour
{
    public bool active = false;
    protected bool isMouseOver = false;
    protected SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
    }
    protected bool CheckIfMouseHovers()
    {
        Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;
        if(spriteRenderer.bounds.Contains(mousePos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        public abstract void checkState();
     public abstract void onClick();
     public abstract void onUnclick();
     public abstract void onHover();
     public abstract void onMouseUp();
     public abstract void onMouseExit();
    }

    public class Button : UIElement
    {
        void Start()
        {
        }
        void Update()
        { 
            checkState();
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

        if (Input.GetMouseButtonDown(0))
        {
            onClick();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            onMouseUp();
        }
    }
    else
    {
        if (isMouseOver)
        {
            onMouseExit();
            isMouseOver = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            onUnclick();
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
        } 
        public override void onMouseUp()
        {
        }
        public override void onMouseExit()
        {

        }
        
    }
    
