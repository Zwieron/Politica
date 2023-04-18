using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardAttributes cardAttributes;
    CardInteraction cardInteraction;
    SpriteRenderer spriteRenderer;
    int defaultOrder = 0;
    public Vector2 colliderSize = new Vector2(3.6f,5);
    UIGraphics uiGraphics;
    GameObject cardObject;
    BoxCollider2D boxCollider;
    Hand hand;
    CardState cardState;

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
        if(uiGraphics==null)
        uiGraphics = cardObject.AddComponent<UIGraphics>();
        uiGraphics.setSpriteRenderer(cardObject.GetComponent<SpriteRenderer>());
        if(boxCollider==null)
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
    public Hand GetHand()
    {
        return hand;
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
    public void SetCardState(CardState cardState)
    {
        this.cardState = cardState;
    
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

}

public class InstitutionCard : Card
{
    Institution institution;
}

public class CharacterCard : Card
{
    Character character;
}

public class SpecialCard : Card
{

}
