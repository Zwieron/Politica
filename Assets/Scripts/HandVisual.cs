using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVisual : MonoBehaviour
{
    Hand hand {get; set;}
    public Vector2 handPosition;
    public float Offset = 120f;
    public float rotationOffset = 0;
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
    }
    public void SetSortHand()
    {
        foreach(Card card in hand.GetCards())
        {
            card.SetDefaultOrder(card.GetSprite().sortingOrder);
        }
    }

    public void setRotationOffset(float rotationOffset)
    {
        this.rotationOffset = rotationOffset;
    }
    public void SetHand(Hand hand)
    {
        this.hand = hand;
    }
    public Hand GetHand()
    {
        return hand;
    }
    public void RenderHand(bool y)
    {int i = 0;
        if(!y)
        {
        foreach(Card c in hand.GetCards())
        {
            c.GetCardInteraction().SetDefaultPosition(new Vector3(handPosition.x + i * Offset,handPosition.y,0));
            c.GetCardInteraction().SetDefaultRotation(-rotationOffset);
            i++;
        }
        }
        else
        {
        foreach(Card c in hand.GetCards())
        {
            c.GetCardInteraction().SetDefaultPosition(new Vector3(handPosition.x ,handPosition.y + i * Offset,0));
            c.GetCardInteraction().SetDefaultRotation(-rotationOffset);
            i++;
        }
        }
    }
    public void setHandPosition(Vector2 handPosition)
    {
        this.handPosition = handPosition;
    }
}
