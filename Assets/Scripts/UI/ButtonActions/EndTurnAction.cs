using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnAction : ButtonAction
{
    bool turnEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action(int value)
    {
        turnEnded = true;
        Debug.Log("Turn ended");
    }
    public override void tooltip()
    {
        Debug.Log("End Turn");
    }
    public void reset()
    {
        turnEnded = false;
    }
    public bool isTurnEnded()
    {
        return turnEnded;
    }
    void greyOut()
    {
        if(!player.isPlayerTurn())
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }
}
