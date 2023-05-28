using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BiddingPhase : GamePhase
{
    public int totalIterations;
    int iteration = 0;
    public bool blockIfPassed = false;
    public int cardsDrawn;
    List<Player> winners = new List<Player>();
    Dictionary<Card, Player> winnersByCard = new Dictionary<Card, Player>();
    public AfterBiddingOvertonModifier econOvertonModifier;
    public AfterBiddingOvertonModifier worldviewOvertonModifier;
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        showCards();
    }

    // Update is called once per frame
    void Update()
    {
        if(blockIfPassed) //TODO sprawdzić potem
            blockBidButtonsAfterPassed();
        if(checkIfAllPlayersHavePassed())
        {
            finishBiddingPhaseIteration();
        }
    }
    void showCards()
    {
        if(game.getTable()==null)
        Debug.Log("No table");
        if(cardsDrawn<=deck.getDeckCount())
            game.getTable().drawCards(deck,cardsDrawn);
        else
            game.getTable().drawCards(deck,deck.getDeckCount());
        createButtonsAroundCardsOnTable(ButtonTypes.BidAction);
    }


    Player findWinner(Card card)
    {
        List<BidAction> actions = createListOfButtonsOfCard(card);
        int highestBid = -1;
        Player winner = null;
        Debug.Log(":FWF: "+card);
        if(actions.Count==0)
        {
            Debug.Log("No actions");
            return null;
        }
        foreach(BidAction action in actions)
        {
            if(action.getNewBidValue()>highestBid)
            {
                highestBid = action.getNewBidValue();
                winner = action.getPlayer();
                Debug.Log("Winner: " + winner);
            }
        }
        //zmiana sumy na overtonie
        Debug.Log(":FWF: econOvertonModifier: "+checkBiddingModifierToEconViews(highestBid, card.GetComponent<Character>()));
        econOvertonModifier.changeOfSum(checkBiddingModifierToEconViews(highestBid, card.GetComponent<Character>()));
        Debug.Log(":FWF: worldviewModifier: "+checkBiddingModifierToWorldviews(highestBid, card.GetComponent<Character>()));
        worldviewOvertonModifier.changeOfSum(checkBiddingModifierToWorldviews(highestBid, card.GetComponent<Character>()));
        return winner;
    }
    void findWinnerForEveryCard()
    {
        foreach(Card card in game.getTable().getHand().getCards())
        {
            Player winner = findWinner(card);
            winnersByCard.Add(card, winner);
            Debug.Log(":FWFEC:");
            Debug.Log("Card: " + card + " Winner: " + winner);
        }
    }
    void giveWonCardsToWinners()
    {
        foreach(KeyValuePair<Card, Player> pair in winnersByCard)
        {
            Debug.Log("Card: " + pair.Key + " Winner: " + pair.Value);
                croupier.changeCardsOwner(pair.Value, pair.Key);
        }
    }
    
    List<BidAction> createListOfButtonsOfCard(Card card)
    {
        List<BidAction> actions = new List<BidAction>();
        foreach(BidAction action in phaseButtonsManager.getButtons().OfType<BidAction>())
        {
            if(action.getCard()==null)
            Debug.Log("No card in action");
            if(action.getCard().Equals(card))
            {
                actions.Add(action);
            }
        }
        return actions;
    }
    void blockBidButtonsAfterPassed()
    {
        foreach(PassAction pas in phaseButtonsManager.getButtons().OfType<PassAction>())
        {
            if(pas.isPassed())
            foreach(BidAction action in phaseButtonsManager.getButtons().OfType<BidAction>())
            {
                if(action.getPlayer().Equals(pas.getPlayer()))
                action.GetComponent<Button>().setBlockade(true);
            }
        }
    }
    int checkBiddingModifierToEconViews(int bid, Character character)
    {
        
        int temp = (int)character.getEconomicView();
        return temp*bid;
    }
    int checkBiddingModifierToWorldviews(int bid, Character character)
    {
       int temp = (int)character.getWorldview()*bid;
       return temp*bid;
    }
    void finishBiddingPhaseIteration()
    {
            findWinnerForEveryCard();
            giveWonCardsToWinners();
            refreshPlayerHands();
            destroyButtons();
            econOvertonModifier.updateEconOvertonWindow();
            worldviewOvertonModifier.updateWorldviewOvertonWindow();
            iteration++;
            if(iteration==totalIterations)
            {
                foreach(HandVisual hand in  game.getInterfaceManager().getHands())
                {
                    foreach(CardInteraction card in hand.getCards())
                    {
                        card.setActive(false);
                    }
                }
                game.getGameInfo().setGamePhase(GamePhases.ActionPhase);
            }
            else
            showCards();
    }

}


