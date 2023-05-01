using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    Institution characterInstitution;
    public int characterNotoriety;
    int supportModifier;
    public Worldviews worldview;
    public EconomicViews economicView;
    public CharacterBuff characterBuff;
    List<ButtonTypes> availibleActions = new List<ButtonTypes>();
   CharacterActionsManager characterActionsManager;

    // Start is called before the first frame update
    void Start()
    {
      characterActionsManager = GetComponent<CharacterActionsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void checkAvailibleActions()
   {
      availibleActions.Clear();
      availibleActions.Add(ButtonTypes.ExposeCharacter);
      availibleActions.Add(ButtonTypes.StrengthenNotoriety);
      if(characterInstitution!=null)
      {
      availibleActions.Add(ButtonTypes.InstitutionAction);
      availibleActions.Add(ButtonTypes.BlockAction);
      }
      if(characterInstitution==null)
      availibleActions.Add(ButtonTypes.OvertakeInstitution);   
   }
   public List<ButtonTypes> getAvailibleActions()
   {
      return availibleActions;
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
    public CharacterActionsManager GetCharacterActionsManager()
    {
        return characterActionsManager;
    }
    public string getCharacterName()
    {
      return name;
    }

}
