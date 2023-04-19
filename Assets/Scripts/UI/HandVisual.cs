using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVisual : MonoBehaviour
{
    Hand hand {get; set;}
    List<CardInteraction> cardInteractions = new List<CardInteraction>();
    public Vector2 handPosition = new Vector2(0,50);
    public float Offset = 120f;
    public float rotationOffset = 0;
    bool blockade = false;
    CardInteraction selectedCard;
    InterfaceElements interfaceElements;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blockHand(blockade);
    }
    public void refresh()
    {
        cardInteractions.Clear();
        foreach(Card c in hand.getCards())
        {
            cardInteractions.Add(c.GetCardInteraction());
            c.GetCardInteraction().setHandVisual(this);
        }
        calculatePositionInCenter();
        foreach(CardInteraction card in cardInteractions)
        {
            card.toDefaultLocRotScale();
        }
    }
    public void setSortHand()
    {
        foreach(CardInteraction card in cardInteractions)
        {
            card.SetDefaultOrder(card.GetSprite().sortingOrder);
        }
    }

    public void setRotationOffset(float rotationOffset)
    {
        this.rotationOffset = rotationOffset;
    }
    public void setHand(Hand hand)
    {
        this.hand = hand;
    }
    public Hand getHand()
    {
        return hand;
    }
    public void renderHand(bool y)
    {int i = 0;
        if(!y)
        {
        foreach(Card c in hand.getCards())
        {
            if (c==null)
            Debug.Log("no Card");
            c.GetCardInteraction().setDefaultPosition(new Vector3(handPosition.x + i * Offset,handPosition.y,0));
            c.GetCardInteraction().setDefaultRotation(-rotationOffset);
            i++;
        }
        }
        else
        {
        foreach(Card c in hand.getCards())
        {
            c.GetCardInteraction().setDefaultPosition(new Vector3(handPosition.x ,handPosition.y + i * Offset,0));
            c.GetCardInteraction().setDefaultRotation(-rotationOffset);
            i++;
        }
        }
    }
    public void setHandPosition(Vector2 handPosition)
    {
        this.handPosition = handPosition;
    }
     public void blockHand(bool block)
    {
        foreach (CardInteraction card in cardInteractions)
        {
            if(selectedCard==null || block==false)
            {
                card.setBlockade(block);
            }
            else if(card != selectedCard)
            {
                card.setBlockade(block);
            }
        }
    }
        public void setBlockade(bool blockade, CardInteraction selectedCard)
    {
        this.blockade = blockade;
        this.selectedCard = selectedCard;
        this.interfaceElements.setBlockade(blockade, this);
    }
        public void setBlockade(bool blockade)
    {
        this.blockade = blockade;
        this.selectedCard = null;
    }
    public void setInterfaceElements(InterfaceElements interfaceElements)
    {
        this.interfaceElements = interfaceElements;
        interfaceElements.addHand(this);
    }
    void calculatePositionInCenter()
    {
        Debug.Log("Stara pozycja: "+handPosition.ToString());
        float y = handPosition.y;
        float x = 0;
        x = (hand.getSize()*hand.getCards()[0].GetComponent<SpriteRenderer>().bounds.size.x/2)+(Offset*(hand.getSize()))/2;
        handPosition = new Vector2((Screen.width/2)-x/2,y);
        Debug.Log("Nowa pozycja: "+handPosition.ToString());
    }
    public void setYDimension(float y)
    {
        Debug.Log("Ustawianie Y na "+y.ToString());
        handPosition = new Vector2(handPosition.x,y);
        Debug.Log("Nowa pozycja: "+handPosition.ToString());
    }
}
