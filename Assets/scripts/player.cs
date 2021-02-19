using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform aimTarget; // the target where we aim to land the ball
    float force = 1300; // ball impact force

    bool hitting; // boolean to know if we are hitting the ball or not 

    public Transform ball; // the ball 
    Animator animator;

    Vector3 aimTargetInitialPosition; // initial position of the aiming gameObject which is the center of the opposite court


    private void Start()
    {
   
    }

    void Update()
    {
        



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // if we collide with the ball 
        {
            Vector3 dir = aimTarget.position - transform.position; // get the direction to where we want to send the ball
            other.GetComponent<Rigidbody>().velocity = dir.normalized * 100 + new Vector3(0, 100, 0);
            //add force to the ball plus some upward force according to the shot being played

            Vector3 ballDir = ball.position - transform.position; // get the direction of the ball compared to us to know if it is


            aimTarget.position = aimTargetInitialPosition; // reset the position of the aiming gameObject to it's original position ( center)

        }
    }
}
