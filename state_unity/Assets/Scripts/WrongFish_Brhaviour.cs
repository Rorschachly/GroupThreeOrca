using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongFish_Brhaviour : MonoBehaviour {

    // Use this for initialization
    bool startdissolve = false, expand = false;
    float dissolve_value;

    void Start () {
        dissolve_value = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(startdissolve)
        {
            expand = false;
            transform.localScale = Vector3.one;
            gameObject.GetComponent<Material>().SetFloat(Shader.PropertyToID("Vector1_B597625B"), dissolve_value);
            dissolve_value += 0.1f;
            if (dissolve_value > 1.5f)
                startdissolve = false;
        }
        if (expand)
                transform.localScale += new Vector3(0.03f,0.03f,0.03f);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("dissolve");
        expand = true;
    }

    IEnumerator dissolve()
    {
        yield return new WaitForSeconds(2f);
        startdissolve = true;
    }
}
