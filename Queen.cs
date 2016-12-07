using UnityEngine;
using System.Collections;

public class Queen : Chessman
{
    public override bool[,] Possible()
    {
        bool[,] r = new bool[8, 8];
        Chessman c1;
        int i;
        int j;

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
            if (i < 0)
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
