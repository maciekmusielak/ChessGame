using UnityEngine;
using System.Collections;
/*
  Ruchy skoczek
   X1 X2 
  X3    X4
     K  
  X5    X6
   X7 X8 

 */
public class Knight : Chessman
{

    public override bool[,] Possible()
    {
        bool[,] r = new bool[8, 8];
        //Chessman c1, c2;
        //do X1
        knight_move(CurrentX - 1, CurrentY + 2, ref r);

        //do X2
        knight_move(CurrentX + 1, CurrentY + 2, ref r);

        //do X3
        knight_move(CurrentX - 2, CurrentY + 1, ref r);

        //do X4
        knight_move(CurrentX + 2, CurrentY + 1, ref r);

        //do X5
        knight_move(CurrentX - 2, CurrentY - 1, ref r);

        //do X6
        knight_move(CurrentX + 2, CurrentY - 1, ref r);

        //do X7
        knight_move(CurrentX - 1, CurrentY - 2, ref r);

        //do X8
        knight_move(CurrentX + 1, CurrentY - 2, ref r);

        return r;
    }
    public void knight_move(int x, int y, ref bool[,] r)
    {
        Chessman c1;
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            c1 = BoardManager.Instance.Chessmans[x,y];
            if (c1 == null)
                r[x, y] = true;
            //else
            else if(ifWhite != c1.ifWhite)
                r[x, y] = true; 
        }
    }
}
