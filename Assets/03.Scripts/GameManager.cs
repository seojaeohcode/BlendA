using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsMan = true;
    public GameObject[] Npc = new GameObject[2];
    
    void Start()
    {
        Npc[0].SetActive(true);
        Npc[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSex();
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
