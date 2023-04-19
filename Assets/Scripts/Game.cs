using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{   
    public int playerNumber = 2;
    public Vector2 player1Pos;
    public Vector2 player2Pos;
    PrefabInstantiator startingInstantiator;
    List<GameObject> playersObjs = new List<GameObject>();
    List<Player> players = new List<Player>();
    List<Party>  parties = new List<Party>();
    public Sprite cardSprite;
    List<Hand> hands = new List<Hand>();
    InterfaceElements interfaceManager;
    
    // Start is called before the first frame update
    void Start()
    {
        interfaceManager = GetComponent<InterfaceElements>();
        for(int i = 0; i < playerNumber; i++)
        {
            createPlayer("Player "+(i+1).ToString());
            for(int j = 0; j < 5; j++)
            {
                createCard(playersObjs[i].GetComponent<Hand>());
            }
            playersObjs[i].GetComponent<Player>().getHandVisual().refresh();
            playersObjs[i].GetComponent<Player>().getHandVisual().setSortHand();
        }
    }

    void createCard(Hand hand)
    {
        GameObject card = new GameObject("Card");
            card.AddComponent<Card>();
            card.GetComponent<Card>().SetCardState(CardState.InHand);
            hand.addCard(card.GetComponent<Card>());
            card.GetComponent<CardInteraction>().SetSprite(cardSprite);
            card.GetComponent<CardInteraction>().GetSprite().sortingOrder = hand.getSize() + 1;
            Debug.Log(hand.getCards().Count);
            
            if(players.IndexOf(hand.getOwner())==1){

                hand.getOwner().getHandVisual().setHandPosition(player2Pos);
                                hand.getOwner().getHandVisual().renderHand(false);
            }
            else{

                hand.getOwner().getHandVisual().setHandPosition(player1Pos);
                                hand.getOwner().getHandVisual().renderHand(false);
            }
             card.GetComponent<Card>().GetCardInteraction().toDefaultLocRotScale();
            Debug.Log("gruba akcja ");
    }

    void addParty(Party party)
    {
        parties.Add(party);
    }
    void createPlayer(string name)
    {
        GameObject player = new GameObject(name);
        player.AddComponent<Player>();
        player.AddComponent<Hand>();
        player.AddComponent<HandVisual>();
        player.GetComponent<HandVisual>().setHand(player.GetComponent<Hand>());
        player.GetComponent<Hand>().setHandVisual(player.GetComponent<HandVisual>());
        player.GetComponent<HandVisual>().setInterfaceElements(interfaceManager);
        player.GetComponent<Player>().setHandVisual(player.GetComponent<HandVisual>());
        player.AddComponent<Party>();
        player.GetComponent<Party>().setOwner(player.GetComponent<Player>());
        addParty(player.GetComponent<Party>());
        player.GetComponent<Hand>().setOwner(player.GetComponent<Player>());
        players.Add(player.GetComponent<Player>());
        hands.Add(player.GetComponent<Hand>());
        playersObjs.Add(player);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
    public List<GameObject> getPlayersObjs()
    {
        return playersObjs;
    }
        public List<Party> GetParties()
    {
        return parties;
    }
    public List<Player> GetPlayers()
    {
        return players;
    }
    public void setPrefabInstantiator(PrefabInstantiator instantiator)
    {
        this.startingInstantiator = instantiator;
    }
}
