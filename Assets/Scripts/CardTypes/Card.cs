using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardAttributes cardAttributes;
    CardInteraction cardInteraction;
    SpriteRenderer spriteRenderer;
    public Vector2 colliderSize = new Vector2(3,5);
    UIGraphics uiGraphics;
    GameObject cardObject;
    BoxCollider2D boxCollider;
    Hand hand;

    // Start is called before the first frame update
    void Awake()
    {
        if(gameObject==null)
        cardObject = new GameObject();
        else
        cardObject = gameObject;
        cardObject.tag = "Card";
        Debug.Log(cardObject.GetInstanceID());
        spriteRenderer = cardObject.AddComponent<SpriteRenderer>();
        uiGraphics = cardObject.AddComponent<UIGraphics>();
        boxCollider = cardObject.AddComponent<BoxCollider2D>();
        boxCollider.size = colliderSize;
        cardAttributes =cardObject.AddComponent<CardAttributes>();
        cardInteraction = cardObject.AddComponent<CardInteraction>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public CardInteraction GetCardInteraction()
    {
        return cardInteraction;
    }
    public void SetHand(Hand hand)
    {
        this.hand = hand;
    }
    public void SetSprite(Sprite sprite)
    {
        if(cardObject==null)
        Debug.Log("CardObject is null");
        if(spriteRenderer==null)
        spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer==null)
        Debug.Log("SpriteRenderer is null");
        if(sprite==null)
        Debug.Log("Sprite is null");
        if(spriteRenderer!=null && sprite!=null)
        spriteRenderer.sprite = sprite;
    }
    public SpriteRenderer GetSprite()
    {
        return spriteRenderer;
    }
    public GameObject  GetGameObject()
    {
        return cardObject;
    
    }
}
