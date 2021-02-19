using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    public Transform EixoCentral;
    public int dir;
    float timer;
    float timer1;
    float timer2;
    int passo;
    public float delay = 2f;
    public float delay1 = 2f;

    public Transform startPos;

    public GameObject ball;
    public GameObject rball;

    public float teste = 5.0f;

    public bool[] trainingMenu = {true, false, false, true};
    void Start()
    {
        


    }

    void Update()
    {
        
        EixoCentral.rotation = Quaternion.Euler(0, StepMotor(dir, delay) - 90, 0);
        frequency(delay1);
        selectTraining();

    }

    int StepMotor(int dir, float delay)
    {
        if (!(Time.time - timer < delay) )
        {
            if ((dir<=1) && (dir>=-1))
            {
                passo += dir;
            }
            timer = Time.time;
        }
        return passo;
    }

    void frequency(float delay)
    {
        if (!(Time.time - timer1 < delay))
        {
            CreateBall();
            timer1 = Time.time;
        }
    }

    void CreateBall()
    {
        
        float angulo = EixoCentral.transform.localRotation.y;
        GameObject newBall = (GameObject)Instantiate(ball);
        newBall.transform.position = startPos.transform.position;
        newBall.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Sin(angulo)* -teste*100, 500, Mathf.Cos(angulo) * -teste*100), ForceMode.Impulse);
    }

    void selectTraining()
    {
        if(trainingMenu[0] == true){
            trainingMenu[1] = false;
            trainingMenu[2] = false;
            trainingMenu[3] = false;
        }
        if(trainingMenu[1] == true){
            trainingMenu[0] = false;
            trainingMenu[2] = false;
            trainingMenu[3] = false;
        }
        if(trainingMenu[2] == true){
            trainingMenu[0] = false;
            trainingMenu[1] = false;
            trainingMenu[3] = false;
        }
        if(trainingMenu[3] == true){
            trainingMenu[0] = false;
            trainingMenu[1] = false;
            trainingMenu[2] = false;
        }

    }
}
