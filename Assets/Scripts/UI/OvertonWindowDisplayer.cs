using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OvertonWindowDisplayer : MonoBehaviour
{
    public OvertonWindow overtonWindow;
    public TMP_Text economicText;
    public TMP_Text worldviewText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Display();
    }

    public void Display()
    {
        economicText.text = overtonWindow.getEconomicViewString();
        worldviewText.text = overtonWindow.getWorldviewString();
    }
}
