using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothcanSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip hitSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }
}
