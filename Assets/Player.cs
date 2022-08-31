using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    int coinsCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            GetComponent<Rigidbody>().velocity = Vector3.up * 5;
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (coinsCollected > 10)
        {
            GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }
	}
	private void OnTriggerEnter(Collider other)
	{
        //GetComponent<Renderer>().material.color = other.transform.GetComponent<Renderer>().sharedMaterial.color;
        //SceneManager.LoadScene(0);
        Destroy(other.gameObject);
        coinsCollected += 1;
    }
}
