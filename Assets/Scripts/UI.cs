﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.LWRP;
using UnityEngine.Rendering;

public class UI : MonoBehaviour
{
    public GameObject play;

    public Animation mainmenuout;
    public Animation Optionsin;
    public Animation AudioOptionsin;
    public Animation GraphicsIn;
    public Animation LvlselectIn;

    public AudioMixer audiomixer;

    public Slider musicSlider;
    public Slider gameMusicSlider;
    public Slider soundSlider;

    public Dropdown graphics;
    public Toggle fpstoggle;

    public GameObject fpstxt;

    public float musicVolume = 1;
    public float gameMusicVolume = 1;
    public float soundVolume = 1;

    public RenderPipelineAsset LowQualityAsset;
    public RenderPipelineAsset MediumQualityAsset;
    public RenderPipelineAsset HighQualityAsset;

    int controls;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        gameMusicSlider.value = PlayerPrefs.GetFloat("GameMusicVolume", 1);
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);

        graphics.value = PlayerPrefs.GetInt("GraphicsSettings", 2);
        fpstoggle.isOn = PlayerPrefs.GetInt("fpscounter", 0) == 1 ? true : false;

        controls = PlayerPrefs.GetInt("Controls", 1);
    }

    public void setValues()
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
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("GameMusicVolume", gameMusicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);

        PlayerPrefs.Save();
    }
    IEnumerator opsback()
    {

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("GameMusicVolume", gameMusicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);

        PlayerPrefs.Save();


        Optionsin.PlayQueued("OptionsOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(Optionsin.GetClip("OptionsOut").length);   
        mainmenuout.PlayQueued("MainMenuIn", QueueMode.PlayNow);
    }

    public void LVLselect()
    {
        StartCoroutine(lvlselect());
    }

    IEnumerator lvlselect()
    {
        mainmenuout.PlayQueued("MainMenuOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(mainmenuout.GetClip("MainMenuOut").length);
        LvlselectIn.PlayQueued("LevelMenuIn", QueueMode.PlayNow);
    }
    public void LVLselectBack()
    {
        StartCoroutine(lvlselect_back());
    }

    IEnumerator lvlselect_back()
    {
        LvlselectIn.PlayQueued("LevelMenuOut", QueueMode.PlayNow);
        yield return new WaitForSeconds(LvlselectIn.GetClip("LevelMenuOut").length);
        mainmenuout.PlayQueued("MainMenuIn", QueueMode.PlayNow);
    }

    public void Quit()
    {
        Application.Quit();
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
        switch (index)
        {
            case 0:
                GraphicsSettings.renderPipelineAsset = LowQualityAsset;
                break;

            case 1:
                GraphicsSettings.renderPipelineAsset = MediumQualityAsset;
                break;

            case 2:
                GraphicsSettings.renderPipelineAsset = HighQualityAsset;
                break;
        }

        PlayerPrefs.SetInt("GraphicsSettings", index);
        PlayerPrefs.Save();
    }

    public void FPScounterToggle(bool state)
    {
        fpstxt.SetActive(state);
        PlayerPrefs.SetInt("fpscounter", Convert.ToInt32(state));
        PlayerPrefs.Save();
    }

    public void setControls(int c)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ControlsPref = c;
        PlayerPrefs.SetInt("Controls", c);
        PlayerPrefs.Save();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("GameMusicVolume", gameMusicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);

        PlayerPrefs.Save();
    }
}
