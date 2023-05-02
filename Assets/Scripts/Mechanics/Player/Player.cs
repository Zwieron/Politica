using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    public Party party;
    protected Hand hand;
    protected HandVisual handVisual;
    public bool playerTurn = false;
    public Game game;
    public Directions buttonDirection;
    public List<ButtonAction> playerActions;
    ButtonAction selectedAction;

    // Start is called before the first frame update
    void Start()
    {   
        playerActions = new List<ButtonAction>();
        game = FindObjectOfType<Game>();
        setStartingPlayer();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void startTurn()
    {
        playerTurn = true;
    }
    public void endTurn()
    {
        playerTurn = false;
        clearSelectedAction();
    }
    public bool isPlayerTurn()
    {
        return playerTurn;
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
            case 1: buttonDirection = Directions.DOWN;
            break;
            case 2: buttonDirection = Directions.UP;
            break;
            case 3: buttonDirection = Directions.LEFT;
            break;
            case 4: buttonDirection = Directions.RIGHT;
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
    public void gatherPlayerButtonActions(List<ButtonAction> actions)
    {
        playerActions.Clear();
        foreach(ButtonAction action in actions)
        {
            if(action.getPlayer().Equals(this))
            {
                playerActions.Add(action);
            }
        }
    }
    public List<ButtonAction> getPlayerButtonActions()
    {
        return playerActions;
    }
    public void clearSelectedAction()
    {
        selectedAction = null;
    }
    public void selectAction(ButtonAction action)
    {
        selectedAction = action;
    }
    public ButtonAction getSelectedAction()
    {
        return selectedAction;
    }
}
