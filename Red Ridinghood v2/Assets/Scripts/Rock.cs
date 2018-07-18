using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    //Bedient hoe hard de rocks gaan vallen
    public float rockfallForce;

    private Rigidbody rb;
    private float waitTime;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void FallTrigger(float time)
    {   //wordt aangeroepen vanuit rockfall
        //Debug.Log("Fall function is called");
        waitTime = time;
        StartCoroutine("Fall");
    }

    private IEnumerator Fall()
    {
        //wacht op het  juiste moment om de rocks weg te schieten
        yield return new WaitForSeconds(waitTime);
        rb.isKinematic = false;
        float xForce = Random.Range(-rockfallForce, rockfallForce);
        rb.AddForce(xForce, rockfallForce, 0);
        yield return null;
    }
}