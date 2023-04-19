using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceElements : MonoBehaviour
{
    bool blockade = false;
    HandVisual selectedHand;
    List<HandVisual> hands = new List<HandVisual>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blockHands(blockade);
    }

    public void blockHands(bool block)
    {
        foreach (HandVisual hand in hands)
        {
            if(block==false)
            {
                hand.setBlockade(block);
            }
            else if(hand != selectedHand)
            {
                hand.setBlockade(block);
            }
        }
    }
        public void setBlockade(bool blockade, HandVisual selectedHand)
    {
        this.blockade = blockade;
        this.selectedHand = selectedHand;
    }
        public void setBlockade(bool blockade)
    {
        this.blockade = blockade;
    }
    public void addHand(HandVisual hand)
    {
        hands.Add(hand);
    }
}
