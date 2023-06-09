using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Player
{
    // Start is called before the first frame update
    void Start()
    {
        setStartingPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void drawCards(Deck deck, int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            Transform card = deck.drawTransform();
            if(card != null)
            game.getPrefabModifier().createCard(card, this.hand);
            deck.removeLastDrawnCard();
        }
        handVisual.refresh();
    }
    public override void setStartingPlayer()
    {
        setHand(GetComponent<Hand>());
        GetComponent<HandVisual>().setHand(GetComponent<Hand>());
        GetComponent<Hand>().setHandVisual(GetComponent<HandVisual>());
        setHandVisual(GetComponent<HandVisual>());
        game.getInterfaceManager().addHandVisual(GetComponent<HandVisual>());
        GetComponent<Hand>().setOwner(this);
    }

}

