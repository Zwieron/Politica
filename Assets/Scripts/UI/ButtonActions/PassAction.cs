using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassAction : ButtonAction
{
    bool pass = false;
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
        pass=true;
    }
    public override void tooltip()
    {
        Debug.Log("Pass");
    }
    public bool isPassed()
    {
        return pass;
    }
}
