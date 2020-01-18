using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

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
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Resume();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Paused();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().menu = true;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().game = false;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().igmfadeout();
        SceneManager.LoadScene(0);
    }
}
