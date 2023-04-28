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
    public float player2Y = 400;
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
        card.GetComponent<CardInteraction>().GetSprite().sortingOrder = hand.getSize() + 1;
        hand.getOwner().getHandVisual().setDefaultPositionOfCards(false);
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

        card.transform.SetParent(canvas.transform);
        hand.addCard(card.GetComponent<Card>());
        card.GetComponent<CardInteraction>().GetSprite().sortingOrder = hand.getSize() + 1;
        hand.getOwner().getHandVisual().refresh();
        hand.getOwner().getHandVisual().setDefaultPositionOfCards(false);
        card.GetComponent<Card>().getCardInteraction().toDefaultLocRotScale();
    }
    public void createPlayer(string name, int playerNumber)
    {
        GameObject player;
        prefabInstantiator.instantiatePrefab(prefabCollection.player);
        player = GetComponent<PrefabInstantiator>().getLastPrefab();
        player.name = name;
        player.GetComponent<Player>().setPlayerNumber(playerNumber);
        gameInfo.addPlayer(player.GetComponent<Player>());
        gameInfo.addPlayerObj(player);
        if(playerNumber==2)
        {
            player.GetComponent<HandVisual>().setYDimension(player2Y);
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
    //BUTTONS/////////BUTTONS/////////BUTTONS/////////BUTTONS/////////BUTTONS/////////BUTTONS/////////BUTTONS/////////BUTTONS/////////BUTTONS/////////
    public void createBidButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.bidButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<BidAction>());
    }
    public void createPassButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.passButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<PassAction>());
    }
    public void createEndTurnButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.endTurnButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<EndTurnAction>());
    }
    public void createUndoTurnButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.undoTurnButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<UndoTurnAction>());
    }
    public void createActivateCardButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.activateCardButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<ActivateCardAction>());
    }
    //CHARACTER//ACTIONS/////////CHARACTER//ACTIONS/////////CHARACTER//ACTIONS/////////CHARACTER//ACTIONS/////////CHARACTER//ACTIONS/////////CHARACTER//ACTIONS/////////
    public void createExposeCharacterButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.exposeCharacterButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<ExposeCharacterButton>());
    }
        public void createBlockActionButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.blockActionButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<BlockActionButton>());
    }
        public void createInstitutionActionButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.institutionActionButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<InstitutionActionButton>());
    }
        public void createOvertakeInstitutionButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.overtakeInstitutionButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<OvertakeInstitutionButton>());
    }
        public void createStrengthenNotorietyButton(Vector2 position, GamePhase gamePhase)
    {
        prefabInstantiator.instantiatePrefab(prefabCollection.strengthenNotorietyButton,position);
        GameObject button = GetComponent<PrefabInstantiator>().getLastPrefab();
        button.transform.SetParent(canvas.transform,true);
        gamePhase.getPhaseButtonsManager().addButton(button.GetComponent<StrengthenNotorietyButton>());
    }
    //GETS///////////////////////GETS///////////////////////GETS///////////////////////GETS///////////////////////GETS///////////////////////GETS///////////////////////
    public PrefabInstantiator getPrefabInstantiator()
    {
        return prefabInstantiator;
    }
}
