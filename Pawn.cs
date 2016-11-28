using UnityEngine;
using System.Collections;

public class Pawn : Chessman {
    public override bool[,] Possible()
    {
        bool[,] r = new bool[8, 8];

        //r[5, 2] = true; -> test

        return r;
    }
}
