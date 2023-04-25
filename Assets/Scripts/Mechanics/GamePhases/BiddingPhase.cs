using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BiddingPhase : GamePhase
{
    public bool blockIfPassed = false;
    public int cardsDrawn;
    List<Player> winners = new List<Player>();
    Dictionary<Card, Player> winnersByCard = new Dictionary<Card, Player>();
    public AfterBiddingOvertonModifier econOvertonModifier;
    public AfterBiddingOvertonModifier worldviewOvertonModifier;
    
    // Start is called before the first frame update
    new void Start()
    {
        game = GetComponent<Game>();
        showCards();
    }

    // Update is called once per frame
    void Update()
    {
        if(blockIfPassed)
            blockBidButtonsAfterPassed();
        if(checkIfAllPlayersHavePassed())
        {
            findWinnerForEveryCard();
            giveWonCardsToWinners();
            foreach(Player player in game.getGameInfo().getPlayers())
            {
                player.getHandVisual().refresh();
            }
            foreach(ButtonAction button in buttons)
            {
                Destroy(button.gameObject);
            }
            econOvertonModifier.updateEconOvertonWindow();
            worldviewOvertonModifier.updateWorldviewOvertonWindow();
            game.getGameInfo().setGamePhase(GamePhases.ActionPhase);
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
        foreach(Player player in game.getGameInfo().getPlayers())
        {
            //pass button
            game.getPrefabModifier().createPassButton(player.getHandVisual().getHandPosition(), this);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<PassAction>().setPlayer(player);
            //end turn button
            Vector2  buttonPosition = new Vector2(player.getHandVisual().getHandPosition().x, player.getHandVisual().getHandPosition().y - 40);
            game.getPrefabModifier().createEndTurnButton(buttonPosition, this);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<EndTurnAction>().setPlayer(player);
            foreach(Card card in game.getTable().getHand().getCards())
            {
                base.createButtonAroundCard(card, direction: player.buttonDirection);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<BidAction>().setParty(player.getParty());
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<BidAction>().setPlayer(player);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<BidAction>().setCard(card);
            }
        }
    }
    bool checkIfAllPlayersHavePassed()
    {
        int passedPlayers = 0;
        foreach(PassAction pas in buttons.OfType<PassAction>())
        {
            if(pas.isPassed())
            passedPlayers++;
        }
        if(passedPlayers==game.getGameInfo().getPlayers().Count)
        {
            Debug.Log("All players passed");
            return true;
        }
        else 
            return false;
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
            if(action.getBidValue()>highestBid)
            {
                highestBid = action.getBidValue();
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
            Debug.Log(":GWCTW:");
            Debug.Log("Card: " + pair.Key + " Winner: " + pair.Value);
                croupier.changeCardsOwner(pair.Value, pair.Key);
        }
    }
    
    List<BidAction> createListOfButtonsOfCard(Card card)
    {
        List<BidAction> actions = new List<BidAction>();
        foreach(BidAction action in buttons.OfType<BidAction>())
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
        foreach(PassAction pas in buttons.OfType<PassAction>())
        {
            if(pas.isPassed())
            foreach(BidAction action in buttons.OfType<BidAction>())
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
}


