using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabModifier : MonoBehaviour
{
    PrefabCollection  prefabCollection;
    PrefabInstantiator prefabInstantiator;
    GameInfo gameInfo;
    public GameObject canvas;
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
        card.GetComponent<Card>().getCardInteraction().toDefaultLocRotScale();
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
        card.GetComponent<Card>().getCardInteraction().toDefaultLocRotScale();
    }
    public void createPlayer(string name, int playerNumber)
    {
        GameObject player;
        prefabInstantiator.instantiatePrefab(prefabCollection.player);
        player = GetComponent<PrefabInstantiator>().getLastPrefab();
        player.name = name;
        gameInfo.addParty(player.GetComponent<Party>());
        gameInfo.addPlayer(player.GetComponent<Player>());
        gameInfo.addHand(player.GetComponent<Hand>());
        gameInfo.addPlayerObj(player);
        if(playerNumber==2)
        {
            player.GetComponent<HandVisual>().setYDimension(380);
        }
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
        public void createButton(Vector2 position)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.bidButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.parent = canvas.transform;
    }
}
