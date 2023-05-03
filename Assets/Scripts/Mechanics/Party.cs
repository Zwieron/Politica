using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
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
    void sumSupportPercentage()
    {
        int tempSupport = 0;
        foreach(Card card in owner.getHand().getCards())
        {
            if(card.isCharacterCard())
            {
                Character character = card.GetComponent<Character>();
                tempSupport += character.getSupportModifier();
            }
        }
        supportPercentage = tempSupport;
    }

    public void changeFunds(int amount)
    {
        funds += amount;
    }
    public int getFunds()
    {
        return funds;
    }
    public void setFunds(int amount)
    {
        funds=amount;
    }
    public void setOwner(Player player)
    {
        this.owner = player;
    }

}
