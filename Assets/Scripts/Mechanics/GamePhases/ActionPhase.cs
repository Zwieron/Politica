using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : GamePhase
{   
    public int cardsDrawn;
    public Deck MinistryDeck;
    public Deck MediaDeck;
    public Deck JudiciaryDeck;
    public Deck NGODeck;
    List<Deck> instituitonDecks  = new List<Deck>();
    List<Card> activeCards = new List<Card>();
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        createPlayButtonsAroundPlayersHand();
        instituitonDecks.Add(MinistryDeck);
        instituitonDecks.Add(MediaDeck);
        instituitonDecks.Add(JudiciaryDeck);
        instituitonDecks.Add(NGODeck);
        showCards();
    }

    // Update is called once per frame
    void Update()
    {
        displayActionButtonsWhenCardIsActive();
        foreach(Player player in game.getGameInfo().getPlayers())
        {
            player.gatherPlayerButtonActions(phaseButtonsManager.getButtons());
        }
    }
    void showCards()
    {
        foreach(Deck decker in instituitonDecks)
        {
            if(cardsDrawn<=decker.getDeckCount())
            game.getTable().drawCards(decker,cardsDrawn);
        else
            game.getTable().drawCards(decker,decker.getDeckCount());
        }
    }
    void createPlayButtonsAroundPlayersHand()
    {
        foreach (Player player in game.getGameInfo().getPlayers())
        {
            foreach (Card card in player.getHand().getCards())
            {
                Directions direction = (Directions)((int)player.buttonDirection*-1);
                phaseButtonsManager.createButtonAroundCard(card, ButtonTypes.ActivateCardAction,direction);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<ActivateCardAction>().setPlayer(player);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<ActivateCardAction>().setCard(card);
            }
            phaseButtonsManager.createDefaultButtonsForPlayer(player);
            player.gatherPlayerButtonActions(phaseButtonsManager.getButtons());
        }
    }
    void displayActionButtonsWhenCardIsActive()
    {
        bool clear = false;
        foreach(Player player in game.getGameInfo().getPlayers())
        {
            foreach(Card card in player.getHand().getCards())
            {
                if(card.getCardInteraction().isActive()&&!activeCards.Contains(card))
                {
                    activeCards.Add(card);
                    phaseButtonsManager.createButtonsForActivatedCharacterCard(card, player);            
                }
                else if(!card.getCardInteraction().isActive()&&activeCards.Contains(card))
                {
                    activeCards.Remove(card);
                    clear = true;
                }
            }
        }
        if(clear)
        {
            phaseButtonsManager.clearActiveCardButtons();
        }
    }
    
}
