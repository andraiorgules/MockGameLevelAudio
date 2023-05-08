using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    
    public AudioClip enterClip;
    public AudioClip exitClip;
    
    private AudioSource source;

    public float enterExitClip = .5f;

    public GameObject groundObject;
    private AudioSource backgroundMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        backgroundMusic = groundObject.GetComponent<AudioSource>();
        
        
        if (!groundObject)
        {
            Debug.Log("No game objects are tagged with 'Ground'");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.PlayOneShot(enterClip,enterExitClip);
            backgroundMusic.mute = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.PlayOneShot(exitClip,enterExitClip);
            backgroundMusic.mute = false;
            
        }
    }
}
