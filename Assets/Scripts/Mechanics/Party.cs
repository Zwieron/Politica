using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public List<Character> partyMembers = new List<Character>();
    public int supportPercentage;
    public int funds;
    // Start is called before the first frame update
    void Start()
    {
        funds = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SumSupportPercentage()
    {
        int tempSupport = 0;
        foreach(Character character in partyMembers)
        {
            tempSupport += character.supportModifier;
        }
        supportPercentage = tempSupport;
    }

}
