using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvertonWindow : MonoBehaviour
{
    Worldviews presentPublicWorldview;
    EconomicViews presentPublicEconomicView;
    // Start is called before the first frame update
    void Start()
    {
        presentPublicEconomicView = EconomicViews.Centrism;
        presentPublicWorldview = Worldviews.Centrism;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeWorldview(Worldviews newWorldview)
    {
        presentPublicWorldview = newWorldview;
    }
    public void changeWorldview(int change)
    {   if(presentPublicWorldview + change < Worldviews.Anarchy && presentPublicWorldview + change > Worldviews.Fashizm)
            presentPublicWorldview += change;
        else if(change<0)
            presentPublicWorldview = Worldviews.Fashizm;
        else
            presentPublicWorldview = Worldviews.Anarchy;
    }
    public void changeEconomicView(EconomicViews newEconomicView)
    {
        presentPublicEconomicView = newEconomicView;
    }
    public void changeEconomicView(int change)
    {
        if(presentPublicEconomicView + change < EconomicViews.Socialism && presentPublicEconomicView + change > EconomicViews.Lasseizfaire)
            presentPublicEconomicView += change;
        else if(change<0)
            presentPublicEconomicView = EconomicViews.Lasseizfaire;
        else
            presentPublicEconomicView = EconomicViews.Socialism;
    }
    public string getWorldviewString()
    {
        switch(presentPublicWorldview)
        {
            case Worldviews.Fashizm:
                return "Fashizm";
            case Worldviews.Conservatism:
                return "Conservatism";
            case Worldviews.Centrism:
                return "Centrism";
            case Worldviews.Liberalism:
                return "Liberalism";
            case Worldviews.Anarchy:
                return "Anarchy";
            default:
                return "NULL";
        }
    }
    public string getEconomicViewString()
    {
        switch(presentPublicEconomicView)
        {
            case EconomicViews.Lasseizfaire:
                return "Leseferyzm";
            case EconomicViews.Liberalism:
                return "Liberalism";
            case EconomicViews.Centrism:
                return "Centrism";
            case EconomicViews.SocialDemocracy:
                return "Socdem";
            case EconomicViews.Socialism:
                return "Socialism";
            default:
                return "NULL";
        }
    }
    public EconomicViews getEconomicView()
    {
        return presentPublicEconomicView;
    }
    public Worldviews getWorldview()
    {
        return presentPublicWorldview;
    }
}
