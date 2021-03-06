﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongFish_Brhaviour : MonoBehaviour {

    // Use this for initialization
    bool startdissolve = false, expand = false;
    public Material mat;
    float dissolve_value;

    void Start () {
        mat.SetFloat(Shader.PropertyToID("Vector1_B597625B"), -1f);
        dissolve_value = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(startdissolve)
        {
            expand = false;
            transform.localScale = Vector3.one;
            dissolve_value += 0.01f;
            mat.SetFloat(Shader.PropertyToID("Vector1_B597625B"), dissolve_value);

            if (dissolve_value > 1.5f)
            {
                startdissolve = false;
                gameObject.SetActive(false);
            }
        }
        if (expand)
                transform.localScale += new Vector3(0.01f,0.01f,0.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("dissolve");
            expand = true;
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    StartCoroutine("dissolve");
    //    expand = true;
    //}

    IEnumerator dissolve()
    {
        yield return new WaitForSeconds(0.75f);
        startdissolve = true;
    }
}
