using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void action(int value);
    public abstract void tooltip();
}
