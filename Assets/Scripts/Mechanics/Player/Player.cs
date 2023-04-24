using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    public Party party;
    protected GameObject ggameObject;
    protected Hand hand;
    protected HandVisual handVisual;
    public bool user;
    public Game game;
    public Directions buttonDirection;

    // Start is called before the first frame update
    void Start()
    {   game = FindObjectOfType<Game>();
        setStartingPlayer();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setParty(Party party)
    {
        this.party = party;
    }
    public Party getParty()
    {
        return this.party;
    }
    public void setHand(Hand hand)
    {
        this.hand = hand;
    }
    public Hand getHand()
    {
        return  this.hand;
    }
    public void setHandVisual(HandVisual handVisual)
    {
        this.handVisual = handVisual;
    }
    public HandVisual getHandVisual()
    {
        return this.handVisual;
    }
    public void setGameObject(GameObject partyObj)
    {
        this.ggameObject = partyObj;
    }
    public GameObject getGameObject()
    {
        return this.ggameObject;
    }
    public void setPlayerNumber(int playerNumber)
    {
        this.playerNumber=playerNumber;
    }
        public void setGame(Game game)
    {
        this.game = game;
    }
        void setDirection(int playerNumber)
    {
        switch(playerNumber)
        {
            case 0: buttonDirection = Directions.DOWN;
            break;
            case 1: buttonDirection = Directions.UP;
            break;
            case 2: buttonDirection = Directions.LEFT;
            break;
            case 3: buttonDirection = Directions.RIGHT;
            break;
        }
    }
    public virtual void setStartingPlayer()
    {
        setHand(GetComponent<Hand>());
        GetComponent<HandVisual>().setHand(GetComponent<Hand>());
        GetComponent<Hand>().setHandVisual(GetComponent<HandVisual>());
        setHandVisual(GetComponent<HandVisual>());
        game.getInterfaceManager().addHandVisual(GetComponent<HandVisual>());
        GetComponent<Party>().setOwner(this);
        setParty(GetComponent<Party>());
        GetComponent<Hand>().setOwner(this);
        setHand(GetComponent<Hand>());
        setDirection(playerNumber);
        Debug.Log("Player " + playerNumber + " is starting");
    }
}
