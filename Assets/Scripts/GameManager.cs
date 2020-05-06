﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentlevel;
    public int levelsunlocked;
    public int ControlsPref;

    public GameObject hud;

    public int totalStars = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name)
                  && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
        hud.SetActive(false);

        currentlevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelsunlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        totalStars = PlayerPrefs.GetInt("TotalStars", 0);
        Debug.Log(totalStars + "stars");
        Debug.Log(currentlevel);
        Debug.Log(levelsunlocked);
    }

    public void CompleteLevel()
    {
        GameObject.Find("LevelManager").GetComponent <LevelManager > ().SaveGame();
        if (currentlevel == levelsunlocked)
        {
            levelsunlocked += 1;
            PlayerPrefs.SetInt("LevelsUnlocked", levelsunlocked);
            Debug.Log(levelsunlocked + " Total levels unlocked");
        }
        if (currentlevel < levelsunlocked) 
        {
            currentlevel += 1;
            PlayerPrefs.SetInt("CurrentLevel", currentlevel);
        }
        totalStars += GameObject.Find("LevelManager").GetComponent<LevelManager>().levelStars;
        PlayerPrefs.SetInt("TotalStars", totalStars);
        PlayerPrefs.Save();

        SceneManager.LoadScene("LoadingScene");
    }

    public void showHUD()
    {
        hud.SetActive(true);
    }
}
