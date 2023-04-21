using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerNumber;
    Party party;
    protected GameObject ggameObject;
    protected Hand hand;
    protected HandVisual handVisual;
    public bool user;
    public Game game;

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
    public virtual void setStartingPlayer()
    {
        setHand(GetComponent<Hand>());
        GetComponent<HandVisual>().setHand(GetComponent<Hand>());
        GetComponent<Hand>().setHandVisual(GetComponent<HandVisual>());
        GetComponent<HandVisual>().setInterfaceElements(game.getInterfaceManager());
        setHandVisual(GetComponent<HandVisual>());
        GetComponent<Party>().setOwner(this);
        GetComponent<Hand>().setOwner(this);
    }
}
