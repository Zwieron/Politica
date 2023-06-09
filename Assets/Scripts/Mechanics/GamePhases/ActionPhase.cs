using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : GamePhase
{   
    Executioner executioner;
    public int cardsDrawn;
    public Deck MinistryDeck;
    public Deck MediaDeck;
    public Deck JudiciaryDeck;
    public Deck NGODeck;
    List<Deck> instituitonDecks  = new List<Deck>();
    List<Card> activeCards = new List<Card>();
    public ButtonAction registeredSelectAction;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        createDefaultPlayerButtons();
        instituitonDecks.Add(MinistryDeck);
        instituitonDecks.Add(MediaDeck);
        instituitonDecks.Add(JudiciaryDeck);
        instituitonDecks.Add(NGODeck);
        showCards();
    }

    // Update is called once per frame
    void Update()
    {   
        if(checkIfAllPlayersHavePassed())
        {
            finishActionPhase();
        }
        displayActionButtonsWhenCardIsActive();
        displaySelectButtonsWhenSelectingActionIsActive();
        if(phaseButtonsManager.checkIfAnySelectButtonIsSelected())
        {
            phaseButtonsManager.clearSelectCardButtons();
        }
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
    void displayActionButtonsWhenCardIsActive()
    {
        bool clear = false;
        foreach(Player player in game.getGameInfo().getPlayers())
        {
            foreach(Card card in player.getHand().getCards())
            {
                if(card.getCardInteraction().isActive()&&
                    !activeCards.Contains(card)&&player.getSelectedAction()==null&&
                        card.GetCardActionsManager().getCardActionToExecute()==null)
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
    void displaySelectButtonsWhenSelectingActionIsActive() //TODO: polimorfizm tej funkcji
    {
        Player player = game.getTurnManager().getCurrentPlayer();
        foreach(Card card in player.getHand().getCards())
        {
            if(card.isCardActionSelecting(registeredSelectAction))
            {
                displaySelectButtons(card, player);
                registeredSelectAction = card.GetCardActionsManager().getActiveCardAction();
            }
        }
    }
    void displaySelectButtons(Card card, Player player)
    {
        if(card is Character)
        {
            foreach(Card institutionCard in game.getTable().getHand().getCards())
                {
                    SelectingCharacterButton button = (SelectingCharacterButton)card.GetCardActionsManager().getActiveCardAction();
                    phaseButtonsManager.createSelectButtonForActivatedInstitutionCard(institutionCard, player, button);
                }
        }
        if(card is Institution)
        {
            foreach(Card characterCard in game.getTable().getHand().getCards())
                {
                    SelectingCharacterButton button = (SelectingCharacterButton)card.GetCardActionsManager().getActiveCardAction();
                    // phaseButtonsManager.createSelectButtonForActivatedCharacterCard(characterCard, player, button);
                }
        }
    } 
    void finishActionPhase()
    {
            executioner = gameObject.AddComponent<Executioner>();
            foreach(Player player in game.getGameInfo().getPlayers())
            {
                foreach(Card card in player.getHand().getCards())
                {
                    if(card is Character)
                    {
                        executioner.addAction(card.GetCardActionsManager().getCardActionToExecute());
                    }
                }
            }
            executioner.executeActions();
            refreshPlayerHands();
            Destroy(executioner);
            destroyButtons();
            Debug.Log("Action Phase finished");
            game.getGameInfo().setGamePhase(GamePhases.PollPhase);
    }
}
