using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiddingPhase : GamePhase
{

    List<Card> cards = new List<Card>();
    List<Party> parties = new List<Party>();
    List<Party> winners = new List<Party>();
    List<Bidding> biddings = new List<Bidding>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< game.getGameInfo().getPlayers().Count ; i++)
        {
            cards.Add(deck.drawCard());
        }
        for(int i = 0; i< game.getGameInfo().getPlayers().Count ; i++)
        {
            biddings.Add(new Bidding(game.getGameInfo().getParties()[i], cards));
            parties.Add(biddings[i].GetParty());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Party CheckWhichPartyWinsBiddingOnACard(Card card)
    {
        Bidding biggestBid = new Bidding(new Party(), cards);
        for(int i = 0; i< parties.Count ; i++)
        {
            if(biggestBid.GetCardsBid(card)<biddings[i].GetCardsBid(card))
            {
                biggestBid = biddings[i];
            }
        }
        return biggestBid.GetParty();
    }
    void CheckWinnerForEveryCard()
    {
        foreach(Card card in cards)
        {
            winners.Add(CheckWhichPartyWinsBiddingOnACard(card));
        }
    }
}
public class Bidding
{
    Party party;
    Dictionary<Card,int> cardBids = new Dictionary<Card,int>();

    public Bidding(Party party, List<Card> cards)
    {
        this.party = party;
        foreach (Card card in cards)
        {
            cardBids.Add(card, 0);
        }
    }

    public void PartyBidsFundsOnASelectedCard(Card card, int funds)
    {
        party.ChangeFunds(-funds);
        cardBids[card] += funds;
    }

    public Party GetParty()
    {return party;
    }
    public int GetCardsBid(Card card)
    {
        return cardBids[card];
    
    }

}
