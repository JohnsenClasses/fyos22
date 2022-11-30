using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
    public Transform head;
    Vector3[] lastGripPositions = new Vector3[2];
    public Transform[] hands;
    OVRGrabber[] grabbers;
    // Start is called before the first frame update
    void Start()
    {
        grabbers = new OVRGrabber[hands.Length];
        for(int i = 0; i < hands.Length; i++)
		{
            grabbers[i] = hands[i].GetComponentInChildren<OVRGrabber>();
		}
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

        bool[] triggersPulled = new bool[2];
        triggersPulled[1] = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        triggersPulled[0] = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);

        for(int i = 0; i < hands.Length; i++)
		{
            if (triggers[i] > .6f && grabbers[i].grabbedObject == null)
            {
                Vector3 delta = hands[i].position - lastGripPositions[i];

                this.transform.Translate(-delta);

            }else if (triggersPulled[i])
			{
                if(grabbers[i].grabbedObject != null)
				{
                    grabbers[i].grabbedObject.gameObject.SendMessage("fire");
				}
			}


            lastGripPositions[i] = hands[i].position;
        }
        

    }
}
