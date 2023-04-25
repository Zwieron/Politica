using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvertonWindow : MonoBehaviour
{
    Worldviews presentPublicWorldview;
    EconomicViews presentPublicEconomicView;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        presentPublicEconomicView = EconomicViews.Centrism;
        presentPublicWorldview = Worldviews.Centrism;
        textMesh = GetComponent<TextMesh>();
        textMesh.text = presentPublicWorldview + "\n" + presentPublicEconomicView;
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
}
