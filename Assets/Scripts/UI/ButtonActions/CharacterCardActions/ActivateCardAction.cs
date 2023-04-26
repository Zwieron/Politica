using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCardAction : ButtonAction
{
    Card card;
    CardState newCardState = CardState.Unactive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action(int value)
    {
        newCardState = CardState.Activated;
    }
    public override void tooltip()
    {
        Debug.Log("Activate Card");
    }
    public override void update()
    {
        card.SetCardState(newCardState);
    }
    public override void reset()
    {
        newCardState = card.GetCardState();
    }
}
