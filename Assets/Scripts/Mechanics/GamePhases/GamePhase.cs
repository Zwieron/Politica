using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class GamePhase : MonoBehaviour
{
    public Game game;
    public Deck deck;
    public Croupier croupier;
    public PhaseButtonsManager phaseButtonsManager;
    // Start is called before the first frame update
    protected void Start()
    {
        game = GetComponent<Game>();
        phaseButtonsManager = GetComponent<PhaseButtonsManager>();
        phaseButtonsManager.setGamePhase(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PhaseButtonsManager getPhaseButtonsManager()
    {
        return phaseButtonsManager;
    }
    protected void createButtonsAroundCardsOnTable(ButtonTypes buttonTypes)
    {
        foreach(Player player in game.getGameInfo().getPlayers())
        {

            foreach(Card card in game.getTable().getHand().getCards())
            {
                phaseButtonsManager.createButtonAroundCard(card,buttonTypes, direction: player.buttonDirection);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<ButtonAction>().setPlayer(player);
                game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<ButtonAction>().setCard(card);
            }
            phaseButtonsManager.createDefaultButtonsForPlayer(player);
            player.gatherPlayerButtonActions(phaseButtonsManager.getButtons());
        }
    }
    protected bool checkIfAllPlayersHavePassed()
    {
        int passedPlayers = 0;
        foreach(PassAction pas in phaseButtonsManager.getButtons().OfType<PassAction>())
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
}

