using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBiddingOvertonModifier : MonoBehaviour
{
    public OvertonWindow overtonWindow;
    public float ratio;
    int sumOfBids;
    public void changeOfSum(int i)
    {
        sumOfBids += i;
    }
    int updateSumOfBids()
    {
        return Mathf.CeilToInt(sumOfBids*ratio);
    }
    public void updateEconOvertonWindow()
    {
        overtonWindow.changeEconomicView(updateSumOfBids());
    }
    public void updateWorldviewOvertonWindow()
    {
        overtonWindow.changeWorldview(updateSumOfBids());
    }
}
