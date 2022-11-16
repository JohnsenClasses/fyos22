using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire()
	{
        this.GetComponent<Renderer>().material.color = Color.red;
	}
}
