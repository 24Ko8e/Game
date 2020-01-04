using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    GameObject player;
    PlayerMovement Playermovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Playermovement = player.GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Playermovement.alive)
        {
            Vector3 desiredposition = target.position + offset;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedposition;

            //transform.LookAt(target);
        }
    }
}
