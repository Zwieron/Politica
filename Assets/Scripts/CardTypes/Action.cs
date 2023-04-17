using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    protected string actionName;
    protected string actionDescription;
    protected int actionCost;
    protected int actionPower;
    // Start is called before the first frame update
    public Action(string name, string description)
    {
        actionName = name;
        actionDescription = description;
    }
    public void DoAction()
    {

    }
}
public class NegativeAction : Action
{
    public NegativeAction(string name, string description, int cost, int power) : base(name, description)
    {
        actionCost = cost;
        actionPower = power;
    }
    public void DoAction(Party party)
    {
        party.supportPercentage =- actionPower;
    }
}
public class PositiveAction : Action
{
        public PositiveAction(string name, string description, int cost, int power) : base(name, description)
    {
        actionCost = cost;
        actionPower = power;
    }
    public void DoAction(Party party)
    {
        party.supportPercentage =+ actionPower;
    }
}
public class DoubleEdgedAction : Action
{
    public int actionPower2;
    public DoubleEdgedAction(string name, string description, int cost, int power, int power2) : base(name, description)
    {
        actionCost = cost;
        actionPower = power;
        actionPower2 = power2;
    }
    public void DoAction(Party party1, Party party2, int damage1, int damage2)
    {
        party1.supportPercentage =- actionPower;
        party2.supportPercentage =- actionPower2;
    }
}
