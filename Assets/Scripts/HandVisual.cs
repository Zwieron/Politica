using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVisual : MonoBehaviour
{
    Hand hand {get; set;}
    public float handPosition;
    public float xOffset = 40f;
    public float rotationOffset = 10f;
    // Start is called before the first frame update
    void Start()
    {
         RenderHand();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetHand(Hand hand)
    {
        this.hand = hand;
    
    }
    public Hand GetHand()
    {
        return hand;
    }
    public void RenderHand()
    {
        int i = 0;
        foreach(Card c in hand.GetCards())
        {
            c.GetCardInteraction().SetDefaultPosition(new Vector3(handPosition + i * xOffset,50,0));
            c.GetCardInteraction().SetDefaultRotation(-rotationOffset * i);
            i++;
        }
    }
}
