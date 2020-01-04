using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public AudioMixer audiomixer;

    public Slider musicSlider;
    public Slider gameMusicSlider;
    public Slider soundSlider;

    public float musicVolume;
    public float gameMusicVolume;
    public float soundVolume;
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        gameMusicSlider.value = PlayerPrefs.GetFloat("GameMusicVolume", 1);
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);

        /*if (musicSlider.value > 0.0001)
        {
            setVolumeMtoggle(true);
        }
        else
            setVolumeMtoggle(false);*/

    }

    public void Play()
    {
        SceneManager.LoadScene(1);
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
    /*public void setVolumeMtoggle(bool state)
    {
        if (state)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        }
        if (!state)
        {
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            musicSlider.value = 0.0001f;
        }
    }*/

    public void setVolumeIGM(float volume)
    {
        audiomixer.SetFloat("GameMusicVolume", Mathf.Log10(volume) * 20);
        gameMusicVolume = volume;
    }
    /*public void setVolumeIGMtoggle(bool state)
    {
        if (state)
        {
            gameMusicSlider.value = PlayerPrefs.GetFloat("GameMusicVolume", 1);
        }
        if (!state)
        {
            PlayerPrefs.SetFloat("GameMusicVolume", gameMusicVolume);
            gameMusicSlider.value = 0.0001f;
        }
    }*/

    public void setVolumeS(float volume)
    {
        audiomixer.SetFloat("SoundVolume", Mathf.Log10(volume) * 20);
        soundVolume = volume;
    }
    /*public void setVolumeStoggle(bool state)
    {
        if (state)
        {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);
        }
        if (!state)
        {
            PlayerPrefs.SetFloat("SoundVolume", soundVolume);
            soundSlider.value = 0.0001f;
        }
    }*/

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("GameMusicVolume", gameMusicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);

        PlayerPrefs.Save();
    }
}
