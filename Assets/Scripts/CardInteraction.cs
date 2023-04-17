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
    public Vector3 defaultPosition;
    public UIGraphics UIGraphics;
    float deltaTime;
    bool isDragging = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (spriteRenderer == null)
        {
            Debug.LogError("Card: SpriteRenderer not found.");
        }
        UIGraphics = GetComponent<UIGraphics>();
    }

    // Update is called once per frame
    void Update()
{   if(!blocked)
    {
    checkState();

    if (isMouseOver && Input.GetMouseButtonDown(0))
    {
        onClick();
        isDragging = true;
    }
    if(!isMouseOver && Input.GetMouseButtonDown(0))
    {
        onUnclick();
    }

    if (isDragging)
    {
        DragCardWhileCardIsClicked();
        deltaTime += Time.deltaTime;
    }

    if (Input.GetMouseButtonUp(0))
    {
        if (isDragging)
        {
            onMouseUp();
        }
        isDragging = false;
    }
    }
}


    public override void onClick()
    {
        if(!active)
        {
        
        Debug.Log("Card Clicked");
        isDragging=true;


        }
    }
    public override void onUnclick()
    {
        if(active)
        {
            active=false;
            Debug.Log("Card UnClicked");
            UIGraphics.ResizeInTime(defaultScale, 0.2f);
            GetComponent<Card>().Sort();
            toDefaultLocationRotationInTime();
            GetComponent<Card>().GetHand().SetBlockade(false, GetComponent<Card>());
        }
    }
    public override void onHover()
    {
        if(!active)
        {
        UIGraphics.ResizeInTime(hoverScale,0.01f);
        Debug.Log("Card Hover");
        }
    }
    public override void onMouseUp()
    {
        if(deltaTime>.2f)
        {
        Debug.Log("Card Released");
        toDefaultLocationRotationInTime();
        isDragging=false;
        deltaTime=0;
        }
        else
        {
        active=true;
        isDragging=false;
        Debug.Log("Card Odklikd");
        GetComponent<Card>().GetSprite().sortingOrder=30;
        GetComponent<Card>().GetHand().SetBlockade(true, GetComponent<Card>());
       UIGraphics.TransformInTime(new Vector3(Screen.width/2,Screen.height/2,0),0.1f);
        UIGraphics.RotateInTime(0,.1f);
        UIGraphics.ResizeInTime(clickScale,.3f);
        deltaTime=0;
        }
    }
    public override void onMouseExit()
    {
        if(!active)
        {
        UIGraphics.ResizeInTime(defaultScale,.1f);
        }
    }
    ///MYSZKA
    void DragCardWhileCardIsClicked()
{
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0;
    transform.position = mousePos;
}
    public Vector3 GetDefaultPosition()
    {
        return defaultPosition;
    }
    public void SetDefaultPosition(Vector3 newPosition)
    {
        defaultPosition=newPosition;
    }
    public void SetDefaultRotation(float newRotation)
    {
        defaultRotation=newRotation;
    }
    public void toDefaultLocationRotationInTime()
    {
        UIGraphics.RotateInTime(defaultRotation,.2f);
        UIGraphics.TransformInTime(defaultPosition,.2f);
    }
        public void toDefaultLocationRotationScale()
    {
        Vector3 start = transform.position;
        spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, defaultRotation);
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y, start.z);
        transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
    }
    public void toDefaultScale()
    {
        UIGraphics.ResizeInTime(defaultScale,.2f);
    }
    public void setDragging(bool boole)
    {
        isDragging = boole;
    }


}