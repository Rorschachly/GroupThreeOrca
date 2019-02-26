using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour {

    private bool hold;
    private Collider rightHand;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed");
        }
        if (hold)
        {
            Debug.Log("Hold in");
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Grabbed");
                //this.transform.position = rightHand.transform.position;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        hold = true;
        rightHand = other;
    }

    private void OnTriggerExit(Collider other)
    {
        hold = false;
    }
}
