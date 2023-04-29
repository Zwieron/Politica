using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : GamePhase
{
    List<Card> activeCards = new List<Card>();
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        createPlayButtonsAroundPlayersHand();
        
    }

    // Update is called once per frame
    void Update()
    {
        displayActionButtonsWhenCardIsActive();
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
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<ActivateCardAction>().SetCard(card);
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
