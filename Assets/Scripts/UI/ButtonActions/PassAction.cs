using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassAction : ButtonAction
{
    public bool newPass = false;
    public bool oldPass = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action(int i)
    {
        newPass=true;
        Debug.Log("Pass clicked");
    }
    public override void tooltip()
    {
        Debug.Log("Pass");
    }
    public bool isPassed()
    {
        return oldPass;
    }
    public override void update()
    {
        if(newPass)
        oldPass = true;
        Debug.Log("Pass updated");
    }
    public override void reset()
    {
        newPass = false;
    }
        public override void setCard(Card card)
    {}
}

