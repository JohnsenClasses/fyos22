using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothBall : MonoBehaviour
{
    [SerializeField] Transform firePosition;
    [SerializeField] AudioClip hitSound;

    public void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = this.GetComponent<Rigidbody>().velocity;
        if (v.magnitude > .1f)
        {
            this.transform.forward = this.GetComponent<Rigidbody>().velocity.normalized;
        }
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
