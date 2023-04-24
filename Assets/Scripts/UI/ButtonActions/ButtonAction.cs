using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public abstract class ButtonAction : MonoBehaviour
{
    public TMP_Text text;
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
