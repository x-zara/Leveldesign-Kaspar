using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject infoDialogue;
    public GameObject pauseMenuDialogue;
    public bool isInfoOn;
    public bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!isPaused);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PauseGame(bool doPause)
    {
        isPaused = doPause;
        pauseMenuDialogue.SetActive(isPaused);

        Time.timeScale = isPaused ? 0 : 1;
    }

    public void Info(bool doInfo)
    {
        // Infodialog
        isInfoOn = doInfo;
        infoDialogue.SetActive(isInfoOn);
    }

    // Applikation beenden
    public void QuitGame()
    {
        Application.Quit();
    }

    // Spiel starten -> Wechsel zur GameView Szene
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        //Szene neu starten
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Zurück zum Hauptmenü über Pausemenü
    public void BackToMainMenu()
    {
        // MainMenu Szene laden
        SceneManager.LoadScene(4);
    }
}
