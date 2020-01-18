using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int currentlevel;
    public static int levelsunlocked;

    public static int totalStars = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        currentlevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelsunlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        totalStars = PlayerPrefs.GetInt("TotalStars", 0);
        Debug.Log(totalStars + "stars");
    }

    public static void CompleteLevel()
    {
        GameObject.Find("LevelManager").GetComponent <LevelManager > ().SaveGame();
        levelsunlocked += 1;
        PlayerPrefs.SetInt("LevelsUnlocked", levelsunlocked);
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
}
