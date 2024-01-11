using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public GameObject pauseMenuCanvas;
    void Start()
    {
        Time.timeScale= 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Play();

            }
            else
            {
                Stop();
            }
        }
    }

    public void Play()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale= 1.0f;
        paused = false;
    }

    public void Stop()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        paused= true;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Qitted");
    }
}
