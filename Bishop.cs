using UnityEngine;
using System.Collections;

public class Bishop : Chessman
{
    public override bool[,] Possible()
    {
        bool[,] r = new bool[8, 8];

        /*
         * Ruch po przekątnych/diagonalach =>
         *  gdy x+1 to y+1
         *  x+2, y+2 etc.
         *  diagonalTopLeft:
         *          x--, y++
         *  diagonalTopRight
         *          x++, j++s
         *  diagonalDownLeft:
         *          x--,y--
         *  diagonaldownRight:
         *          x++,y--
         */

        Chessman c1;
        int i, j;
        //diagonalTopLeft
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;
            c1 = BoardManager.Instance.Chessmans[i, j];
            if (c1 == null)
                r[i, j] = true;
            else
            {
                if (ifWhite != c1.ifWhite)
                    r[i, j] = true;
                break;
            }
        }
        //diagonalTopRight
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j >= 8)
                break;
            c1 = BoardManager.Instance.Chessmans[i, j];
            if (c1 == null)
                r[i, j] = true;
            else
            {
                if (ifWhite != c1.ifWhite)
                    r[i, j] = true;
                break;
            }
        }
        //diagonalDownLeft
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
                break;
            c1 = BoardManager.Instance.Chessmans[i, j];
            if (c1 == null)
                r[i, j] = true;
            else
            {
                if (ifWhite != c1.ifWhite)
                    r[i, j] = true;
                break;
            }
        }
        //diagonalDownRight
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >= 8 || j < 0)
                break;
            c1 = BoardManager.Instance.Chessmans[i, j];
            if (c1 == null)
                r[i, j] = true;
            else
            {
                if (ifWhite != c1.ifWhite)
                    r[i, j] = true;
                break;
            }
        }

        return r;
    }
}
