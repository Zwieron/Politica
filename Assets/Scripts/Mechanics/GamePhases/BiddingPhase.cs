using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiddingPhase : GamePhase
{
    public int cardsDrawn;
    List<Party> winners = new List<Party>();
    Dictionary<Card, Party> winnersByCard = new Dictionary<Card, Party>();
    
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
    void showCards()
    {
        if(game.getTable()==null)
        Debug.Log("No table");
        game.getTable().drawCards(deck,cardsDrawn);
        foreach(Player player in game.getGameInfo().getPlayers())
        {
            game.getPrefabModifier().createPassButton(player.getHandVisual().getHandPosition(), this);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<PassAction>().setPlayer(player);
            foreach(Card card in game.getTable().getHand().getCards())
            {
                base.createButtonAroundCard(card, direction: player.buttonDirection);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<BidAction>().setParty(player.getParty());
            }
        }
    }
    int compareBids(int bid1, int bid2)
    {
        return Mathf.Max(bid1, bid2);
    }
    Party findWinner(Card card)
    {
        List<BidAction> actions = createListOfButtonsOfCard(card);
        int highestBid = 0;
        Party winner = null;
        foreach(BidAction action in actions)
        {
            if(action.getBidValue()>highestBid)
            {
                highestBid = action.getBidValue();
                winner = action.getParty();
            }
        }
        return winner;
    }
    List<BidAction> createListOfButtonsOfCard(Card card)
    {
        List<BidAction> actions = new List<BidAction>();
        foreach(BidAction action in buttons)
        {
            if(action.getCard()==card)
            {
                actions.Add(action);
            }
        }
        return actions;
    }

}

