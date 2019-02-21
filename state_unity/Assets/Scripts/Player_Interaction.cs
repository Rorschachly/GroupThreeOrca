using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour {


    public GameObject XRRig;
    public GameObject granny, box;
    public float raycastlength;
    [SerializeField] LayerMask mylayermask;
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

        //if(Physics.Raycast(myray, out hit, raycastlength,mylayermask.value))
        //{
        //    Debug.Log("called from hit");
        //   // hit.collider.GetComponent<Granny_Behavior>().LookAt();
        //}
        //else
        //{
        //   // granny.GetComponent<Granny_Behavior>().LookAway();
        //}

        //for testing without oclus
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            granny.GetComponent<Granny_Behavior>().LookAt();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("box");
            XRRig.transform.LookAt(box.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            granny.GetComponent<Granny_Behavior>().LookAway();
            granny.GetComponent<Granny_Behavior>().GoFish();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G");
            granny.GetComponent<Granny_Behavior>().LookAway();
            granny.GetComponent<Granny_Behavior>().GiveFish();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N");
            granny.GetComponent<Granny_Behavior>().LookAway();
            granny.GetComponent<Granny_Behavior>().NudgeFish();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "granny_swim")
        {
            Debug.Log(other.name);
        }

    }
}
