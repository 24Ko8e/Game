using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int currentscore;
    public static int highscore;

    public static int currentlevel = 1;
    public static int levelsunlocked;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void CompleteLevel()
    {
        SceneManager.LoadScene(currentlevel + 1);
        currentlevel+=1;
    }
}
