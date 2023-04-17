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
        UIGraphics=GetComponent<UIGraphics>();
    }

    // Update is called once per frame
    void Update() 
    {   if(isDragging)
        {
            DragCardWhileCardIsClicked();
        }
        else
        checkState();
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
            toDefaultLocationRotation();
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
        isDragging=false;
        deltaTime=0;
        }
        else
        {
        active=true;
        isDragging=false;
        Debug.Log("Card Odklikd");
       UIGraphics.TransformInTime(new Vector3(Screen.width/2,Screen.height/2,0),0.1f);
        transform.rotation=Quaternion.Euler(0,0,0);
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
            deltaTime += Time.deltaTime;
            Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z=0;
            transform.position=mousePos;
            Debug.Log(deltaTime);
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
    void toDefaultLocationRotation()
    {
        UIGraphics.RotateInTime(defaultRotation,.2f);
        UIGraphics.TransformInTime(defaultPosition,.2f);
    }
    public void setDragging(bool boole)
    {
        isDragging = boole;
    }


}