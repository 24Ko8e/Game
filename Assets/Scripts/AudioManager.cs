using System.Collections;
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

    public bool isIGMplaying = false;

    public bool menu = true;
    public bool game = false;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        IngamemusicSource.volume = 0;
        MenuMusic();

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Paused()
    {
        IngamemusicSource.volume *= 0.5f;
    }

    public void Resume()
    {
        IngamemusicSource.volume *= 2;
    }

    public void click()
    {
        UIclicksound.Play();
    }

    public void MenuMusic()
    {
        StartCoroutine(playMenuclips());
        menufadein();
    }

    public IEnumerator playMenuclips()
    {
        yield return null;

        for (int i = Random.Range(0, MainMenuMusic.Length); i < MainMenuMusic.Length; i++)
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

    public void menufadein()
    {
        StartCoroutine(MenuMusicFadeIn());
    }
    public IEnumerator MenuMusicFadeIn()
    {
        float time = 1.2f;
        float i = 0;
        float rate = 1 / time;

        while ((i < 1)&& menu)
        {
            MainMenuMusicSource.volume = i;
            i += Time.deltaTime * rate;
            yield return 0;
        }
        MainMenuMusicSource.volume = 1;
    }

    public void InGameMusicStart()
    {
        if (!isIGMplaying)
        {
            StartCoroutine(playIGMusic());
            isIGMplaying = true;
        }
        igmfadein();
    }

    public void igmfadein()
    {
        StartCoroutine(IGMusicFadeIn());
    }

    IEnumerator IGMusicFadeIn()
    {
        float time = 1.8f;
        float j = 0;
        float rate = 1 / time;

        while ((j < 1) && game)
        {
            IngamemusicSource.volume = j;
            j += Time.deltaTime * rate;
            yield return 0;
        }
        IngamemusicSource.volume = 1;
    }

    public IEnumerator playIGMusic()
    {
        yield return null;

        for (int i = Random.Range(0, Ingamemusic.Length); i < Ingamemusic.Length; i++)
        {
            IngamemusicSource.clip = Ingamemusic[i];
            IngamemusicSource.Play();

            Debug.Log(IngamemusicSource.clip.name);

            while (IngamemusicSource.isPlaying)
            {
                yield return null;
            }

            if (i == Ingamemusic.Length - 1)
                i = -1;
        }
    }

    public void menuFadeOut()
    {
        StartCoroutine(menufadeout());
    }

    IEnumerator menufadeout()
    {
        float time = 1.2f;
        float i = MainMenuMusicSource.volume;
        float rate = 1 / time;

        while (i > 0)
        {
            MainMenuMusicSource.volume = i;
            i -= Time.deltaTime * rate;
            yield return 0;
        }
        MainMenuMusicSource.volume = 0;
        InGameMusicStart();
    }


    public void igmfadeout()
    {
        StartCoroutine(IGMusicFadeOut());
    }

    IEnumerator IGMusicFadeOut()
    {
        float time = 1.8f;
        float j = IngamemusicSource.volume;
        float rate = 1 / time;

        while (j > 0)
        {
            IngamemusicSource.volume = j;
            j -= Time.deltaTime * rate;
            yield return 0;
        }
        IngamemusicSource.volume = 0;
        menufadein();
    }
}
