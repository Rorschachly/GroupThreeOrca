using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{

    private bool rightHandtouched = false;
    private bool leftHandtouched = false;
    public GameObject rightHandDisable, granny;
    public GameObject leftHandDisable;
    private Collider rightHand;
    private Collider leftHand;
    GameObject fish;

    public Transform leftholder, rightholder;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void celebrate()
    {
        granny.GetComponent<Granny_Behavior>().chewing.Play();
        granny.GetComponent<Granny_Behavior>().EatenAndCelebration();
        if (gameObject.CompareTag("Salmon3"))
            granny.GetComponent<Granny_Behavior>().Clap3();
        else if (gameObject.CompareTag("Fish"))
            granny.GetComponent<Granny_Behavior>().Clap2();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            celebrate();
        }
    }
        //if (other.gameObject.CompareTag("PlayerLeftHand"))
        //{
        //    Debug.Log("Left Hand touched");
        //    leftHandtouched = true;
        //    rightHandtouched = false;
        //    leftHand = other;
        //    rightHandDisable.tag = "Player";
        //}
        //else if (other.gameObject.CompareTag("PlayerRightHand"))
        //{
        //    Debug.Log("Right Hand touched");
        //    rightHandtouched = true;
        //    leftHandtouched = false;
        //    rightHand = other;
        //    leftHandDisable.tag = "Player";
        //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("PlayerRightHand"))
    //    {
    //        rightHandtouched = false;
    //        leftHandDisable.tag = "PlayerLeftHand";
    //    }
    //    else if (other.gameObject.CompareTag("PlayerLeftHand"))
    //    {
    //        leftHandtouched = false;
    //        rightHandDisable.tag = "PlayerRightHand";
    //    }
    //}

    //private void stickOnToFlipper(Collider whichhand)
    //{
    //    if (whichhand.name == "left_flipper")
    //        this.transform.position = leftholder.position;
    //    else
    //        this.transform.position = rightholder.position;
    //}
}
