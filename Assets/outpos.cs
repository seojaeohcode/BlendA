using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outpos : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip door;
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
            this.audioSource.Play();
    }
}
