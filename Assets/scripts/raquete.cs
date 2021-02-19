using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raquete : MonoBehaviour
{

    

    public Rigidbody raquetes;
    public GameObject ball;
    private GameObject[] bolinha;


    public Transform tRaquetes;


    public float teste = 5.0f;
    public int testeB = 1;

    private void Awake()
    {

    }

    void Start()
    {
        //ball.AddForce(new Vector3(1* teste, 17, -3* teste), ForceMode.VelocityChange); // implementa teste de aceleração, em breve vou colocar essa funçao para o lançador

    }



    void FixedUpdate()
    {
        bolinha = GameObject.FindGameObjectsWithTag("ball");

        foreach(GameObject bola in bolinha)
        {
            ball = bola;

        }

       


        if ((dist(ball, tRaquetes) < testeB*0.1f) && (ball.GetComponent<Transform>().position.z > tRaquetes.position.z))
        {
            
            raquete2(ball, raquetes);
            //raquete1(ball, raquetes);
        }



    }

    void raquete2(GameObject ball, Rigidbody raquetes)
    {
        print(Mathf.Sin(tRaquetes.rotation.eulerAngles.y));
        // se a raquete estiver muito proxima da bola, rebate com o impulso da mesma 
        ball.GetComponent<Rigidbody>().AddForce(Vector3.Reflect(ball.GetComponent<Rigidbody>().position, Vector3.left)*1000000, ForceMode.Impulse);
    }

    
    float dist(GameObject posBola, Transform posRaquete)
    {

        return Mathf.Sqrt(Mathf.Pow((posRaquete.position.x - posBola.GetComponent<Transform>().position.x), 2) + Mathf.Pow((posRaquete.position.y - posBola.GetComponent<Transform>().position.y), 2) + Mathf.Pow((posRaquete.position.z - posBola.GetComponent<Transform>().position.z), 2));
    }

    // void raquete1(GameObject ball, Rigidbody raquetes)
    // {
    //     print(Mathf.Sin(tRaquetes.rotation.eulerAngles.y));
    //     // se a raquete estiver muito proxima da bola, rebate com o impulso da mesma 
    //     ball.GetComponent<Rigidbody>().AddForce(new Vector3((ball.GetComponent<Rigidbody>().velocity.x) * -Mathf.Cos(tRaquetes.rotation.eulerAngles.y), 
    //         (ball.GetComponent<Rigidbody>().velocity.y) * tRaquetes.rotation.x * -50, (ball.GetComponent<Rigidbody>().velocity.z) * Mathf.Sin(tRaquetes.rotation.eulerAngles.y)) * 100, ForceMode.Impulse);
    // }

}
