using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public List<Character> partyMembers = new List<Character>();
    public int supportPercentage;
    Player owner;
    int funds;
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
            tempSupport += character.getSupportModifier();
        }
        supportPercentage = tempSupport;
    }

    public void ChangeFunds(int amount)
    {
        funds =+ amount;
    }
    public void setOwner(Player player)
    {
        this.owner = player;
    }

}
