using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    Party characterParty;
    Institution characterInstitution;
    int characterLevel;
    int supportModifier;
    public Worldviews worldview;
    public EconomicViews economicView;
    public CharacterBuff characterBuff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getSupportModifier()
    {
        return supportModifier;
    }
     public void setParty(Party party)
     {
        characterParty = party;
     }
     public void setInstitution(Institution institution)
     {
        characterInstitution = institution;
     }
     public void setLevel(int level)
     {
        characterLevel = level;
     }
     public void changeLevel(int change)
     {
        characterLevel += change;
     }
}
