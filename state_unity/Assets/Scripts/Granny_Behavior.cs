﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny_Behavior : MonoBehaviour {

    // Use this for initialization

    Animator aniamtor;
    int fishHash = Animator.StringToHash("give_fish");
    int lookHash = Animator.StringToHash("lookat");
    int endloonkHash = Animator.StringToHash("look_end");
    int gofishHash = Animator.StringToHash("fish_trigger");
    int nudge_trigger = Animator.StringToHash("nudge_trigger");
	void Start () {
        aniamtor = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
            //aniamtor.SetTrigger(fishHash);
	}

    public void LookAt()
    {
        aniamtor.SetBool(lookHash, true);
    }

    public void LookAway()
    {
        aniamtor.SetTrigger(endloonkHash);
        aniamtor.SetBool(lookHash, false);
    }

    public void GoFish()
    {
        aniamtor.SetTrigger(gofishHash);
    }

    public void GiveFish()
    {
        aniamtor.SetTrigger(fishHash);
    }

    public void NudgeFish()
    {
        aniamtor.SetTrigger(nudge_trigger);
    }

}
