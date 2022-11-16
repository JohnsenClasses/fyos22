using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothBall : MonoBehaviour
{
    public Transform firePosition;
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
        
        RaycastHit hitInfo;
        if(Physics.Raycast(firePosition.position, firePosition.forward, out hitInfo))
		{
            Rigidbody rb = hitInfo.rigidbody;
            if (rb != null)
            {
                rb.GetComponent<Renderer>().material.color = Color.red;
            }
        }
	}
}
