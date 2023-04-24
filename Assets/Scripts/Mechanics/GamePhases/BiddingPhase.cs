using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiddingPhase : GamePhase
{
    public int cardsDrawn;
    List<Card> cards = new List<Card>();
    List<Party> parties = new List<Party>();
    List<Party> winners = new List<Party>();
    Dictionary<Card, Button> buttons = new Dictionary<Card, Button>();
    // Start is called before the first frame update
    new void Start()
    {
        game = GetComponent<Game>();

        showCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Party CheckWhichPartyWinsBiddingOnACard(Card card)
    {
        return new Party();
    }
    void CheckWinnerForEveryCard()
    {
        foreach(Card card in cards)
        {
            winners.Add(CheckWhichPartyWinsBiddingOnACard(card));
        }
    }
        void showCards()
    {
        if(game.getTable()==null)
        Debug.Log("No table");
        game.getTable().drawCards(deck,cardsDrawn);
        foreach(Card card in game.getTable().getHand().getCards())
        {
            cards.Add(card);
            createButtonAroundCard(card, direction: Direction.DOWN);
        }
    }


}

