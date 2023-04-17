using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    public string Text;
    TextMeshProUGUI TextMeshProUGUI;
    public void SetText(string text)
    {
        Text = text;
        GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
