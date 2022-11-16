using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMiddleController : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]
    public static ParticleSystem particle;
    


    void Start() {

        particle = GetComponent<ParticleSystem>();
        particle.Stop();
        var main = particle.main;
        main.duration = 7f;
    }

    public void OnTriggerEnter(Collider other) {
        if (ball == other.gameObject) {
            Destroy(this.gameObject);
            
            particle.Play();
        }
        

    }
}
