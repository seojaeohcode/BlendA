using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNpc : MonoBehaviour
{

    public GameObject target;
    public Animator animator;
    public 

    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
    }

    void Update()
    {
        MoveToTarget();

    }

    void MoveToTarget()
    {
        if (target.transform.position != Vector3.MoveTowards(transform.position, target.transform.position, 1f))
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.025f); // 현위치, 도착점, 속도
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chair"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("sitting", true);
            target.SetActive(false);  

        }
    }
}
    
