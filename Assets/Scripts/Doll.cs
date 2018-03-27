using UnityEngine;
using System.Collections;

public class Doll
{

    string name;
    string dessert;
    string trick;

    public Doll(string name, string dessert, string trick)
    {
        this.name = name;
        this.dessert = dessert;
        this.trick = trick;
    }

    public string getName()
    {
        return name;
    }

    public string getDessert()
    {
        return dessert;
    }

    public string getTrick()
    {
        return trick;
    }
    public void setName(string name)
    {
        this.name = name;
    }
    public void setDessert(string dessert)
    {
        this.dessert = dessert;

    }
    public void setTrick(string trick)
    {
        this.trick = trick;
    }
}

