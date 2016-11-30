using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * BoardManager.cs
 * klasa tworząca gameObject w postaci planszy
 * wielkość planszy - 1 /jednostka/? na pole, 8x8 całość
 * https://pl.wikipedia.org/wiki/Szachownica
 * Asset - w paczce razem z pionami i teksturami z asset store'a
 * nazwy zmiennych zgodnie z poleceniem zangielszczone, korzystałem
 * z nazw zawartych w tym serwisie: http://mekk.waw.pl/mk/szachy/slownik/index
 */



public class BoardManager : MonoBehaviour {
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
    public static BoardManager Instance { set; get; }
    private bool[,] allowedMove { set; get; }

    public Chessman[,] Chessmans { set; get; }
    private Chessman selected;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f; //wielkość do edycji, w zależności jak zmesh'uje się asset planszy

    private int selectX = -1;
    private int selectY = -1;
    /*
     * Piony/Figury
     * 16 jednego koloru
     * 32 łącznie
     * Figury mają wagi
     * ściąga : https://pl.wikipedia.org/wiki/Szachy
     */
    //Problem : Figury są obrócone względem planszy
    //Jeżeli obróce względem np. białych, to czarne będą obrócone o 180 stopni
    private Quaternion orientate = Quaternion.Euler(-90,90,180);

    public bool whiteTurn = true;

    public List<GameObject> chessmanPref;//Pref'y
    private List<GameObject> activeChessman;
    private void Start()
    {
        Instance = this;
        SpawnAllChess();
    }
    private void Update()
    {
        SelectUpdate();
        DrawChessboard();

        if (Input.GetMouseButtonDown(0))
        {
            if (selectX >= 0 && selectY >= 0)
            {
                if (selected == null)
                {
                    //wybierz
                    SelectChess(selectX,selectY);
                }
                else
                {
                    //ruch
                    MoveChess(selectX,selectY);
                }
            }
        }
    }

    private void SelectChess(int x, int y)
    {
        if (Chessmans[x, y] == null)
            return;

        if (Chessmans[x, y].ifWhite != whiteTurn)
            return;

        allowedMove = Chessmans[x , y].Possible();
        selected = Chessmans[x, y];

        BoardProcessing.Instance.ProcessAllowedMoves(allowedMove);
    }

    private void MoveChess(int x, int y)
    {
        if (allowedMove[x,y])//teraz dostępne tylko allowed ruchy
        {
            Chessmans [selected.CurrentX, selected.CurrentY] = null;
            selected.transform.position = GetCenter(x, y);
            selected.Position(x,y);
            Chessmans[x, y] = selected;
            whiteTurn = !whiteTurn;
        }
        BoardProcessing.Instance.ProcessHide();
        selected = null;
        //zmiana kolejki ruch_biały -> ruch czarny LOOP
        
    }

    private void SelectUpdate()
    {
        if (!Camera.main)
            return;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            //Debug.Log(hit.point);
            selectX = (int)hit.point.x;
            selectY = (int)hit.point.z;
        }
        else
        {
            selectX = -1;
            selectY = -1;
        }
    }

    private Vector3 GetCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;

        return origin;
    }
    private void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 8; //8 pól w prawo
        //Vector3 heightLine = Vector3.down * 8;
        Vector3 heightLine = Vector3.forward * 8;

        //"Rysowanie" planszy jako object w siatce
        for (int i = 0; i <= 8; i++)
        {
            Vector3 draw = Vector3.forward * i; //rysuj krok po kroku w DrawLine()
            Debug.DrawLine(draw, draw + widthLine);
            for (int j = 0; j <= 8; j++)
            {
                draw = Vector3.right * j;
                Debug.DrawLine(draw, draw + heightLine);
            }
        }
        if (selectX >= 0 && selectY >= 0)
        {
            Debug.DrawLine(Vector3.forward * selectY + Vector3.right * selectX, Vector3.forward * (selectY + 1) + Vector3.right * (selectX +1));
            //Debug.DrawLine(Vector3.forward * selectY + Vector3.right * selectX, Vector3.forward * (selectY + 1) + Vector3.right * (selectX +1));
            Debug.DrawLine(Vector3.forward * (selectY+1) + Vector3.right * selectX, Vector3.forward * selectY + Vector3.right * (selectX + 1));
        }
    }
    /*private void SpawnSzach(int index, Vector3 position) 
    { 
    }*/
    private void SpawnChessman(int index, int x, int y)
    {
        GameObject go = Instantiate(chessmanPref[index], GetCenter(x,y), orientate) as GameObject;

        go.transform.SetParent(transform);
        Chessmans[x,y] = go.GetComponent<Chessman>();
        Chessmans[x, y].Position(x,y);
        activeChessman.Add(go);
    }

    private void SpawnAllChess()
    {
        activeChessman = new List<GameObject> ();
        Chessmans = new Chessman[8, 8];

        //BIAŁE/White
        SpawnChessman(0, 3, 0);

        SpawnChessman(1,4, 0);

        SpawnChessman(2, 0, 0);
        SpawnChessman(2, 7, 0);

        SpawnChessman(3, 2, 0);
        SpawnChessman(3, 5, 0);

        SpawnChessman(4, 1, 0);
        SpawnChessman(4, 6, 0);

        SpawnChessman(5, 0, 1);
        SpawnChessman(5, 1, 1);
        SpawnChessman(5, 2, 1);
        SpawnChessman(5, 3, 1);
        SpawnChessman(5, 4, 1);
        SpawnChessman(5, 5, 1);
        SpawnChessman(5, 6, 1);
        SpawnChessman(5, 7, 1);

        //CZARNE/Black
        SpawnChessman(6, 3, 7);

        SpawnChessman(7, 4, 7);

        SpawnChessman(8, 0, 7);
        SpawnChessman(8, 7, 7);

        SpawnChessman(9, 2, 7);
        SpawnChessman(9, 5, 7);

        SpawnChessman(10, 1, 7);
        SpawnChessman(10, 6, 7);

        SpawnChessman(11, 0, 6);
        SpawnChessman(11, 1, 6);
        SpawnChessman(11, 2, 6);
        SpawnChessman(11, 3, 6);
        SpawnChessman(11, 4, 6);
        SpawnChessman(11, 5, 6);
        SpawnChessman(11, 6, 6);
        SpawnChessman(11, 7, 6);
    }

}
