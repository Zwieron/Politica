using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Vector3 mouseposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
    }
    void GetMousePosition()
    {
        mouseposition = Input.mousePosition;
        Debug.Log(mouseposition);

    }

}
