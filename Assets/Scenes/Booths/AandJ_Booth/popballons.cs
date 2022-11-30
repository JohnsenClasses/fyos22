using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popballons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //or gameObject.SetActive(false);
        }
    }   
    // Update is called once per frame
    void Update()
    {
        
    }
}
