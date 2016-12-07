using UnityEngine;
using System.Collections;
/*
 * Król/King
 * ruch o 1 pole
 * w każdą stronę 
 */
public class King : Chessman
{
    public override bool[,] Possible()
    {
        bool[,] r = new bool[8, 8];
        Chessman c1;
        int i;
        int j;


        i = CurrentX - 1;
        j = CurrentY + 1;
        //ruch w lewo
        if(CurrentX !=0)
        {
            c1 = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY];
            if (c1 == null)
                r[CurrentX - 1, CurrentY] = true;
            else if (ifWhite != c1.ifWhite)
                r[CurrentX - 1, CurrentY] = true;
        }
        //ruch w prawo
        if (CurrentX != 7)
        {
            c1 = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY];
            if (c1 == null)
                r[CurrentX + 1, CurrentY] = true;
            else if (ifWhite != c1.ifWhite)
                r[CurrentX + 1, CurrentY] = true;
        }

        //ruchy w górę
        if (CurrentY != 7)
        {
            for(int l = 0; l < 3; l++)
            {
                if(i >= 0 || i < 8)
                {
                    c1 = BoardManager.Instance.Chessmans[i, j];
                    if (c1 == null)
                        r[i, j] = true;
                    else if (ifWhite != c1.ifWhite)
                        r[i, j] = true;
                }
                i++;
            }
        }
        //ruchy w doł
        i = CurrentX - 1;
        j = CurrentY - 1;
        if (CurrentY != 0)
        {
            for (int l = 0; l < 3; l++)
            {
                if (i >= 0 || i < 8)
                {
                    c1 = BoardManager.Instance.Chessmans[i, j];
                    if (c1 == null)
                        r[i, j] = true;
                    else if (ifWhite != c1.ifWhite)
                        r[i, j] = true;
                }
                i++;
            }
        }

        return r;
    }
}
