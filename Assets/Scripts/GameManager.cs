using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int currentscore;
    public static int highscore;

    public static int currentlevel;
    public static int levelsunlocked;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        currentlevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelsunlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        Debug.Log(currentlevel);
        Debug.Log(levelsunlocked);
    }

    public static void CompleteLevel()
    {
        levelsunlocked += 1;
        PlayerPrefs.SetInt("LevelsUnlocked", levelsunlocked);
        currentlevel += 1;
        PlayerPrefs.SetInt("CurrentLevel", currentlevel);
        SceneManager.LoadScene(currentlevel);

        PlayerPrefs.Save();
    }
}
