using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardInteraction : Button
{
    public float defaultScale = 30;
    public float hoverScale = 50;
    public float clickScale = 80;
    public float defaultRotation = 0;
    // HandVisual handVisual;
    public Vector3 defaultPosition;
    float deltaTime;
    ButtonPositioner buttonPositioner;


    // Start is called before the first frame update
    void Awake()
    {
        colliderSize = new Vector2(3.6f,5);
        create();
        buttonPositioner = GetComponent<ButtonPositioner>();
    }

    // Update is called once per frame
    void Update()
{   if(!blocked)
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

    if (isHold)
    {
        dragWhileCardIsClicked();
        deltaTime += Time.deltaTime;
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


    public override void onClick()
    {
        if(!active)
        {
        
        Debug.Log("Card Clicked");
        isHold=true;
        }
    }
    public override void onUnclick()
    {
        if(active)
        {
            active=false;
            Debug.Log("Card UnClicked");
            UIGraphics.resizeInTime(defaultScale, 0.2f);
            Sort();
            toDefaultLocRotInTime();
            setBlockade(false);
        }
    }
    public override void onHover()
    {
        if(!active)
        {
        UIGraphics.resizeInTime(hoverScale,0.01f);
        Debug.Log(gameObject.name);
        }
    }
    public override void onMouseUp()
    {
        if(deltaTime>.2f)
        {
        Debug.Log("Card Released");
        toDefaultLocRotInTime();
        isHold=false;
        deltaTime=0;
        }
        else
        {
        isHold=false;
        Debug.Log("Card Odklikd");
        GetSprite().sortingOrder=30;
        setBlockade(true);
       UIGraphics.transformInTime(new Vector3(Screen.width/2,Screen.height/3,0),0.1f);
        UIGraphics.rotateInTime(0,.1f);
        UIGraphics.resizeInTime(clickScale,.3f);
        deltaTime=0;
        active=true;
        }
    }
    public override void onMouseExit()
    {
        if(!active)
        {
        UIGraphics.resizeInTime(defaultScale,.1f);
        }
    }
    ///MYSZKA
    void dragWhileCardIsClicked()
{
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0;
    transform.position = mousePos;
}
    public Vector3 getDefaultPosition()
    {
        return defaultPosition;
    }
    public void setDefaultPosition(Vector3 newPosition)
    {
        defaultPosition=newPosition;
    }
    public void setDefaultRotation(float newRotation)
    {
        defaultRotation=newRotation;
    }
    public void toDefaultLocRotInTime()
    {
        UIGraphics.rotateInTime(defaultRotation,.2f);
        UIGraphics.transformInTime(defaultPosition,.2f);
    }
        public void toDefaultLocRotScale()
    {
        Vector3 start = transform.position;
        spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, defaultRotation);
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y, start.z);
        transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
    }
    public void toDefaultScale()
    {
        UIGraphics.resizeInTime(defaultScale,.2f);
    }
    public void setDragging(bool boole)
    {
        isHold = boole;
    }
    public ButtonPositioner getButtonPositioner()
    {
        return buttonPositioner;
    }

}