using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] patrolpoints;
    private int CurrentPoint;
    public float speed;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolpoints[0].position;
        CurrentPoint = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolpoints[4].position)
        {
            animator.SetBool("StoneJump", true);
        }

        if (transform.position == patrolpoints[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint <= 4) 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(patrolpoints[CurrentPoint].position - transform.position), 10 * Time.deltaTime);
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolpoints[CurrentPoint].position, speed * Time.deltaTime);

      
    }
}