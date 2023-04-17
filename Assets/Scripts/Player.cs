using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Party party;
    GameObject ggameObject;
    Hand hand;
    HandVisual handVisual;
    public bool user;

    // Start is called before the first frame update
    void Start()
    {
        if(user==false)
        {
            hand.SetBlockade(true);
        }
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
}
