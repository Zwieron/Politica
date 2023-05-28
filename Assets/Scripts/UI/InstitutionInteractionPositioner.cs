using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstitutionInteractionPositioner : MonoBehaviour
{
    bool gotInstitution = false;
    public bool isIdle = true;
    Character character;
    Institution institution;
    public GameObject idlePosition;
    public GameObject activePosition;
    Vector2 idleInstitutionPosition;
    Vector2 activeInstitutionPosition;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        Debug.Log(character.gameObject.name + " " + idleInstitutionPosition + " " + activeInstitutionPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(gotInstitution && institution.getCardInteraction().getBlockade() == false)
        {
            institution.getCardInteraction().setBlockade(true);
        }
        idleInstitutionPosition = idlePosition.transform.position;
        activeInstitutionPosition = activePosition.transform.position;
        if(character.getInstitution()!= null && gotInstitution == false && character.getInstitution().GetHand().Equals(character.GetHand()))
        {
            institution = character.getInstitution();
            institution.getCardInteraction().setDefaultPosition(idleInstitutionPosition);
            institution.getCardInteraction().toDefaultLocRotScale();

            institution.gameObject.transform.SetParent(character.getCardInteraction().GetCanvas().gameObject.transform);
            gotInstitution = true;
        }
        if(gotInstitution)
        {
            if(character.getCardInteraction().isActivated() == true)
            {
                institution.gameObject.transform.position = activeInstitutionPosition;
                institution.getCardInteraction().GetSprite().sortingOrder = 40;
                isIdle = false;
            }
            else
            {
                institution.gameObject.transform.position = idleInstitutionPosition;
                institution.getCardInteraction().GetSprite().sortingOrder = -1;
                isIdle = true;
            }
        }
    }
}
