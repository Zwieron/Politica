using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Card
{
    public string characterName;
    public Institution characterInstitution;
    public int characterNotoriety;
    int supportModifier;
    public Worldviews worldview;
    public EconomicViews economicView;
    public CharacterBuff characterBuff;
    

    // Start is called before the first frame update
    protected override void Awake()
    {
      base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public override void checkAvailibleActions()
   {
      availibleActions.Clear();
      availibleActions.Add(ButtonTypes.ExposeCharacter);
      availibleActions.Add(ButtonTypes.StrengthenNotoriety);
      if(characterInstitution!=null)
      {
      availibleActions.Add(ButtonTypes.InstitutionAct1);
      availibleActions.Add(ButtonTypes.BlockAction);
      }
      if(characterInstitution==null)
      availibleActions.Add(ButtonTypes.OvertakeInstitution);   
   }

    public int getSupportModifier()
    {
        return supportModifier;
    }
     public void setInstitution(Institution institution)
     {
        characterInstitution = institution;
     }
     public void setNotoriety(int notoriety)
     {
        characterNotoriety = notoriety;
     }
     public void changeNotoriety(int change)
     {
        characterNotoriety += change;
     }
     public int getNotoriety()
     {
      return characterNotoriety;
     }
     public EconomicViews getEconomicView()
     {
      return economicView;
     }
     public Worldviews getWorldview()
     {
      return worldview;
     }
     public Institution getInstitution()
     {
      return characterInstitution;
     }
    public string getCharacterName()
    {
      return name;
    }

}
