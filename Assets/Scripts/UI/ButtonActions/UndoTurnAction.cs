using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoTurnAction : ButtonAction
{
    bool turnUndone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turnUndone)
        {
            foreach(ButtonAction ba in player.getPlayerButtonActions())
            {
                ba.reset();
            }
            turnUndone=false;
        }
    }
    public override void action(int i)
    {
        turnUndone = true;
        Debug.Log("Turn undone");
    }
    public override void tooltip()
    {
        Debug.Log("Undo Turn");
    }
    public override void update()
    {}
    public override void reset()
    {}
    public override void setCard(Card card)
    {}
}
