using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidAction : ButtonAction
{
    public Party party;
    int newPartyFunds;
    Card card;
    int newBidValue;
    int oldBidValue;
    
    // Start is called before the first frame update
    void Start()
    {
        party = player.getParty();
        newPartyFunds = party.getFunds();
    }

    // Update is called once per frame
    void Update()
    {
        valueToText();
    }
    public override void action(int actionValue)
    {
        newPartyFunds -= actionValue;
        Debug.Log(newPartyFunds.ToString());
        newBidValue += actionValue;
        Debug.Log(newBidValue.ToString());
    }
    public override void tooltip()
    {
        Debug.Log("button hover");
    }
    public int getNewBidValue()
    {
        return newBidValue;
    }
    public Card getCard()
    {
        return card;
    }
    public override void setCard(Card card)
    {
        this.card = card;
    }
    public void setParty(Party party)
    {
        this.party = party;
    }
    public Party getParty()
    {
        return party;
    }
    public void valueToText()
    {
        text.text = newBidValue.ToString();
    }
    public override void update()
    {
        oldBidValue = newBidValue;
        party.setFunds(newPartyFunds);
    }
    public override void reset()
    {
        newBidValue = oldBidValue;
        newPartyFunds = party.getFunds();
    }
}
