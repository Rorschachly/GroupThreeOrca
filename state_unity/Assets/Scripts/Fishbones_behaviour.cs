using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Fishbones_behaviour : MonoBehaviour
{

    // Use this for initialization
    public Transform pos;
    bool movedown = false;
    float dissolve_value;
    Renderer myrend;
    void Start()
    {
        myrend = GetComponent<Renderer>();
        dissolve_value = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (movedown)
        {
            transform.position = Vector3.Lerp(transform.position, pos.position, Time.deltaTime * 0.8f);
            myrend.material.SetFloat(Shader.PropertyToID("Vector1_329841D5"), dissolve_value);
            dissolve_value += 0.01f;
        }
    }

    public void Slideout()
    {
        myrend.material.SetFloat(Shader.PropertyToID("Vector1_329841D5"), 0f);
        GetComponent<ParentConstraint>().constraintActive = false;
        movedown = true;
    }
}
