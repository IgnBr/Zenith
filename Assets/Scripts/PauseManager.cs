using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Canvas pauseMenu;
    public FirstPersonController controller;


    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;

            Time.timeScale = isPaused ? 0 : 1;
            controller.enabled = !isPaused;
            pauseMenu.gameObject.SetActive(isPaused);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = isPaused;
        }
    }

    public void resumeGame()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;
        controller.enabled = !isPaused;
        pauseMenu.gameObject.SetActive(isPaused);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = isPaused;
    }

    public void quitGame()
    {
        //TODO: Save Logic someday
        SceneManager.LoadScene("MainMenu");
    }
}
