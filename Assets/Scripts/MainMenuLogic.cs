using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject creditsCanvas;
    public string startScene;

    private bool isCredits;

    // Start is called before the first frame update
    void Start()
    {
        mainCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
    public void ShowCredits()
    {
        mainCanvas.SetActive(isCredits);
        isCredits = !isCredits;
        creditsCanvas.SetActive(isCredits);
    }
}
