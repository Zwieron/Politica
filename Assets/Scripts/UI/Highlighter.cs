using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void highlightYellow()
    {
        this.spriteRenderer.color = Color.yellow;
    }
    public void highlightWhite()
    {
        this.spriteRenderer.color = Color.white;
    }
}
