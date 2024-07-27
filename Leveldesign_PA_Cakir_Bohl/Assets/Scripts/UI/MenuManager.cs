using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject infoDialogue;
    public GameObject pauseMenuDialogue;
    public bool isInfoOn;
    public bool isPaused = false;
    public Image _reversedBlackScreen;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

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
        ProgressionManager.Instance.progress = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);
    }

    // Zurück zum Hauptmenü über Pausemenü
    public void BackToMainMenu()
    {
        // MainMenu Szene laden
        SceneManager.LoadScene(4);
    }
}
