using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvertonWindow : MonoBehaviour
{
    string presentPublicWorldview;
    string presentPublicEconomicView;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = presentPublicWorldview + "\n" + presentPublicEconomicView;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
