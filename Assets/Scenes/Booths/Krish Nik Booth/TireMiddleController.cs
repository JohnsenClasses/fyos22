using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMiddleController : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]
    private GameObject particle;
    


    void Start() {
        

    }

    public void OnTriggerEnter(Collider other) {
        if (ball == other.gameObject) {
            Destroy(this.gameObject);

            particle.SetActive(true);
        }

        

    }
}
