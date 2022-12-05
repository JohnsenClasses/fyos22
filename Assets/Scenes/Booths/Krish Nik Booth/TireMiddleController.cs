using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMiddleController : MonoBehaviour
{
    public GameObject tireMiddle;
    public GameObject ball;
    public ParticleSystem particle;



    void Start() {

    }

    public void OnTriggerEnter(Collider other) {

        if (ball == other.gameObject) {
            tireMiddle.gameObject.SetActive(false);

            particle.Play();

            StartCoroutine(resetGame());
        }

        

    }

    IEnumerator resetGame(){
        Debug.Log("restarting game");

        yield return new WaitForSeconds(4);

        tireMiddle.gameObject.SetActive(true);

        ball.transform.localPosition = new Vector3(-.5f, 0.1f, 0);
        ball.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
