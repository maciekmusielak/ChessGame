using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainmenu : MonoBehaviour {


    public Button playButton;
    public Button exitButton;

	// Use this for initialization
	void Start ()
    {
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

    }

    public void PlayPress()
    {
        //Application.LoadLevel nie jest już wspierane, do poprawy
        //gra się buduje jednak nie można jeszcze przejść dalej
        Application.LoadLevel(1);
    }
    
    public void ExitPress()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
