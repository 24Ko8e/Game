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

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        IngamemusicSource.volume = 0;
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

    public void InGameMusicStart()
    {
        StartCoroutine(playIGMusic());
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

        while (j < 1)
        {
            IngamemusicSource.volume = j;
            j += Time.deltaTime * rate;
            yield return 0;
        }
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

    
}
