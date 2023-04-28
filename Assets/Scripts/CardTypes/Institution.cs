using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Institution : MonoBehaviour
{
    public string institutionName;
    public string institutionDescription;
    public Character institutionOwner;
    public int insitutionLevel;
    public int institutionPrice;
    Institution blockedInstitution;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    abstract public void BlockadeAction();
    abstract public void AttackAction();
    abstract public void BuffAction();
}
public class Media : Institution
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void BlockadeAction()
    {}
    override public void AttackAction()
    {}
    override public void BuffAction()
    {}
}

public class NGO : Institution
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        override public void BlockadeAction()
    {}
    override public void AttackAction()
    {}
    override public void BuffAction()
    {}
}

public class Judiciary : Institution
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        override public void BlockadeAction()
    {}
    override public void AttackAction()
    {}
    override public void BuffAction()
    {}
}
