using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject play;

    public Animation mainmenuout;
    public Animation Optionsin;
    public Animation AudioOptionsin;
    public Animation GraphicsIn;

    public AudioMixer audiomixer;

    public Slider musicSlider;
    public Slider gameMusicSlider;
    public Slider soundSlider;

    public Dropdown graphics;
    public Toggle fpstoggle;

    public GameObject fpstxt;

    public float musicVolume;
    public float gameMusicVolume;
    public float soundVolume;
    private void Start()
    {

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        gameMusicSlider.value = PlayerPrefs.GetFloat("GameMusicVolume", 1);
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);

        graphics.value = PlayerPrefs.GetInt("GraphicsSettings", 2);
        fpstoggle.isOn = PlayerPrefs.GetInt("fpscounter", 0) == 1 ? true : false;


    }

    public void Play()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().game = true;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().menu = false;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().menuFadeOut();
        SceneManager.LoadScene("LoadingScene");
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

    public void OnAudioClick()
    {
        StartCoroutine(Audio());
    }

    IEnumerator Audio()
    {
        Optionsin.PlayQueued("OptionsOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(Optionsin.GetClip("OptionsOut").length);
        AudioOptionsin.PlayQueued("AudioOptionsIn", QueueMode.PlayNow);
    }
    public void AudioBack()
    {
        StartCoroutine(AudioBackClick());
    }

    IEnumerator AudioBackClick()
    {
        AudioOptionsin.PlayQueued("AudioOptionsOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(AudioOptionsin.GetClip("AudioOptionsOut").length);
        Optionsin.PlayQueued("OptionsIn", QueueMode.PlayNow);
    }

    public void OnGraphicsClick()
    {
        StartCoroutine(graphicsclick());
    }
    IEnumerator graphicsclick()
    {
        Optionsin.PlayQueued("OptionsOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(Optionsin.GetClip("OptionsOut").length);
        GraphicsIn.PlayQueued("GraphicsIn", QueueMode.PlayNow);
    }

    public void OnGraphicsBack()
    {
        StartCoroutine(graphics_back());
    }
    IEnumerator graphics_back()
    {
        GraphicsIn.PlayQueued("GraphicsOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(GraphicsIn.GetClip("GraphicsOut").length);
        Optionsin.PlayQueued("OptionsIn", QueueMode.PlayNow);
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

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("GraphicsSettings", index);
        //PlayerPrefs.Save();
    }

    public void FPScounterToggle(bool state)
    {
        fpstxt.SetActive(state);
        PlayerPrefs.SetInt("fpscounter", Convert.ToInt32(state));
        //PlayerPrefs.Save();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("GameMusicVolume", gameMusicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);

        PlayerPrefs.Save();
    }
}
