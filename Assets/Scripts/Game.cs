using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{   
    GameInfo gameInfo;
    InterfaceElements interfaceManager;
    PrefabModifier prefabModifier;
    GamePhases gamePhases=GamePhases.BiddingPhase;
    Table table;
    Converter converter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        prefabModifier = GetComponent<PrefabModifier>();
        gameInfo = GetComponent<GameInfo>();
        interfaceManager = GetComponent<InterfaceElements>();
        prefabModifier.createTable();
        startGamePhase(gamePhases);
    }
    void Update()
    {
    
    }
    void startGame()
    {
        for(int i = 0; i < gameInfo.getPlayerNumber(); i++)
        {
            prefabModifier.createPlayer("Player "+(i+1).ToString(), i+1);
            for(int j = 0; j < 5; j++)
            {
                prefabModifier.createCard(gameInfo.getPlayers()[i].getHand());
            }
            gameInfo.getPlayersObjs()[i].GetComponent<Player>().getHandVisual().refresh();
            gameInfo.getPlayersObjs()[i].GetComponent<Player>().getHandVisual().renderHand(false);
            gameInfo.getPlayersObjs()[i].GetComponent<Player>().getHandVisual().setSortHand();
            foreach(Card card in gameInfo.getPlayers()[i].getHand().getCards())
            {
                card.getCardInteraction().toDefaultLocRotScale();
            }
        }
    }
    public GameInfo getGameInfo()
    {
        return gameInfo;
    }
    public PrefabModifier getPrefabModifier()
    {
        return prefabModifier;
    }
    public InterfaceElements getInterfaceManager()
    {
        return interfaceManager;
    }
    public void setGamePhase(GamePhases phase)
    {
        gamePhases = phase;
    }
    public GamePhases getGamePhase()
    {
        return gamePhases;
    }
    public Table getTable()
    {
        return table;
    }
    public void setTable(Table table)
    {
        this.table = table;
    
    }
    void startGamePhase(GamePhases phase)
    {
        switch(phase)
        {
            case GamePhases.BiddingPhase:
                GetComponent<BiddingPhase>().enabled=true;
                GetComponent<ActionPhase>().enabled=false;
                GetComponent<PollPhase>().enabled=false;
                break;
            case GamePhases.ActionPhase:
                GetComponent<BiddingPhase>().enabled=false;
                GetComponent<ActionPhase>().enabled=true;
                GetComponent<PollPhase>().enabled=false;
                break;
            case GamePhases.PollPhase:
                GetComponent<BiddingPhase>().enabled=false;
                GetComponent<ActionPhase>().enabled=false;
                GetComponent<PollPhase>().enabled=true;
                break;
        }
    }
}

