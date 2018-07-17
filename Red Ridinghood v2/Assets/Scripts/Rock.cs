
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public float rockfallForce;

    private Rigidbody rb;
    private float waitTime;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void FallTrigger(float time)
    {
        //Debug.Log("Fall function is called");
        waitTime = time;
        StartCoroutine("Fall");
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(waitTime);
        rb.isKinematic = false;
        float xForce = Random.Range(-rockfallForce, rockfallForce);
        rb.AddForce(xForce, rockfallForce, 0);
        yield return null;
    }
}