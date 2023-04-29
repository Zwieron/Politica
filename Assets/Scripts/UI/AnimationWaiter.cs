using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWaiter : MonoBehaviour
{
    float animationTime;
    float deltaTime = 0;
    bool animationFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool AnimationWait()
    {
        if (!animationFinished)
        {
            deltaTime += Time.deltaTime;
            if (deltaTime >= animationTime)
            {
                deltaTime = 0;
                animationFinished = true;
                return true;
            }
            else
            return false;
        }
        else
            return true;
    }
    public void SetAnimationTime(float time)
    {
        this.animationTime = time;
    }
    public bool isFinished()
    {
        return animationFinished;
    }
    public void Reset()
    {
        animationFinished = false;
    }
    

    
}
