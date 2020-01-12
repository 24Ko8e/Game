using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelManager : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] sw;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ResetStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(true);
            stars[i].GetComponent<AnimationScript>().enabled = true;
            sw[i].SetActive(true);
            sw[i].GetComponent<AnimationScript>().enabled = true;
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
                Debug.Log(i + "true");
            }
            else
            {
                save.StarState.Add(false);
                Debug.Log(i + "false");
            }
        }
        Debug.Log("Save game object created!");
        return save;
    }

    public void SaveGame()
    {
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
                    stars[i].GetComponent<Star>().collected = true;
                    stars[i].SetActive(false);
                    sw[i].SetActive(false);
                    Debug.Log(i + "set to true");
                }
                else
                {
                    stars[i].GetComponent<Star>().collected = false;
                    sw[i].SetActive(true);
                    stars[i].SetActive(true);
                    stars[i].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                    stars[i].GetComponent<AnimationScript>().enabled = true;
                    sw[i].GetComponent<AnimationScript>().enabled = true;
                    Debug.Log(i + "set to false");
                }
            }
        }
        else
        {
            Debug.Log("No save file found!");
        }
    }
}
