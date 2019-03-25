using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Fish_Gameobject_Behaviour : MonoBehaviour {


    readonly int dropfish = Animator.StringToHash("dropFish");
    Animator aniamtor;
    bool movedown = false, ismoveforward = false;
    public Transform pos, pos2; //pos2 ued by salmon 2&3
    Quaternion rot;

    // Use this for initialization
    void Start () {
        aniamtor = GetComponent<Animator>();
        rot = new Quaternion(0,1.2f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (movedown)
        {
            transform.position = Vector3.Lerp(transform.position, pos.position, Time.deltaTime * 0.4f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.4f * Time.deltaTime);
            if (Vector3.Distance(transform.position, pos.position) < .04f)
                movedown = false;
        }
        if (ismoveforward)
        {
            transform.position = Vector3.Lerp(transform.position, pos2.position, Time.deltaTime*1.4f);
            if (Vector3.Distance(transform.position,pos2.position) < .04f)
                ismoveforward = false;
        }
            
	}
    public void show()
    {
        gameObject.SetActive(true);
    }

    public void unbend()
    {
        gameObject.GetComponent<ParentConstraint>().constraintActive = false;
        aniamtor.SetTrigger(dropfish);
        movedown = true;
    }

    public void moveforward()
    {
        ismoveforward = true;
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    GetComponent<Rigidbody>().AddForce(collision.transform.forward,ForceMode.Force);
    //}
}
