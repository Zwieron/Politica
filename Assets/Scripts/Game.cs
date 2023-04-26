using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{   
    GameInfo gameInfo;
    InterfaceElements interfaceManager;
    PrefabModifier prefabModifier;
    Table table;
    Converter converter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        prefabModifier = GetComponent<PrefabModifier>();
        gameInfo = GetComponent<GameInfo>();
        interfaceManager = GetComponent<InterfaceElements>();
        prefabModifier.createTable();
        startGame();
        startGamePhase(gameInfo.getGamePhase());
    }
    void Update()
    {
        if(gameInfo.getGamePhaseChanged())
        {
            startGamePhase(gameInfo.getGamePhase());
            gameInfo.setGamePhaseChanged(false);
        }
    }
    void startGame()
    {
        for(int i = 0; i < gameInfo.getPlayerNumber(); i++)
        {
            prefabModifier.createPlayer("Player "+(i+1).ToString(), i+1);
        }
        gameInfo.getPlayers()[0].startTurn();
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

