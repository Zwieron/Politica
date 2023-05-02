using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{   public int playerNumber = 2;
    public Vector2 player1Pos;
    public Vector2 player2Pos;
    List<GameObject> playersObjs = new List<GameObject>();
    List<Player> players = new List<Player>();
    GamePhases currentGamePhase=GamePhases.BiddingPhase;
    bool gamePhaseChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void addPlayer(Player player)
    {
            players.Add(player);
            Debug.Log("player " + players.Count + " added");
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
    public List<Player> getPlayers()
    {
        return players;
    }
    public int getPlayerNumber()
    {
        return playerNumber;
    }
    public void setGamePhase(GamePhases phase)
    {
        currentGamePhase = phase;
        gamePhaseChanged = true;
    }
    public GamePhases getGamePhase()
    {
        return currentGamePhase;
    }
    public bool getGamePhaseChanged()
    {
        return gamePhaseChanged;
    }
    public void setGamePhaseChanged(bool changed)
    {
        this.gamePhaseChanged = changed;
    }

}
