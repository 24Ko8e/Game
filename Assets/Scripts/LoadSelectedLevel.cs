using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSelectedLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int lvl)
    {
        if (lvl <= GameObject.Find("GameManager").GetComponent<GameManager>().levelsunlocked)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().currentlevel = lvl;
            PlayerPrefs.SetInt("CurrentLevel", GameObject.Find("GameManager").GetComponent<GameManager>().currentlevel);
            PlayerPrefs.Save();

            GameObject.Find("AudioManager").GetComponent<AudioManager>().game = true;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().menu = false;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().menuFadeOut();
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            Debug.Log("level locked");
        }
    }
}
