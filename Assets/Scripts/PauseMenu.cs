using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Animator OptAnim;

    public GameObject options;
    public Scrollbar OptionsScroll;

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
        PauseMenuUI.SetActive(true);
        audioManager.GetComponent<AudioManager>().Paused();
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

    public void OptionsBack()
    {
        OptAnim.SetBool("OUT", true);
        OptAnim.SetBool("IN", false);
        StartCoroutine(disableOptionsMenu());
    }

    IEnumerator disableOptionsMenu()
    {
        yield return new WaitForSeconds(.25f);
        options.SetActive(false);
    }

    public void OnOptionClick()
    {
        options.SetActive(true);
        OptAnim.SetBool("IN", true);
        OptAnim.SetBool("OUT", false);
    }

    IEnumerator setscroll()
    {
        yield return new WaitForSeconds(0.5f);
        OptionsScroll.value = 1;
    }
}
