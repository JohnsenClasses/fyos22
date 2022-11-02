using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
    public Transform head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 leftJoy = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 rightJoy = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector2 joy = (leftJoy + rightJoy) / 2.0f;
        Vector3 movement = joy.x * head.right;
        movement += joy.y * head.forward;
        movement.y = 0;
        //movement.Normalize();
        this.transform.Translate(movement * Time.deltaTime*3);
    }
}
