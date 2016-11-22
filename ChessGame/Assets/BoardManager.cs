using UnityEngine;
using System.Collections;
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
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f; //wielkość do edycji, w zależności jak zmesh'uje się asset planszy

    private int selectX = 0;
    private int selectY = 0;


    private void Update()
    {
        DrawChessboard();
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
    }
}
