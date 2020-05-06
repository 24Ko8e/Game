using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float maxspeed;
    public GameObject deathparticles;
    public bool alive = true;
    public AudioSource playerdeathSound;
    private Vector3 playerspawn;
    bool touch = false;

    Vector3 pointA;
    Vector3 pointB;
    public Transform innerCircle;
    public Transform outerCircle;

    int ControlsPref = 1;

    int i = 1;
    bool nxtLVL = true;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        playerspawn = transform.position;
        ControlsPref = GameObject.Find("Gamemanager").GetComponent<GameManager>().ControlsPref;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive && transform.position.y < 0.28f)
        {
            //transform.Translate(Input.acceleration.x, 0, Input.acceleration.y);
            //rb.AddForce(Input.GetAxisRaw("Horizontal") * force * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * force * Time.deltaTime);  // This is only for debugging purposes. Remove this during final build. 
        if (ControlsPref == 1)
        {
            rb.AddForce(Input.acceleration.x * force * Time.deltaTime, 0, Input.acceleration.y * force * Time.deltaTime);  // Remove the comment for final build.
        }
        if(ControlsPref == 2) { 
            
                //code for d-pad

        }
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);

        if (transform.position.y < 0)
        {
            alive = false;
            if (transform.position.y < -2f)
            {
                PlayerFell();
            }
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            PlayerDied();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Goal" && nxtLVL == true && alive == true)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().CompleteLevel();
            nxtLVL = false;
        }
        if(other.transform.tag == "Enemy")
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        while(alive)
        {
            alive = false;
            GameObject.Find("LevelManager").GetComponent<LevelManager>().ResetStars();
            playerdeathSound.Play();
            Instantiate(deathparticles, transform.position, Quaternion.Euler(-90, 0, 0));
            Invoke("resetposition", 1f);
            GetComponent<Animation>().Play();
        }
    }

    void PlayerFell()
    {
        alive = false;
        Invoke("resetposition", 1f);
    }

    void resetposition()
    {
        transform.position = new Vector3(playerspawn.x, playerspawn.y + 0.45f, playerspawn.z);
        alive = true;
        i-= 1;
    }
}
