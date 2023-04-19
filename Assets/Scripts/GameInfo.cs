using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{   public int playerNumber = 2;
    public Vector2 player1Pos;
    public Vector2 player2Pos;
    List<GameObject> playersObjs = new List<GameObject>();
    List<Player> players = new List<Player>();
    List<Party>  parties = new List<Party>();
    public Sprite cardSprite;
    List<Hand> hands = new List<Hand>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addParty(Party party)
    {
        parties.Add(party);
    }
    public void addPlayer(Player player)
    {
            players.Add(player);
            Debug.Log("player " + players.Count + " added");
    }
    public void addHand(Hand hand) 
    {
        hands.Add(hand);
    }
    public void addPlayerObj(GameObject playerObj)
    {
        playersObjs.Add(playerObj);
    }
    //GETSETS/////////////GETSETS/////////////GETSETS/////////////GETSETS/////////////GETSETS/////////////GETSETS/////////////GETSETS/////////////GETSETS/////////////GETSETS/////////////GETSETS///////////
    public List<GameObject> getPlayersObjs()
    {
        return playersObjs;
    }
    public List<Party> getParties()
    {
        return parties;
    }
    public List<Player> getPlayers()
    {
        return players;
    }
    public int getPlayerNumber()
    {
        return playerNumber;
    }

}
