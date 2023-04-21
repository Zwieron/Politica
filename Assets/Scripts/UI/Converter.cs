using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter
{
    public List<CardInteraction> ConvertCardsToInteractions(List<Card> cards)
    {
        List<CardInteraction> interactions = new List<CardInteraction>();
        foreach (Card card in cards)
        {
            interactions.Add(card.GetComponent<CardInteraction>());
        }
        return interactions;
    }
}
