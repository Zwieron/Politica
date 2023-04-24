using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BidAction : ButtonAction
{
    public Party party;
    Card card;
    int bidValue = 2;
    public TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        valueToText();
    }
    public override void action(int actionValue)
    {
        party.changeFunds(-actionValue);
        Debug.Log(party.getFunds().ToString());
        bidValue += actionValue;
        Debug.Log(bidValue.ToString());
    }
    public override void tooltip()
    {
        Debug.Log("button hover");
    }
    public int getBidValue()
    {
        return bidValue;
    }
    public Card getCard()
    {
        return card;
    }
    public void setCard(Card card)
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
        text.text = bidValue.ToString();
    }
}
