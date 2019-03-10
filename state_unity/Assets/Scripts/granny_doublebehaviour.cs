using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granny_doublebehaviour : MonoBehaviour {

    // Use this for initialization

    public Transform pos;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(transform.position, pos.position, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pos.rotation, 0.3f * Time.deltaTime);
		
	}
}
