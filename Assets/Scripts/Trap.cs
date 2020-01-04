using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float delaytime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpikeTrap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpikeTrap()
    {
        while (true)
        {
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(delaytime);
        }
    }
}
