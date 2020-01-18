using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitDelay());
    }

    IEnumerator waitDelay()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(LoadAsyncLevel());
    }

    IEnumerator LoadAsyncLevel()
    {
        AsyncOperation loadlevel = SceneManager.LoadSceneAsync(GameManager.currentlevel);

        while (!loadlevel.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        //GameObject.Find("AudioManager").GetComponent<AudioManager>().InGameMusicStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
