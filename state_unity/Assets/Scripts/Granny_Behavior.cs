﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FishState { CAUGHT, FLOATING, LOST, EATEN };
public class Granny_Behavior : MonoBehaviour
{

    // Use this for initialization
    public static FishState fish_st = FishState.CAUGHT;

    public GameObject salmon, salmon_2, salmon_3, round_fish, will_fish, fishbones, heart;
    public Transform cm, fishpos;
    public ParticleSystem shuffleParticleLauncher;

    public ParticleSystem grannyBreath;
    public ParticleSystem fireworks;

    public AudioSource grannyHunt;
    public AudioSource grannyCallUser;
    public AudioSource grannyBubbleSound;
    public AudioSource celebration;
    public AudioSource chewing;


    Animator aniamtor;
    readonly int lookHash = Animator.StringToHash("lookat");
    readonly int endloonkHash = Animator.StringToHash("look_end");
    readonly int gofishHash = Animator.StringToHash("fish_trigger");
    readonly int wave = Animator.StringToHash("sayHi_trigger");
    readonly int clap_t = Animator.StringToHash("clap_trigger");
    readonly int nudge_again = Animator.StringToHash("nudge_fish_trigger");
    readonly int correct_fish = Animator.StringToHash("correct");
    float interim_time;
    bool isforward = false, checkfish = false;
    int givefishCount = 0;
    void Start()
    {
        aniamtor = GetComponent<Animator>();
        shuffleParticleLauncher.Stop();
        interim_time = 4f;
        grannyHunt.Stop();
        grannyBreath.Stop();
        grannyCallUser.Stop();
        grannyBubbleSound.Stop();
        fireworks.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isforward)
        {
            transform.position = Vector3.Lerp(transform.position, cm.position, Time.deltaTime * 0.25f);
            if (transform.position == cm.position)
                isforward = false;
        }

        if (checkfish)
        {
            Debug.Log("is fish eaten");
            //checkstate of fish
        }

    }

    public void LookAt()
    {
        aniamtor.SetBool(lookHash, true);
    }
    public void IdleDown2_branch()
    {
        //this branch is waiting on the user to eat the fist -story part1
        StartCoroutine("Nudge_Fish");
        checkfish = true;
    }

    IEnumerator Nudge_Fish()
    {
        Debug.Log("waiting for fish to be eaten");
        yield return new WaitForSeconds(4f);
        aniamtor.SetTrigger(nudge_again);
        //move_fish (crashinto player)
    }

    IEnumerator FishIsLost()
    {
        yield return new WaitForSeconds(interim_time + 2f);
        Debug.Log("fish is lost");
        fish_st = FishState.LOST;
        StartCoroutine("GoFish");
    }

    public void LookAway()
    {
        aniamtor.SetTrigger(endloonkHash);
        grannyCallUser.Play();
        aniamtor.SetBool(lookHash, false);
    }

    IEnumerator Clap()
    {
        yield return new WaitForSeconds(2f);
        salmon_2.SetActive(false);
        Debug.Log("Clap");
        fish_st = FishState.EATEN;
        aniamtor.SetTrigger(clap_t);
    }

    public void Clap2()
    {
        salmon_2.SetActive(false);
        Debug.Log("Clap");
        fish_st = FishState.EATEN;
        aniamtor.SetTrigger(clap_t);
    }

    public void Clap3()
    {
        salmon_3.SetActive(false);
        round_fish.SetActive(false);
        will_fish.SetActive(false);
        Debug.Log("Clap");
        fish_st = FishState.EATEN;
        aniamtor.SetTrigger(correct_fish);
    }

    public void ChooseCorrect()
    {
        aniamtor.SetTrigger(correct_fish);
    }



    IEnumerator GoFish()
    {
        yield return new WaitForSeconds(1f);
        aniamtor.SetTrigger(gofishHash);
        grannyHunt.Play();
        fish_st = FishState.CAUGHT;
    }
    IEnumerator Wave()
    {
        yield return new WaitForSeconds(3f);
        aniamtor.SetTrigger(wave);
        grannyCallUser.Play();
        StartCoroutine("GoFish");
    }

    public void SwimOver()
    {
        isforward = true;
        Debug.Log("forward");
        grannyBreath.Play();
        grannyBubbleSound.Play();
        StartCoroutine("Wave");
    }

    public void playheart()
    {
        heart.SetActive(true);
        //gameObject.SetActive(false);
    }
    /****************
        PARTICLES
     *****************/

    public void EatenAndCelebration()
    {
        celebration.Play();
        fireworks.Play();
    }

    public void playparticles()
    {
        shuffleParticleLauncher.Play();
    }

    /**********************
         FISH SCRIPTING
    ************************/

    public void showSalmon()
    {
        salmon.GetComponent<Fish_Gameobject_Behaviour>().show();
        salmon_2.GetComponent<Fish_Gameobject_Behaviour>().show();
    }

    public void showSalmon3()
    {
        salmon_3.SetActive(true);
    }

    public void fishbones_burp()
    {
        fishbones.GetComponent<Fishbones_behaviour>().Slideout();
    }

    public void showRound()
    {
        round_fish.SetActive(true);
    }

    public void showWill()
    {
        will_fish.SetActive(true);
    }

    public void dropfish(int fishnum)
    {
        switch (fishnum)
        {
            case 1:
                salmon.GetComponent<Fish_Gameobject_Behaviour>().unbend();
                break;
            case 2:
                salmon_2.GetComponent<Fish_Gameobject_Behaviour>().unbend();
                break;
            case 3:
                salmon_3.GetComponent<Fish_Gameobject_Behaviour>().unbend();
                break;
            case 4: //round
                round_fish.GetComponent<Fish_Gameobject_Behaviour>().unbend();
                break;
            case 5: //will
                will_fish.GetComponent<Fish_Gameobject_Behaviour>().unbend();
                break;
        }
    }

    public void hideSalmon()
    {
        salmon.SetActive(false);
    }

    public void pushfish(int fishnum)
    {
        switch (fishnum)
        {
            case 2:
                salmon_2.GetComponent<Fish_Gameobject_Behaviour>().moveforward();
                break;
            case 3:
                salmon_3.GetComponent<Fish_Gameobject_Behaviour>().moveforward();
                break;
            case 4:
                round_fish.GetComponent<Fish_Gameobject_Behaviour>().moveforward();
                break;
            case 5:
                will_fish.GetComponent<Fish_Gameobject_Behaviour>().moveforward();
                break;
        }

    }
}
