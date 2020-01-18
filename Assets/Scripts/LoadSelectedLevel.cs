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
        if (lvl <= GameManager.levelsunlocked)
        {
            GameManager.currentlevel = lvl;
            PlayerPrefs.SetInt("CurrentLevel", GameManager.currentlevel);
        }
            GameObject.Find("AudioManager").GetComponent<AudioManager>().game = true;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().menu = false;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().menuFadeOut();
            SceneManager.LoadScene("LoadingScene");
    }
}
