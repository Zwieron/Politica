using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardAction : ButtonAction
{
    Card card;
    CardSelector cardSelector;
    bool selected = false;
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
        cardSelector.selectCard(card);
        selected = true;
    }
    public override void tooltip()
    {
        Debug.Log("Select");
    }
    public override void update()
    {}
    public override void reset()
    {}
    public override void setCard(Card card)
    {
        this.card = card;
    }
    public void setSelector(CardSelector selector)
    {
        this.cardSelector = selector;
    }
    public CardSelector getSelector()
    {
        return cardSelector;
    }
    public bool isSelected()
    {
        return selected;
    }
    public Card getCard()
    {
        return card;
    }

}
