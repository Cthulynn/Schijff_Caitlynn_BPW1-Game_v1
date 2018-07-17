﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockfall : MonoBehaviour
{

    public GameObject popupToScream;
    public Transform rockParent;
    public float delayTime;

    private AudioSource fusRoDah;
    private List<Rock> rocks = new List<Rock>();
    private bool rocksHaveGone = false;
    private bool playerIsClose = false;

    private void Start()
    {
        //Debug.Log(rockParent.name);
        foreach (Transform rock in rockParent)
        {
            rocks.Add(rock.GetComponent<Rock>());
            Debug.Log(rock.name);
        }
        fusRoDah = gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!rocksHaveGone && playerIsClose)
        {
            if (Input.GetKey("e"))
            {
                //shoot away rocks
                foreach (Rock rock in rocks)
                {
                    rock.FallTrigger(delayTime);
                    Debug.Log(rock.name);
                }
                rocksHaveGone = true;
                fusRoDah.Play();
                popupToScream.SetActive(false);
                Debug.Log("rocks should shoot");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //display message
            playerIsClose = true;
            if (!rocksHaveGone)
            {
                popupToScream.SetActive(true);
            }
            Debug.Log("player enters trigger");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //turn off message
            playerIsClose = false;
            popupToScream.SetActive(false);
            Debug.Log("player exits trigger");
        }
    }
}