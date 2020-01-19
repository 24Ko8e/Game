using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject audioManager;

    public GameObject PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        audioManager.GetComponent<AudioManager>().Resume();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        audioManager.GetComponent<AudioManager>().Paused();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        audioManager.GetComponent<AudioManager>().menu = true;
        audioManager.GetComponent<AudioManager>().game = false;
        audioManager.GetComponent<AudioManager>().igmfadeout();
        SceneManager.LoadScene(0);
    }
}
