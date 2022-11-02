using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
    public Transform head;
    Vector3[] lastGripPositions = new Vector3[2];
    public Transform[] hands;
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


        //add grip motion
        float triggerRight = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float triggerLeft = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        float[] triggers = new float[2] { triggerLeft, triggerRight };
        

        for(int i = 0; i < hands.Length; i++)
		{
            if (triggers[i] > .6f)
            {
                Vector3 delta = hands[i].position - lastGripPositions[i];

                this.transform.Translate(-delta);

                
            }
            lastGripPositions[i] = hands[i].position;
        }
        

    }
}
