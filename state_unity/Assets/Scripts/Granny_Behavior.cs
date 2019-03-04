using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FishState { CAUGHT, FLOATING, LOST, EATEN };
public class Granny_Behavior : MonoBehaviour
{

    // Use this for initialization
    public static FishState fish_st = FishState.CAUGHT;

    public GameObject theFishModel;
    public Transform cm;


    public ParticleSystem grannyBreath;
    public ParticleSystem fireworks;

    public AudioSource grannyHunt;
    public AudioSource grannyCallUser;
    public AudioSource grannyBubbleSound;
    public AudioSource celebration;
    public AudioSource chewing;


    Animator aniamtor;
    readonly int fishHash = Animator.StringToHash("give_fish");
    readonly int lookHash = Animator.StringToHash("lookat");
    readonly int endloonkHash = Animator.StringToHash("look_end");
    readonly int gofishHash = Animator.StringToHash("fish_trigger");
    readonly int nudge_trigger = Animator.StringToHash("nudge_trigger");
    readonly int wave = Animator.StringToHash("sayHi_trigger");
    readonly int clap_t = Animator.StringToHash("clap_trigger");
    readonly int  eat_t = Animator.StringToHash("eat_fish_trigger");
    float interim_time;
    bool isforward = false;
    int givefishCount = 0;
    void Start()
    {
        aniamtor = GetComponent<Animator>();
        interim_time = 4f;
        theFishModel.SetActive(false);
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
            transform.position = Vector3.Lerp(transform.position, cm.position, Time.deltaTime*0.25f);
            if (transform.position == cm.position)
                isforward = false;
        }

        if (givefishCount > 5)
        {
            Application.Quit();
        }
    }

    public void LookAt()
    {
        aniamtor.SetBool(lookHash, true);
    }

    IEnumerator FishIsLost()
    {
        yield return new WaitForSeconds(interim_time + 2f);
        Debug.Log("fish is lost");
        fish_st = FishState.LOST;
        StartCoroutine("GoFish");
    }

    IEnumerator GrannyEatFish()
    {
        yield return new WaitForSeconds(2f);
        aniamtor.SetTrigger(eat_t);
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
        Debug.Log("Clap");
        fish_st = FishState.EATEN;
        aniamtor.SetTrigger(clap_t);
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

    IEnumerator GiveFish()
    {
        givefishCount++;
        yield return new WaitForSeconds(2f);
        grannyBreath.Play();
        grannyBubbleSound.Play();
        theFishModel.SetActive(true);  // to make the fish appear
        if (fish_st == FishState.FLOATING)
            StartCoroutine("NudgeFish");
        if (fish_st == FishState.LOST)
            StartCoroutine("GoFish");
        if (fish_st == FishState.EATEN)
            Debug.Log("Celebration");
        aniamtor.SetTrigger(fishHash);
        fish_st = FishState.FLOATING;
    }

    IEnumerator NudgeFish()
    {
        yield return new WaitForSeconds(interim_time);

        if (fish_st == FishState.LOST)
            StartCoroutine("GoFish");
        if (fish_st == FishState.EATEN)
            Debug.Log("Celebration");
        if (fish_st == FishState.CAUGHT)
            StartCoroutine("GiveFish");

        aniamtor.SetTrigger(nudge_trigger);
        Debug.Log("nudge");
    }

    public void SwimOver()
    {
        isforward = true;
        Debug.Log("forward");
        grannyBreath.Play();
        grannyBubbleSound.Play();
        StartCoroutine("Wave");
    }

    public void EatenAndCelebration()
    {
        theFishModel.SetActive(false);
        celebration.Play();
        fireworks.Play();
    }
}
