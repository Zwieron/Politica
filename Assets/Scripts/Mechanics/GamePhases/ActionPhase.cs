using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : GamePhase
{
    // Start is called before the first frame update
    new void Start()
    {
        game = GetComponent<Game>();
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
                createButtonAroundCard(card, ButtonTypes.ActivateCardAction,player.buttonDirection);
            }
        }
    }
}
