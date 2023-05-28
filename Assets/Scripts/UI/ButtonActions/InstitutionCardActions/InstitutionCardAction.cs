using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstitutionCardAction : ButtonAction, SelectingCharacterButton
{
    protected Card card;
    protected CardSelector cardSelector;
    protected InstitutionActionManager institutionActionManager;
    public override void action(int value)
    {

    }
    public override void tooltip()
    {

    }
    public override void update()
    {

    }
    public override void reset()
    {

    }
    public override void setCard(Card card)
    {
        this.card = card;
    }
    public CardSelector getSelector()
    {
        return cardSelector;
    }
}
