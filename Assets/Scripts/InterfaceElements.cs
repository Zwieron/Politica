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
        BlockHands(blockade);
    }

    public void BlockHands(bool block)
    {
        foreach (HandVisual hand in hands)
        {
            if(block==false)
            {
                hand.SetBlockade(block);
            }
            else if(hand != selectedHand)
            {
                hand.SetBlockade(block);
            }
        }
    }
        public void SetBlockade(bool blockade, HandVisual selectedHand)
    {
        this.blockade = blockade;
        this.selectedHand = selectedHand;
    }
        public void SetBlockade(bool blockade)
    {
        this.blockade = blockade;
    }
    public void AddHand(HandVisual hand)
    {
        hands.Add(hand);
    }
}
