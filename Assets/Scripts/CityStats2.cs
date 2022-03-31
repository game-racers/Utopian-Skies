using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityStats2 : MonoBehaviour
{

    public float Happiness;
    public float Security;
    public Slider HappinessBar;
    public Slider SecurityBar;
    public int days;
    public float seconds;
    public TextMeshProUGUI dayDisplay;
    public float HappinessMod;
    public float SecurityMod;
    public int money;
    public TextMeshProUGUI moneyDisplay;

    public float nextActionTime;
    public float TaxTime;
    public int period = 15;
    public int taxPeriod = 60;
    public double taxRate = 0.01;

    public Population TotalPopulation;
    public int maxPopulation = 0;
    // Start is called before the first frame update
    void Start()
    {
        HappinessBar.value = 50;
        SecurityBar.value = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //reference every object in scene with BuildStats
        Buildable[] Buildings = FindObjectsOfType<Buildable>();

        if (Time.time > TaxTime)
        {
            TaxTime = Time.time + taxPeriod;
            addMoney((int)Taxes());

        }


        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time+period;
            // execute block of code here
            foreach (Buildable i in Buildings)
            {
                //check if happy mod is + or -
                if (i.GetHappMod() >= 0)
                {
                    HappinessMod += i.GetHappMod();
                }
                else
                {
                    HappinessMod -= i.GetHappMod();
                }

                if (i.GetSecMod() >= 0)
                {
                    SecurityMod += i.GetSecMod();
                }
                else
                {
                    SecurityMod -= i.GetSecMod();
                }


            }
            //set happiness = new happiness
            Happiness = Happiness + (Happiness * HappinessMod);
            if (Happiness > 70 && HappinessMod < .7)
            {
                Happiness = 70;
            }
            Security = Security + (Security * SecurityMod);
        }





        moneyDisplay.SetText("$" + money);







        if (seconds >= 600) {
            days = (int)(seconds / 600); ;
            //seconds = 0;
            //days += 1;
            dayDisplay.SetText("Day: " + days);
        }
        seconds += Time.deltaTime * 1;
        HappinessBar.value = Happiness;
        SecurityBar.value = Security;

    }


    public void addMoney(int add)
    {
        money = money + add;
    }

    public void loseMoney(int loss)
    {
        money = money - loss;
    }

    public double Taxes()
    {
        var houses = GameObject.FindGameObjectsWithTag("House").Length;
        return (houses * taxRate);
    }

    public int increaseMaxPop(int increase)
    {
        maxPopulation += increase;
        return maxPopulation;
    }
}
