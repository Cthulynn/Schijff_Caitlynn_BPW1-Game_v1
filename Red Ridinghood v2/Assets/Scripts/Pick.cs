using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{

    private AudioSource audioComponent;

    private void Start()
    {
        audioComponent = GetComponent<AudioSource>();
    }

    void Update()

    {
        //Als Audio klaar is, maak het dan kapot
        if (!audioComponent.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}