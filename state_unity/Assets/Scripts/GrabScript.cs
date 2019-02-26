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
        if (hold)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                this.transform.position = rightHand.transform.position;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hehe");
        hold = true;
        rightHand = other;
    }

    private void OnTriggerExit(Collider other)
    {
        hold = false;
    }
}
