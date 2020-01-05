﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AudioManager : MonoBehaviour
{
    public AudioSource UIclicksound;
    public AudioSource MainMenuMusicSource;
    public AudioSource IngamemusicSource;

    public AudioClip[] MainMenuMusic;
    public AudioClip[] Ingamemusic;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void click()
    {
        UIclicksound.Play();
    }

    public void MenuMusic()
    {
        StartCoroutine(playMenuclips());
    }

    public IEnumerator playMenuclips()
    {
        yield return null;

        for (int i = Random.Range(0, 3); i < MainMenuMusic.Length; i++)
        {
            MainMenuMusicSource.clip = MainMenuMusic[i];
            MainMenuMusicSource.Play();

            Debug.Log(MainMenuMusicSource.clip.name);

            while (MainMenuMusicSource.isPlaying)
            {
                yield return null;
            }

            if (i == MainMenuMusic.Length-1)
                i = -1;
        }
    }
}
