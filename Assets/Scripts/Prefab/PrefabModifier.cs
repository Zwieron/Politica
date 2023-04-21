using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabModifier : MonoBehaviour
{
    PrefabCollection  prefabCollection;
    PrefabInstantiator prefabInstantiator;
    GameInfo gameInfo;
    Game game;
    // Start is called before the first frame update
    void Awake()
    {
        prefabCollection = GetComponent<PrefabCollection>();
        if(GetComponent<PrefabCollection>()==null)
        Debug.Log("PrefabCollection not found");
        prefabInstantiator = GetComponent<PrefabInstantiator>();
        game = GetComponent<Game>();
        gameInfo = GetComponent<GameInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createCard(Hand hand)
    {
        Debug.Log(hand.getSize());
        if(hand==null)
        Debug.Log("No hand!");
        GameObject card;
        prefabInstantiator.instantiatePrefab(prefabCollection.card);
        card = prefabInstantiator.getLastPrefab();

        hand.addCard(card.GetComponent<Card>());
        card.GetComponent<CardInteraction>().setHandVisual(hand.getOwner().getHandVisual());
        card.GetComponent<CardInteraction>().GetSprite().sortingOrder = hand.getSize() + 1;
        hand.getOwner().getHandVisual().renderHand(false);
        card.GetComponent<Card>().GetCardInteraction().toDefaultLocRotScale();
    }
        public void createCard(Transform prefab, Hand hand)
    {
        Debug.Log(hand.getSize());
        if(hand==null)
        Debug.Log("No hand!");
        GameObject card;
        prefabInstantiator.instantiatePrefab(prefab);
        card = prefabInstantiator.getLastPrefab();

        hand.addCard(card.GetComponent<Card>());
        card.GetComponent<CardInteraction>().setHandVisual(hand.getOwner().getHandVisual());
        card.GetComponent<CardInteraction>().GetSprite().sortingOrder = hand.getSize() + 1;
        hand.getOwner().getHandVisual().refresh();
        hand.getOwner().getHandVisual().renderHand(false);
        card.GetComponent<Card>().GetCardInteraction().toDefaultLocRotScale();
    }
    public void createPlayer(string name, int playerNumber)
    {
        GameObject player;
        prefabInstantiator.instantiatePrefab(prefabCollection.player);
        player = GetComponent<PrefabInstantiator>().getLastPrefab();
        player.name = name;

        // player.GetComponent<Player>().setHand(player.GetComponent<Hand>());
        // player.GetComponent<Player>().setPlayerNumber(playerNumber);
        // player.GetComponent<HandVisual>().setHand(player.GetComponent<Hand>());
        // player.GetComponent<Hand>().setHandVisual(player.GetComponent<HandVisual>());
        // player.GetComponent<HandVisual>().setInterfaceElements(game.getInterfaceManager());
        // player.GetComponent<Player>().setHandVisual(player.GetComponent<HandVisual>());
        // player.GetComponent<Party>().setOwner(player.GetComponent<Player>());
        gameInfo.addParty(player.GetComponent<Party>());
        gameInfo.addPlayer(player.GetComponent<Player>());
        // player.GetComponent<Hand>().setOwner(player.GetComponent<Player>());
        gameInfo.addHand(player.GetComponent<Hand>());
        gameInfo.addPlayerObj(player);
        if(playerNumber==2)
        {
            player.GetComponent<HandVisual>().setYDimension(380);
        }
        Debug.Log(player.GetComponent<Hand>().getSize());
    }
    public void createTable()
    {
        if(prefabCollection==null)
        Debug.Log("No prefabCollection!");
        prefabInstantiator.instantiatePrefab(prefabCollection.table);
        GameObject table = GetComponent<PrefabInstantiator>().getLastPrefab();
        table.GetComponent<Table>().setGame(game);
        game.setTable(table.GetComponent<Table>());
    }
}
