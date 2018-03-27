using UnityEngine;
using System.Collections;

public class Puzzle
{
    // a list to store all the dolls
    Doll[] dolls = new Doll[6];

    public Puzzle()
    {
        Doll liuwen = new Doll("liuwen", "waffle", "tightrope");
        Doll venie = new Doll("venie", "tart", "dart");
        Doll eve = new Doll("eve", "macaron", "unicycle");
        Doll elita = new Doll("elita", "shortbread", "swing");
        Doll muhua = new Doll("muhua", "cheese", "ballet");
        Doll cecile = new Doll("cecile", "brownie", "taming");
        dolls[0] = eve;
        dolls[1] = venie;
        dolls[2] = liuwen;
        dolls[3] = muhua;
        dolls[4] = elita;
        dolls[5] = cecile;
    }

    public Doll[] getPuzzleAnswer()
    {
        return dolls;
    }
}
