using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMove : MonoBehaviour
{
    [SerializeField] Transform[] objectPos;
    [SerializeField] float speed = 5f;
    int foodNum = 0;


    void Start()
    {
        transform.position = objectPos[foodNum].transform.position;
    }


    void Update()
    {
        MovePath();
    }

    public void MovePath()
    {
        transform.position = Vector3.MoveTowards
            (transform.position, objectPos[foodNum].transform.position, speed * Time.deltaTime);

        if (transform.position == objectPos[foodNum].transform.position)
            foodNum++;

        if (foodNum == objectPos.Length)
            foodNum = 0;
    }
}
