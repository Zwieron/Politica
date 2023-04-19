using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Player
{
    Party party = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void drawCards(Deck deck, int numCards)
    {
        hand.cards.Clear();
        for (int i = 0; i < numCards; i++)
        {
            hand.addCard(deck.drawCard());
        }
    }
}

