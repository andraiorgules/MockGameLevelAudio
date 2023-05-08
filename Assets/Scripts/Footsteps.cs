using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Footsteps : MonoBehaviour
{
    public AudioClip[] feetWater;
    public AudioClip[] feetDirt;
    private AudioSource source;
    private AudioClip footStep;
    private string surface = "dirt";
    

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(surface == "dirt")
            {
                footStep = feetDirt[Random.Range(0, feetDirt.Length)];
            }

            if (surface == "water")
            {
                footStep = feetWater[Random.Range(0, feetWater.Length)];
            }

            source.PlayOneShot(footStep);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("SoundArea1"))
        {
            Debug.Log(message: "Footsteps are water");
            surface = "water";
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("SoundArea1"))
        {
            Debug.Log(message: "Footsteps are dirt");
            surface = "dirt";
        }
    }
}
