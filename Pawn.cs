using UnityEngine;
using System.Collections;

public class Pawn : Chessman {
    public override bool[,] Possible()
    {
        bool[,] r = new bool[8, 8];
        Chessman c1, c2;
        //r[5, 2] = true; -> test
        /*
         * Określenie ruchu piona dla drużyny:
         * ->Białe
         * ->Czarne
         * Określenie możliwych ruchów pionów:
         * ->pierwszy ruch
         * ->ruch w przód ? midlle
         * ->ruch przy ataku ? diagonal, atak tylko gdy można dokonać bicia!
         * ->->ruch w prawo
         * ->->ruch w lewo
         */
        if (ifWhite)//zasady ruchu Białych
        {
            //ruch w przód
            if (CurrentY != 7)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                if (c1 == null)
                    r[CurrentX, CurrentY + 1] = true;
            }
            //atak w lewo /
            if (CurrentX != 0 && CurrentY != 7)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c1 != null && !c1.ifWhite)
                    r[CurrentX - 1, CurrentY + 1] = true;
            }
            //atak w prawo /
            if (CurrentX != 7 && CurrentY != 7)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c1 != null && !c1.ifWhite)
                    r[CurrentX + 1, CurrentY + 1] = true;
            }
            //pierwszy ruch
            if (CurrentY == 1)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 2];
                if (c1 == null && c2 == null)
                    r[CurrentX, CurrentY + 2] = true;
            }
        }
        else//zasady ruchu Czarnych
        {
            //ruch w przód
            if (CurrentY != 0)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                if (c1 == null)
                    r[CurrentX, CurrentY - 1] = true;
            }
            //atak w lewo /
            if (CurrentX != 0 && CurrentY != 0)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c1 != null && c1.ifWhite)
                    r[CurrentX - 1, CurrentY - 1] = true;
            }
            //atak w prawo /
            if (CurrentX != 7 && CurrentY != 0)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY - 1];
                if (c1 != null && c1.ifWhite)
                    r[CurrentX + 1, CurrentY - 1] = true;
            }
            //pierwszy ruch
            if (CurrentY == 6)
            {
                c1 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 2];
                if (c1 == null && c2 == null)
                    r[CurrentX, CurrentY - 2] = true;
            }
        }
        return r;
    }
}
