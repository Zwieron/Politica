using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIElement : MonoBehaviour
{
    public bool active = false;
    protected bool isMouseOver = false;
    protected bool blocked = false;
    int defaultOrder = 0;
    protected SpriteRenderer spriteRenderer;
    public UIGraphics UIGraphics;
    // Start is called before the first frame update
    void Awake()
    {
        create();
    }

    // Update is called once per frame
    void Update()
    {   
    }
        public void setBlockade(bool blockade)
    {
        blocked=blockade;
    }
        public void SetSprite(Sprite sprite)
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer==null)
        Debug.Log("SpriteRenderer is null");
        if(sprite==null)
        Debug.Log("Sprite is null");
        if(spriteRenderer!=null && sprite!=null)
        spriteRenderer.sprite = sprite;
    }
    protected virtual void create()
    {
        if(spriteRenderer==null)
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer==null)
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        if(UIGraphics==null)
        UIGraphics = gameObject.GetComponent<UIGraphics>();
        if(UIGraphics==null)
        UIGraphics = gameObject.AddComponent<UIGraphics>();
        UIGraphics.setSpriteRenderer(gameObject.GetComponent<SpriteRenderer>());
    }
    public SpriteRenderer GetSprite()
    {
    return spriteRenderer;
    }
    public void SetDefaultOrder(int order)
    {
    this.defaultOrder = order;
    }
    public int getDefaultOrder()
    {
    return defaultOrder;
    }
    public void Sort()
    {
        this.GetSprite().sortingOrder = defaultOrder;
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
        protected BoxCollider2D boxCollider;
        public Vector2 colliderSize;
    void Awake()
        {
            create();
        }
    void Update()
        { 
            checkState();
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
        } 
        public override void onMouseUp()
        {
        }
        public override void onMouseExit()
        {

        }
        
    }
    
