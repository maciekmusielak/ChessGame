using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class mainmenu : MonoBehaviour
{

    public Button playButton;
    public Button exitButton;
    private Canvas CanvasObject;
    // Use this for initialization
    void Start()
    {
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        CanvasObject = GetComponent<Canvas>();
    }

    public void PlayPress()
    {
        //Application.LoadLevel nie jest już wspierane, do poprawy
        //gra się buduje jednak nie można jeszcze przejść dalej
        //SceneManager.LoadScene("Chess");
        CanvasObject.enabled = !CanvasObject.enabled;
    }  

    public void ExitPress()
    {
        Application.Quit();
    }
    // Update is called once per frame
    //void Update()
    //{

    //}
}

