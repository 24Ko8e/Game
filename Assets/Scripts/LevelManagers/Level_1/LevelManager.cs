using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// for Level 1
public class LevelManager : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] sw;
    public bool[] state;

    public int levelStars = 0;

    public int lvl1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        Debug.Log(levelStars + " levelStars");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ResetStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            levelStars = lvl1;
            stars[i].SetActive(state[i]);
            stars[i].GetComponent<AnimationScript>().enabled = state[i];
            stars[i].GetComponent<Star>().collected = !state[i];
            sw[i].SetActive(state[i]);
            sw[i].GetComponent<AnimationScript>().enabled = state[i];
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.StarState.Clear();
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i].GetComponent<Star>().collected == true)
            {
                save.StarState.Add(true);
            }
            else
            {
                save.StarState.Add(false);
            }
        }
        Debug.Log("Save game object created!");
        return save;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("lvl1", levelStars);
        PlayerPrefs.Save();

        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Level1.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/Level1.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Level1.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < stars.Length; i++)
            {
                if (save.StarState[i] == true) 
                {
                    state[i] = false;
                    stars[i].GetComponent<Star>().collected = true;
                    stars[i].SetActive(false);
                    sw[i].SetActive(false);
                    lvl1 += 1;
                }
                else
                {
                    state[i] = true;
                    stars[i].GetComponent<Star>().collected = false;
                    sw[i].SetActive(true);
                    stars[i].SetActive(true);
                    stars[i].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                    stars[i].GetComponent<AnimationScript>().enabled = true;
                    sw[i].GetComponent<AnimationScript>().enabled = true;
                }
            }
            levelStars = lvl1;
        }
        else
        {
            Debug.Log("No save file found!");

            if (lvl1 != PlayerPrefs.GetInt("lvl1", 0))
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("Cheating");
            }
        }
    }
}
