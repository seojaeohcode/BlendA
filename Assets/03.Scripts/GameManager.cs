using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsMan = true;
    public GameObject[] Npc = new GameObject[2];
    public AudioClip[] Music = new AudioClip[8];
    AudioSource AS;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        Npc[0].SetActive(true);
        Npc[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!AS.isPlaying)
            RandomPlay();
        ChangeSex();
    }

    void RandomPlay()
    {
        AS.clip = Music[Random.Range(0, Music.Length)];
        AS.Play();
    }

    void ChangeSex()
    {
        if (IsMan)
        {
            Npc[0].SetActive(true);
            Npc[1].SetActive(false);
        }
        else
        {
            Npc[0].SetActive(false);
            Npc[1].SetActive(true);
        }
    }
}
