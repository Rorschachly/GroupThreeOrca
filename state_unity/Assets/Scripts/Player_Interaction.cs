using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour {


    public GameObject XRRig;
    public GameObject granny;
    public float raycastlength;
    [SerializeField] LayerMask mylayermask;
    bool isstop = false, isforward = true;
	// Use this for initialization
	void Start () {
        Vector3 granny_pos = new Vector3(granny.transform.position.x, XRRig.transform.position.y,
       granny.transform.position.z);
        XRRig.transform.LookAt(granny_pos);
    }

    // Update is called once per frame
    void Update () {

        Ray myray = new Ray(XRRig.transform.position, XRRig.transform.forward * raycastlength);
        RaycastHit hit;

        if(Physics.Raycast(myray, out hit, raycastlength,mylayermask.value))
        {
            Vector3 granny_pos = granny.transform.position;
            XRRig.transform.LookAt(granny_pos);
        }

        if(!isstop && isforward)
            granny.transform.localPosition += new Vector3(0, 0, 0.08f);
        if (!isstop&&!isforward)
            granny.transform.Translate(-Vector3.forward*Time.deltaTime *5f, XRRig.transform);

        if (granny.transform.position.z > 2 && isforward)
        {
            isforward = false;
            granny.transform.LookAt(XRRig.transform.position);
        }

        //if (granny.transform.position.z < -15)
        //{
        //    isstop = true;
        //    granny_fish.transform.position = granny.transform.position;
        //    granny_fish.gameObject.SetActive(true);
        //    granny.gameObject.SetActive(false);
        //    Granny_Behavior.is_fish = true;
        //}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "granny_swim")
        {
            isstop = true;
            Granny_Behavior.is_fish = true;
        }

    }
}
