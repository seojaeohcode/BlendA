using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPosition : MonoBehaviour
{
    public bool isX = false;
    public bool isZ = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.rotation.eulerAngles.z != 0 || gameObject.transform.rotation.eulerAngles.x !=0)
        {

        }   
    }
}
