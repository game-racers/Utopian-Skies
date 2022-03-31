using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityStats : MonoBehaviour
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
    public int debtLimit;
    public TextMeshProUGUI moneyDisplay;

    public float nextActionTime;
    public float TaxTime;
    public int period = 15;
    public int taxPeriod = 60;
    public double temptaxRate;
    public double tempbusinesstaxRate;
    public double tempindustryRate;

    public DialogueManager dialManager;

    public int stage;
    public int style;

    //Delete this later
    public Slider baseSlider;
    public Slider busSlider;
    public Slider indusSlider;



    //Marked: To be moved to population script eventually to help keep city stats from doing too much.
    public TextMeshProUGUI popDisplay;
    //public Population pop;


    public TaxSystem CityTaxes;
    public Population TotalPopulation;
    public int maxPopulation = 0;
    //Purely for debugging:
    public int populationCount = 0;

    public DialogueManager dialManage;



    // Start is called before the first frame update
    void Start()
    {
        HappinessBar.value = 50;
        SecurityBar.value = 50;
        TotalPopulation = new Population("City Population");
        CityTaxes = new TaxSystem();

       
    }

    // Update is called once per frame
    void Update()
    {
        //reference every object in scene with BuildStats
        Buildable[] Buildings = FindObjectsOfType<Buildable>();

        if (TotalPopulation.getPopulation > maxPopulation)
        {
            TotalPopulation.setPop(maxPopulation);
        }

        if (TotalPopulation.getPopulation < 0)
        {
            TotalPopulation.setPop(1);
        }

        if (Time.time > TaxTime)
        {
            TaxTime = Time.time + taxPeriod;
            addMoney((int)CityTaxes.TaxPop(TotalPopulation));
            addMoney((int)CityTaxes.TaxBusinesses());
            
            //If housing is available, and people are happy here move people in. (Probably going to be changed in the future)
            if(maxPopulation > TotalPopulation.getPopulation)
            {
                if(Happiness > 70)
                {
                    populationCount = TotalPopulation.increasePop((int) Random.Range(0.0f, maxPopulation));
                }
                else if (Happiness >= 50)
                {
                    populationCount = TotalPopulation.increasePop((int)Random.Range(0.0f, maxPopulation/2));
                }
                else if (Happiness < 50)
                {
                    populationCount = TotalPopulation.decreasePop((int)Random.Range(0.0f, maxPopulation / 12));
                }
                if (Happiness < 20 && dialManager.mobcheck[0] == false)
                {
                    dialManager.StartDialogue(dialManager.mobdial[dialManager.mobcount+1]);
                }
            }
        }


        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time+period;
            // execute block of code here
            foreach (Buildable i in Buildings)
            {
                //check if happy mod is + or -
                //if (i.GetHappMod() >= 0)
                //{
                    HappinessMod += i.GetHappMod();
                //}
                //else
                //{
                //    HappinessMod -= i.GetHappMod();
                //}

                if (i.GetSecMod() >= 0)
                {
                    SecurityMod += i.GetSecMod();
                }
                else
                {
                    SecurityMod -= i.GetSecMod();
                }

                if (Happiness < 30 && dialManage.mobcheck[0] == false)
                {
                    dialManage.StartDialogue(dialManage.mobdial[dialManage.mobcount]);
                    dialManage.mobcheck[dialManage.mobcount] = true;

                }


            }
            //set happiness = new happiness
            Happiness = Happiness + (Happiness * HappinessMod);
            if (Happiness > 100)
            {
                Happiness = 100;
            }
            else if (Happiness > 70 && HappinessMod < .7)
            {
                Happiness = 70;
            }
            Security = Security + (Security * SecurityMod);
        }





        moneyDisplay.SetText("$" + money);

        //Marked: to be moved to population script eventually.
        popDisplay.SetText("Population: " + populationCount);





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

    //public double Taxes()
    //{
    //    var houses = GameObject.FindGameObjectsWithTag("House").Length;
    //    return (houses * taxRate);
    //}

    //public double BusinessTaxes()
    //{
    //    var businesses = GameObject.FindGameObjectsWithTag("SBusiness").Length;
    //    return (businesses * businesstaxRate);
    //}

    public int increaseMaxPop(int increase)
    {
        maxPopulation += increase;
        return maxPopulation;
    }

    public void setStyle(int newstyle)
    {
        style = newstyle;
    }

    public void setStage(int newstage)
    {
        stage = newstage;
    }

    public int getStyle()
    {
        return style;
    }

    public int getStage()
    {
        return stage;
    }


    public void setTax()
    {
        temptaxRate = baseSlider.value;
    }

    public void setbusTax()
    {
        tempbusinesstaxRate = busSlider.value;
    }

    public void setindusTax()
    {
        tempindustryRate = indusSlider.value;
    }
    
    }
