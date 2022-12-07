using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMiddleController : MonoBehaviour
{
    public GameObject tireMiddle;
    public GameObject ball;
    public ParticleSystem particle;

    [Range(0f,10f)] public float fadeSpeed;

    // public Material playBall;
    // public Material lockBall;

    public Rigidbody rb;

    private void Start()
    {
        ball.transform.localPosition = new Vector3(-0.5f, 0.13f, 0f);
        ball.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        rb.velocity = new Vector3 (0f, 0f, 0f);

    }

    void FixedUpdate() {
        
        if(ball.transform.localPosition.y <= -0.2)
        {
            StartCoroutine(fadeBall());
        }

        // if (ballPos == new Vector3(-0.5f, .13f, 0f) && ballRot == new Vector3(0,0,0) && ballVel == new Vector3 (0,0,0))
        // {
        //     ball.GetComponent<MeshRenderer>().material = lockBall;
        // }
        // else
        // {
        //     ball.GetComponent<MeshRenderer>().material = playBall;
        // }

    }

    public void OnTriggerEnter(Collider other) {

        if (ball == other.gameObject) {
            tireMiddle.gameObject.SetActive(false);

            particle.Play();

            StartCoroutine(fadeBall());
        }

        

    }

//     IEnumerator resetGame(int seconds){
// //        Debug.Log("restarting game");

//         yield return new WaitForSeconds(seconds);
//         if (!tireMiddle.gameObject.activeSelf)
//         {
//             tireMiddle.gameObject.SetActive(true);
//         }

//         ball.transform.localPosition = new Vector3(-.5f, .13f, 0);
//         ball.transform.eulerAngles = new Vector3(0, 0, 0);

//         rb.velocity = new Vector3 (0,0,0);
//     }

    IEnumerator fadeBall(){
        
        yield return new WaitForSeconds(3);
        rb.velocity = new Vector3 (0,0,0);
        
        if (!tireMiddle.gameObject.activeSelf)
        {
            tireMiddle.gameObject.SetActive(true);
        }

        StartCoroutine(fadeOut());

        yield return new WaitForSeconds(1);

        ball.transform.localPosition = new Vector3(-.5f, .13f, 0);
        ball.transform.eulerAngles = new Vector3(0, 0, 0);
        rb.velocity = new Vector3 (0,0,0);
       

        StartCoroutine(fadeIn());
    }

    IEnumerator fadeOut(){
         while (ball.gameObject.GetComponent<MeshRenderer>().material.color.a > 0){
            Color color = ball.gameObject.GetComponent<MeshRenderer>().material.color;
            float alpha = color.a - (fadeSpeed * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, alpha);
            ball.gameObject.GetComponent<MeshRenderer>().material.color = color;
            
            yield return null;
        }
    }

    IEnumerator fadeIn(){
        while (ball.gameObject.GetComponent<MeshRenderer>().material.color.a < 1){
            Color color = ball.gameObject.GetComponent<MeshRenderer>().material.color;
            float alpha = color.a + (fadeSpeed * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, alpha);
            ball.gameObject.GetComponent<MeshRenderer>().material.color = color;
            
            yield return null;
        }
    }
}