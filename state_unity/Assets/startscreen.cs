using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startscreen : MonoBehaviour
{

    // Use this for initialization

    public Material mat;
    public GameObject granny, paticlesFXW, particle_white, particle_2, headInteaction, pod, grannyDouble, set;
    float disolve = -1f;
    bool open = false, close = false;
    void Start()
    {
        mat.SetFloat(Shader.PropertyToID("Vector1_4C2A0FE0"), -1f);
        set.SetActive(false);
        particle_2.SetActive(false);
        StartCoroutine("openscene");
    }

    IEnumerator openscene()
    {
        yield return new WaitForSeconds(1.5f);
        open = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            mat.SetFloat(Shader.PropertyToID("Vector1_4C2A0FE0"), disolve);
            disolve += 0.01f;
            if(disolve>0 && disolve<2)
            {
                set.SetActive(true);
                particle_2.SetActive(true);
            }
            if (disolve > 2)
            {
                open = false;
                gameObject.SetActive(false);
                granny.SetActive(true);
                paticlesFXW.SetActive(true);
                particle_white.SetActive(true);
                headInteaction.GetComponent<Player_GazeInteraction>().enabled = true;
            }
        }

        if (close)
        {
            mat.SetFloat(Shader.PropertyToID("Vector1_4C2A0FE0"), disolve);
            disolve -= 0.01f;
            if (disolve <= -1)
            {
                close = false;
                
                granny.SetActive(false);
                paticlesFXW.SetActive(false);
                particle_white.SetActive(false);
                headInteaction.GetComponent<Player_GazeInteraction>().enabled = false;
                pod.SetActive(false);
                grannyDouble.SetActive(false);
                set.SetActive(false);
                particle_2.SetActive(false);
                gameObject.SetActive(true);
            }
        }
    }

    public void closescreen()
    {
        gameObject.SetActive(true);
        mat.SetFloat(Shader.PropertyToID("Vector1_4C2A0FE0"), 2f);
        close = true;
    }
}
