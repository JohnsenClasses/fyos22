using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMiddleController : MonoBehaviour
{
    public GameObject tireMiddle;
    public GameObject ball;
    public ParticleSystem particle;

    public Material playBall;
    public Material lockBall;

    private void Start()
    {
        ball.transform.localPosition = new Vector3(-0.5f, 0.13f, 0f);
        ball.transform.eulerAngles = new Vector3(0f, 0f, 0f);

    }

    void Update() {
        Vector3 ballPos = ball.transform.localPosition;
        Vector3 ballRot = ball.transform.eulerAngles;

        if(ballPos.y <= -0.2)
        {
            StartCoroutine(resetGame(3));
        }

        if (ballPos == new Vector3(-0.5f, 0.13f, 0f) && ballRot == new Vector3(0,0,0))
        {
            ball.GetComponent<MeshRenderer>().material = lockBall;
        }
        else
        {
            ball.GetComponent<MeshRenderer>().material = playBall;
        }

    }

    public void OnTriggerEnter(Collider other) {

        if (ball == other.gameObject) {
            tireMiddle.gameObject.SetActive(false);

            particle.Play();

            StartCoroutine(resetGame(5));
        }

        

    }

    IEnumerator resetGame(int seconds){
//        Debug.Log("restarting game");

        yield return new WaitForSeconds(seconds);
        if (!tireMiddle.gameObject.activeSelf)
        {
            tireMiddle.gameObject.SetActive(true);
        }

        ball.transform.localPosition = new Vector3(-.5f, 0.13f, 0);
        ball.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}