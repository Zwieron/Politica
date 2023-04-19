using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{   
    PrefabInstantiator instantiator;
    GameInfo gameInfo;
    InterfaceElements interfaceManager;
    PrefabModifier prefabModifier;
    GamePhase currentPhase;

    
    
    // Start is called before the first frame update
    void Start()
    {
        prefabModifier = GetComponent<PrefabModifier>();
        gameInfo = GetComponent<GameInfo>();
        instantiator = GetComponent<PrefabInstantiator>();
        interfaceManager = GetComponent<InterfaceElements>();
        startGame();
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
                card.GetCardInteraction().toDefaultLocRotScale();
            }
        }
    }
    public GameInfo getGameInfo()
    {
        return gameInfo;
    }
    public  PrefabInstantiator getInstantiator()
    {
        return instantiator;
    }
    public InterfaceElements getInterfaceManager()
    {
        return interfaceManager;
    }
}
