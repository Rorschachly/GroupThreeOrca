using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FishState { CAUGHT, FLOATING, LOST, EATEN };
public class Granny_Behavior : MonoBehaviour
{

    // Use this for initialization
    public static FishState fish_st = FishState.CAUGHT;

    public GameObject theFishModel;


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
            transform.Translate(transform.forward * Time.deltaTime, Space.World);

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

    public void LookAway()
    {
        aniamtor.SetTrigger(endloonkHash);
        grannyCallUser.Play();
        aniamtor.SetBool(lookHash, false);
    }

    IEnumerator GoFish()
    {
        yield return new WaitForSeconds(interim_time);
        aniamtor.SetTrigger(gofishHash);
        grannyHunt.Play();
        fish_st = FishState.CAUGHT;
    }

    IEnumerator GiveFish()
    {
        givefishCount++;
        yield return new WaitForSeconds(interim_time);
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

    }

    public void SwimOver()
    {
        isforward = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isforward)
        {
            Debug.Log("colided" + other.name);
            isforward = false;
            grannyBreath.Play();
            grannyBubbleSound.Play();
            StartCoroutine("GoFish");
        }
    }

    public void EatenAndCelebration()
    {
        theFishModel.SetActive(false);
        celebration.Play();
        fireworks.Play();
    }
}
