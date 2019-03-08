using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour {

    private bool rightHandtouched = false;
    private bool leftHandtouched = false;
    public GameObject rightHandDisable;
    public GameObject leftHandDisable;
    private Collider rightHand;
    private Collider leftHand;

    public Transform leftholder, rightholder;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (rightHandtouched)
        {
            stickOnToFlipper(rightHand);
        } else if (leftHandtouched)
        {
            stickOnToFlipper(leftHand);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerLeftHand"))
        {
            Debug.Log("Left Hand touched");
            leftHandtouched = true;
            rightHandtouched = false;
            leftHand = other;
            rightHandDisable.tag = "Player";
        } else if (other.gameObject.CompareTag("PlayerRightHand"))
        {
            Debug.Log("Right Hand touched");
            rightHandtouched = true;
            leftHandtouched = false;
            rightHand = other;
            leftHandDisable.tag = "Player";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerRightHand"))
        {
            rightHandtouched = false;
            leftHandDisable.tag = "PlayerLeftHand";
        } else if (other.gameObject.CompareTag("PlayerLeftHand"))
        {
            leftHandtouched = false;
            rightHandDisable.tag = "PlayerRightHand";
        }
    }

    private void stickOnToFlipper(Collider whichhand)
    {
        if (whichhand.name == "left_flipper")
            this.transform.position = leftholder.position;
        else
            this.transform.position = rightholder.position;
    }
}
