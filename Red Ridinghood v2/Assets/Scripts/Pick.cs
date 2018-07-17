using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{

    private AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!Audio.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}