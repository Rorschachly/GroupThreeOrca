using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny_Behavior : MonoBehaviour {

    // Use this for initialization

    Animator aniamtor;
    public static bool is_fish = false;
    int fishHash = Animator.StringToHash("give_fish");
	void Start () {
        aniamtor = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (is_fish)
            aniamtor.SetTrigger(fishHash);
	}
}
