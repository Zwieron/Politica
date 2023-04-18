using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{   
    public int playerNumber = 2;
    public Vector2 player1Pos;
    public Vector2 player2Pos;
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
            playersObjs[i].GetComponent<Player>().getHandVisual().Refresh();
            playersObjs[i].GetComponent<Player>().getHandVisual().SetSortHand();
        }
    }

    void createCard(Hand hand)
    {
        GameObject card = new GameObject("Card");
            card.AddComponent<Card>();
            card.GetComponent<Card>().SetCardState(CardState.InHand);
            hand.AddCard(card.GetComponent<Card>());
            card.GetComponent<Card>().SetSprite(cardSprite);
            card.GetComponent<Card>().GetSprite().sortingOrder = hand.GetSize() + 1;
            Debug.Log(hand.GetCards().Count);
            
            if(players.IndexOf(hand.GetOwner())==1){

                hand.GetOwner().getHandVisual().setHandPosition(player2Pos);
                                hand.GetOwner().getHandVisual().RenderHand(false);
            }
            else{

                hand.GetOwner().getHandVisual().setHandPosition(player1Pos);
                                hand.GetOwner().getHandVisual().RenderHand(false);
            }
             card.GetComponent<Card>().GetCardInteraction().toDefaultLocationRotationScale();
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
        player.GetComponent<HandVisual>().SetHand(player.GetComponent<Hand>());
        player.GetComponent<Hand>().SetHandVisual(player.GetComponent<HandVisual>());
        player.GetComponent<HandVisual>().SetInterfaceElements(interfaceManager);
        player.GetComponent<Player>().setHandVisual(player.GetComponent<HandVisual>());
        player.AddComponent<Party>();
        player.GetComponent<Party>().setOwner(player.GetComponent<Player>());
        addParty(player.GetComponent<Party>());
        player.GetComponent<Hand>().SetOwner(player.GetComponent<Player>());
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
}
