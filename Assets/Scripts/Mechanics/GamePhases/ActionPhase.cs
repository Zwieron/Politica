using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : GamePhase
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        createButtonsAroundPlayersHand();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createButtonsAroundPlayersHand()
    {
        foreach (Player player in game.getGameInfo().getPlayers())
        {
            foreach (Card card in player.getHand().getCards())
            {
                phaseButtonsManager.createButtonAroundCard(card, ButtonTypes.ActivateCardAction,Directions.UP);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<ActivateCardAction>().setPlayer(player);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<ActivateCardAction>().SetCard(card);
            }
            phaseButtonsManager.createDefaultButtonsForPlayer(player);
            player.gatherPlayerButtonActions(phaseButtonsManager.getButtons());
        }
    }
}
