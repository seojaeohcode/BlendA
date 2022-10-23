using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class FillLiquid : MonoBehaviour
{

    float a;
    //private RaycastHit hit; // 面倒等 按眉
    //public float raycastDistance = 50f;
    //float b;
    //private void OnParticleCollision(GameObject other)
    //{
    //    Debug.Log("立盟窃");
    //}


    void Start()
    {
        //Renderer r = GetComponent<Renderer>();
        //r.material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        //a = transform.GetComponent<Renderer>().material.GetFloat("_FillAmount");
        //transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", 1.6f);
        //Debug.Log("Amount Value is" + a);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.gameObject.CompareTag("glass"))
            {
                if (a > 0)
                {
                    a = a - 0.1f;
                }
                else
                {
                    a = 0;
                }
            }
            //FillA();
            //a--;
        }
        */
        //void FillA()
        //{

        //}

        //private void OnCollisionEnter(ObiCollider collision)
        //{
        //    if (collision.collider.gameObject.CompareTag("drink")) 
        //    {
        //        Debug.Log("澜丰 立盟");
        //        a=transform.GetComponent<Renderer>().material.GetFloat("_FillAmount");
        //        a--;
        //    }
        //}

        //void OnParticleCollision(GameObject other)
        //{
        //    Debug.Log("Particle hit!");
        //}
    }
}