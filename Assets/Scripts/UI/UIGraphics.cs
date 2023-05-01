using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGraphics : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool animationFinished=false;
    // Start is called before the first frame update
    void Start()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {   
    }
    public void resizeInTime(float ratio,  float seconds)
    {
        StartCoroutine(ResizeInTimeCoroutine(ratio, seconds));
    }
    public void transformInTime(Vector3 position, float seconds)
    {
        StartCoroutine(TransformInTimeCoroutine(position, seconds));
    }

    public void rotateInTime(float degrees, float seconds)
    {
        StartCoroutine(RotateInTimeCoroutine(degrees, seconds));
    }


    IEnumerator ResizeInTimeCoroutine(float ratio, float seconds)
    {
        //What does this code do? 
        //It lerps the scale of the sprite to the ratio in time in seconds
        float time = 0;
        float start = spriteRenderer.transform.localScale.x;
        float end = ratio;
        while (time < seconds)
        {
            float scale = Mathf.Lerp(start, end, time / seconds);
            spriteRenderer.transform.localScale = new Vector3(scale, scale, scale);
            time += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator TransformInTimeCoroutine(Vector3 position, float seconds)
    {
        //What does this code do? 
        //It lerps the position of the sprite to the new position in time in seconds
        float time = 0;
        Vector3 start = spriteRenderer.transform.position;
        Vector3 end = position;
        while (time < seconds)
        {
            float x = Mathf.Lerp(start.x, end.x, time / seconds);
            float y = Mathf.Lerp(start.y, end.y, time / seconds);
            spriteRenderer.transform.position = new Vector3(x, y, start.z);
            time += Time.deltaTime;
            yield return null;
        }
    
    }
    IEnumerator RotateInTimeCoroutine(float degrees, float seconds)
    {
        //What does this code do? 
        //It lerps the scale of the sprite to the ratio in time in seconds
        float time = 0;
        float start = spriteRenderer.transform.rotation.eulerAngles.z;
        float end = degrees;
        while (time < seconds)
        {
            float scale = Mathf.Lerp(start, end, time / seconds);
            spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, scale);
            time += Time.deltaTime;
            yield return null;
        }
    }
    public void setSpriteRenderer(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
    }
}

