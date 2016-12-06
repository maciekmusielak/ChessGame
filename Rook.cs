using UnityEngine;
using System.Collections;

public class Rook : Chessman {
    public override bool[,] Possible()
    {
        bool[,] r = new bool[8, 8];
        Chessman c1;
        //ruch w prawo
        int i;
        i = CurrentX;
        while (true)
        {
            //CurrentX + 1;
            i++;
            if (i >= 8)
                break;

            c1 = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c1 == null)
                r[i, CurrentY] = true;
            else
            {
                if (c1.ifWhite != ifWhite)
                    r[i, CurrentY] = true;
                break;
            }
        }

        //ruch w lewo
        i = CurrentX;
        while (true)
        {
            //CurrentX + 1;
            i--;
            if (i < 0)
                break;

            c1 = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c1 == null)
                r[i, CurrentY] = true;
            else
            {
                if (c1.ifWhite != ifWhite)
                    r[i, CurrentY] = true;
                break;
            }
        }


        //ruch przód(góra)
        i = CurrentY;
        while (true)
        {
            //CurrentX + 1;
            i++;
            if (i >= 8)
                break;

            c1 = BoardManager.Instance.Chessmans[CurrentX, i];
            if (c1 == null)
                r[CurrentX, i] = true;
            else
            {
                if (c1.ifWhite != ifWhite)
                    r[CurrentX, i] = true;
                break;
            }
        }


        //ruch tył(dół)
        i = CurrentY;
        while (true)
        {
            //CurrentX + 1;
            i--;
            if (i < 0 )
                break;

            c1 = BoardManager.Instance.Chessmans[CurrentX, i];
            if (c1 == null)
                r[CurrentX, i] = true;
            else
            {
                if (c1.ifWhite != ifWhite)
                    r[CurrentX, i] = true;
                break;
            }
        }


        return r;
    }

}
