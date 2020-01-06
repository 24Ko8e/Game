using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject play;
    public GameObject resume;

    public Animation mainmenuout;
    public Animation Optionsin;

    public AudioMixer audiomixer;

    public Slider musicSlider;
    public Slider gameMusicSlider;
    public Slider soundSlider;

    public float musicVolume;
    public float gameMusicVolume;
    public float soundVolume;
    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelsUnlocked", 1) == 1)
        {
            play.SetActive(true);
            resume.SetActive(false);
        }

        if (PlayerPrefs.GetInt("LevelsUnlocked", 1) > 1)
        {
            play.SetActive(false);
            resume.SetActive(true);
        }

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        gameMusicSlider.value = PlayerPrefs.GetFloat("GameMusicVolume", 1);
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);

        GameObject.Find("AudioManager").GetComponent<AudioManager>().MenuMusic();

    }

    public void Play()
    {
        audiomixer.SetFloat("MusicVolume",-80);
        SceneManager.LoadScene(GameManager.currentlevel);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().InGameMusic();
    }

    public void Resume()
    {
        audiomixer.SetFloat("MusicVolume", -80);
        SceneManager.LoadScene(GameManager.currentlevel);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().InGameMusic();
    }

    public void Options()
    {
        StartCoroutine(ops());
    }
    IEnumerator ops()
    {
        mainmenuout.PlayQueued("MainMenuOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(mainmenuout.GetClip("MainMenuOut").length);
        Optionsin.PlayQueued("OptionsIn", QueueMode.PlayNow);
    }

    public void OptionsBack()
    {
        StartCoroutine(opsback());
    }
    IEnumerator opsback()
    {
        Optionsin.PlayQueued("OptionsOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(Optionsin.GetClip("OptionsOut").length);   
        mainmenuout.PlayQueued("MainMenuIn", QueueMode.PlayNow);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void setVolumeM(float volume)
    {
        audiomixer.SetFloat("MusicVolume", Mathf.Log10 (volume) * 20);
        musicVolume = volume;
    }

    public void setVolumeIGM(float volume)
    {
        audiomixer.SetFloat("GameMusicVolume", Mathf.Log10(volume) * 20);
        gameMusicVolume = volume;
    }

    public void setVolumeS(float volume)
    {
        audiomixer.SetFloat("SoundVolume", Mathf.Log10(volume) * 20);
        soundVolume = volume;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("GameMusicVolume", gameMusicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);

        PlayerPrefs.Save();
    }
}
