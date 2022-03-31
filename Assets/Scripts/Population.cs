using System.Collections;
using System.Collections.Generic;

//TODO: Create SubPop Groups to categorize groups that are Mutually Exclusive ex. Poor, Middleclass, Rich; Adult & Senior; Blue Collar & White Collar; etc; 

public class Population
{
    private string name;
    private int population;
    private Dictionary<string, SubPopulation> subPopulations;

    public void setPop(int num)
    {
        population = num;
    }

    public Population (string name)
    {
        this.name = name;
        this.subPopulations = new Dictionary<string, SubPopulation>();
    }

    //Creates Subpopulation
    public void newSubPop(string name)
    {
        this.subPopulations.Add(name,new SubPopulation(name));
    }

    //Increases the populaiton
    public int increasePop(int num)
    {
        this.population += num;
        return this.population;
    }

    //Decreases Population
    public int decreasePop(int num)
    {
        this.population -= num;
        return this.population;
    }

    //Returns an int representing the number of people.
    public int getPopulation => population;

    //Move people between Subpops
    public bool shiftSubPop(string src, string dest, int num)
    {
        this.subPopulations[src].decreasePop(num);
        this.subPopulations[dest].increasePop(num);
        return true;
    }
    /*
    public int increaseSubPop(string name, int num)
    {
        return this.subPopulations[name].increasePop(num);
    }

    public int decreaseSubPop(string name, int num)
    {
        return this.subPopulations[name].decreasePop(num);
    }
    */

    /*
    public int getTotalPopulation()
    {
        foreach (KeyValuePair<string, SubPopulation> subPop in subPopulations)
        {

        }
    }
    */

}

public class SubPopulation
{
    private string name;
    private int population;

    public SubPopulation(string name)
    {
        this.name = name;
    }

    public void decreasePop(int num)
    {
        this.population -= num;
    }

    public void increasePop(int num)
    {
        this.population += num;
    }

    //Returns an int representing the number of people.
    public int getPopulation => population;
}