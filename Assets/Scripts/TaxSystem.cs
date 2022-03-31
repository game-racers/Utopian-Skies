using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxSystem
{
    // Start is called before the first frame update
    private double taxRate = 0.10;
    private double businessTaxRate = 0.5;
    // The Minimum and Maximum Tax Rate Available to the Player
    public const double MAXTAXRATE = 0.45;
    public const double MINTAXRATE = 0;
    public int income = 20000;

    //STUFF FROM PREVIOUS
    //public float nextActionTime;
    //public float TaxTime;
    //public int period = 15;
    //public int taxPeriod = 60;

    ///public MonoBehaviour citystats;

    public TaxSystem()
    {
        //Empty Constructor
    }

    public double TaxPop(Population pop)
    {
        //var houses = GameObject.FindGameObjectsWithTag("House").Length;
        return (pop.getPopulation * income * taxRate);
    }

    public double TaxPop(SubPopulation pop)
    {
        //var houses = GameObject.FindGameObjectsWithTag("House").Length;
        return (pop.getPopulation * income * taxRate);
    }


    public double TaxBusinesses()
    {
        var businesses = GameObject.FindGameObjectsWithTag("SBusiness").Length;
        return (businesses * businessTaxRate);
    }

    public void setTaxRate(double rate)
    {
        this.taxRate = rate;
    }

    public void setBusinessTaxRate(double rate)
    {
        this.businessTaxRate = rate;
    }
}
