using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colideTeste : MonoBehaviour
{
     public Rigidbody rb;
     public Transform bola;
     public Transform raquete;

     public GameObject ball;
    private GameObject[] bolinha;

    public float teste;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bolinha = GameObject.FindGameObjectsWithTag("ball");

        foreach(GameObject bola in bolinha)
        {
            ball = bola;

        }

        // se a raquete estiver na frente da 
        if((dist(ball, raquete)<50) && (isFront(ball, raquete))){
            rb.isKinematic = false;
        }else{
            rb.isKinematic = true;
        }
        
    }
    bool isFront(GameObject posBola, Transform posRaquete){
        // verifica se a bola está na frente da raquete
        return (posRaquete.position.z - posBola.GetComponent<Transform>().position.z)>=0;
    }

    float dist(GameObject posBola, Transform posRaquete)
    {
        // mede a distancia da raquete até a bola
        return Mathf.Sqrt(Mathf.Pow((posRaquete.position.x - posBola.GetComponent<Transform>().position.x), 2) + Mathf.Pow((posRaquete.position.y - posBola.GetComponent<Transform>().position.y), 2) + Mathf.Pow((posRaquete.position.z - posBola.GetComponent<Transform>().position.z), 2));
    }


}
