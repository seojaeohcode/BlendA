using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillLiquid : MonoBehaviour
{

    float a;
    float b;
    void Start()
    {
        Renderer r = GetComponent<Renderer>();
        r.material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        //a = transform.GetComponent<Renderer>().material.GetFloat("_FillAmount");
        transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", 1.6f);
        Debug.Log("Amount Value is" + a);
    }

    // Update is called once per frame
    void Update()
    {
        FillA();
        a--;
    }

    void FillA()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("drink"))
        {
            Debug.Log("¿Ω∑· ¡¢√À");
            a=transform.GetComponent<Renderer>().material.GetFloat("_FillAmount");
            a--;
        }
    }

}
