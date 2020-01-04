using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] patrolpoints;
    private int CurrentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolpoints[0].position;
        CurrentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
      

        if(transform.position == patrolpoints[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint >= patrolpoints.Length)
        {
            CurrentPoint = 0;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, patrolpoints[CurrentPoint].position, speed * Time.deltaTime);
    }
}
