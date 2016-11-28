using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardProcessing : MonoBehaviour
{
    /*public void BoardProcessing(){}
     * Proces nie może uzyskać dostępu do pliku
     */
    public static BoardProcessing Instance{ get; set; }// !? brak dostępu ?!

    public GameObject processingPrefab;
    public List<GameObject> processing;

    private void Start()
    {
        Instance = this;//?
        processing = new List<GameObject>();
    }
    /*Podejście do problemu ruchów figur:
     * Jeżeli w BoardManager generuje obiekty, dodaje możliwość ich ruchów.
     * Generowanie obiektów z określonym ruchem i możliwością ruchu (blokada inną figurą itp).
     * Każda figura ma określone ruchy =>
     * 1.Trzeba okreslić dla każdego obiektu(figury) możliwy ruch
     * 2.Trzeba sprawdzić czy ruch jest możliwy i dozwolony /allowed, posiible
    */
    private GameObject getProcessObject()
    {
        GameObject go = processing.Find(g => !g.activeSelf);//GameObject.activeSelf => zwraca stan z SetActive
        if (go == null)
        {
            go = Instantiate(processingPrefab);
            processing.Add(go);
        }

        return go;
    }
    public void ProcessAllowedMoves(bool[,] moves)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (moves[i, j])
                {
                    GameObject go = getProcessObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);//możliwy ruch -> ustaw na pozycji [i,j]
                }
            }
        }
    }

    public void ProcessHide()
    {
        foreach (GameObject go in processing)
            go.SetActive(false);
    } // rozszerzenie ProcessAllowedMoves o ruchy nie dozwolone
}
