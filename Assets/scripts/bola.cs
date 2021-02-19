using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bola : MonoBehaviour
{

    public Rigidbody raquetes;
    public Rigidbody ball;

    public GameObject gball;

    public Transform tRaquetes;
    public Transform tBall;

    float timer1;
    float delay = 5;

    public float teste = 5.0f;
    public int testeB = 10;

    private void Awake()
    {

    }

    void Start()
    {
        gball = GameObject.FindGameObjectWithTag("ball");
        //ball.AddForce(new Vector3(1* teste, 17, -3* teste), ForceMode.VelocityChange); // implementa teste de aceleração, em breve vou colocar essa funçao para o lançador
        if (!(Time.time - timer1 < delay))
        {
            Destroy(gball);
            timer1 = Time.time;
        }
    }



    void FixedUpdate()
    {
        
        ball.AddForce(new Vector3(0, -98.1f, 0), ForceMode.Acceleration);  // garante a gravidade na bola 

        
    }
}
