using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidAction : ButtonAction
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action()
    {
        Debug.Log("bid");
    }
    public override void tooltip()
    {
        Debug.Log("button hover");
    }
}
