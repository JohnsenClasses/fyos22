using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popballoons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        
        {
            Destroy(gameObject);
            
        }
    }   
    // Update is called once per frame
    void Update()
    {
        
    }
}
