using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{   
    PrefabInstantiator instantiator;
    GameInfo gameInfo;
    InterfaceElements interfaceManager;
    PrefabModifier prefabModifier;
    
    
    // Start is called before the first frame update
    void Start()
    {
        prefabModifier = GetComponent<PrefabModifier>();
        gameInfo = GetComponent<GameInfo>();
        instantiator = GetComponent<PrefabInstantiator>();
        interfaceManager = GetComponent<InterfaceElements>();
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

    // void createCard(Hand hand)
    // {
    //     GameObject card = new GameObject("Card");
    //         card.AddComponent<Card>();
    //         card.GetComponent<Card>().SetCardState(CardState.InHand);
    //         hand.addCard(card.GetComponent<Card>());
    //         card.GetComponent<CardInteraction>().SetSprite(cardSprite);
    //         card.GetComponent<CardInteraction>().GetSprite().sortingOrder = hand.getSize() + 1;
    //         Debug.Log(hand.getCards().Count);
            
    //         if(gameInfo.getPlayers().IndexOf(hand.getOwner())==1){

    //             hand.getOwner().getHandVisual().setHandPosition(player2Pos);
    //                             hand.getOwner().getHandVisual().renderHand(false);
    //         }
    //         else{

    //             hand.getOwner().getHandVisual().setHandPosition(player1Pos);
    //                             hand.getOwner().getHandVisual().renderHand(false);
    //         }
    //          card.GetComponent<Card>().GetCardInteraction().toDefaultLocRotScale();
    //         Debug.Log("gruba akcja ");
    // }
    // void createPlayer(string name)
    // {
    //     GameObject player = new GameObject(name);
    //     player.AddComponent<Player>();
    //     player.AddComponent<Hand>();
    //     player.AddComponent<HandVisual>();
    //     player.GetComponent<HandVisual>().setHand(player.GetComponent<Hand>());
    //     player.GetComponent<Hand>().setHandVisual(player.GetComponent<HandVisual>());
    //     player.GetComponent<HandVisual>().setInterfaceElements(interfaceManager);
    //     player.GetComponent<Player>().setHandVisual(player.GetComponent<HandVisual>());
    //     player.AddComponent<Party>();
    //     player.GetComponent<Party>().setOwner(player.GetComponent<Player>());
    //     gameInfo.addParty(player.GetComponent<Party>());
    //     player.GetComponent<Hand>().setOwner(player.GetComponent<Player>());

    //     gameInfo.addHand(player.GetComponent<Hand>());
    //     gameInfo.addPlayerObj(player);
    // }
    // Update is called once per frame
    void Update()
    {
    
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
