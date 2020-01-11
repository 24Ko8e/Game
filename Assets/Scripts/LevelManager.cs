using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] sw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[0].GetComponent<Star>().collected)
            {
                stars[i].SetActive(false);
                sw[i].SetActive(false);
            }
        }
    }
}
