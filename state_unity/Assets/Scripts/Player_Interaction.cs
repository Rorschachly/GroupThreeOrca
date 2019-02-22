using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour {


    public GameObject XRRig;
    public GameObject granny, box;
    public float raycastlength;
    [SerializeField] LayerMask mylayermask;
    bool isrotate = false;
    static float game_starttime;
    float counterTime, interimTime, postime;
    bool isLookAt = true, isFish = false, fisheaten = false, fishLost = false, nudgeFish = false, ispos=false;
    // Use this for initialization
    void Start () {
        interimTime = 2.18f;
        game_starttime = Time.time;
        counterTime = 0.0f;
        postime = 0f;
    }

    // Update is called once per frame
    void Update () {

        counterTime += Time.deltaTime;
        Debug.Log(counterTime);
        if (counterTime >= 5f)
        {
            XRRig.transform.LookAt(new Vector3(granny.transform.position.x, XRRig.transform.position.y,
          granny.transform.position.z));
            counterTime = 0f;
        }
        Ray myray = new Ray(XRRig.transform.position, XRRig.transform.forward * raycastlength);
        RaycastHit hit;

        if (isLookAt && Physics.Raycast(myray, out hit, raycastlength, mylayermask.value))
        {
            counterTime += Time.deltaTime;
            if (counterTime >= interimTime)
            {
                hit.collider.GetComponent<Granny_Behavior>().LookAt();
                isLookAt = false;
                counterTime = 0.0f;
            }
        }
        else
        {
            counterTime += Time.deltaTime;
            if (counterTime >= interimTime && !isLookAt)
            {
                granny.GetComponent<Granny_Behavior>().LookAway();
                counterTime = 0.0f;
            }
        }

        postime += Time.deltaTime;

        //for testing without oclus
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isrotate = true;
            postime = 0;
            fishLost = true;
            ispos = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isrotate = true;
        }
            if (isrotate)
        {
            Vector3 relpos = XRRig.transform.position - granny.transform.position;
            Quaternion rot = Quaternion.LookRotation(relpos);
            Quaternion cur = granny.transform.localRotation;
            granny.transform.rotation = Quaternion.Lerp(cur, rot, Time.deltaTime);
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

/* needs ENUM state for execution... looping and logic error has to be fixed.
 * if (ispos)
        {
            if (fishLost && postime >= 4f)
            {
                granny.GetComponent<Granny_Behavior>().GoFish();
                postime = 0.0f;
                isFish = true;
                fishLost = false;
            }

            if (isFish || fishLost && postime >= 2f)
            {
                granny.GetComponent<Granny_Behavior>().GiveFish();
                isFish = false;
                fisheaten = false;
                fishLost = false;
                postime = 0f;
            }

            if (!fisheaten && postime >= 3f)
            {
                granny.GetComponent<Granny_Behavior>().NudgeFish();
                postime = 0f;
                nudgeFish = true;
            }

            if (nudgeFish && postime >= 2.2f)
            {
                fisheaten = false;
                fishLost = true;
                isFish = false;
                postime = 0f;
            }
        }
 */