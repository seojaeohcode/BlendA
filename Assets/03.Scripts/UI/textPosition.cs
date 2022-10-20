using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPosition : MonoBehaviour
{
    public GameObject Cam;

    Vector3 startScale;
    public float distance = 3;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float dist = Vector3.Distance(Cam.transform.position, transform.position);
        Vector3 newScale = startScale * dist / distance;
        transform.localScale = newScale;

        transform.rotation = Cam.transform.rotation;
    }
    /*
    public GameObject bottle;
    public float positionX = 0;
    public float positionY = 0;
    public float positionZ = 0;
    public bool isRotate = true;
    
    public GameObject Cam;
    private void Start()
    {
        
        positionX = bottle.transform.position.x;
        positionY = bottle.transform.position.y + 1.6f;
        positionZ = bottle.transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Cam.transform.rotation;
        
        if (gameObject.transform.position.x != 0 || gameObject.transform.position.z != 0)
        {
            transform.position = new Vector3(bottle.transform.position.x, positionY, bottle.transform.position.z);
        }

        if (gameObject.transform.rotation.eulerAngles.z != 0 || gameObject.transform.rotation.eulerAngles.x != 0)
        {
            if (isRotate)
            {
                positionX = bottle.transform.position.x;
                positionZ = bottle.transform.position.z;
                isRotate = false;
            }
           
            transform.position = new Vector3(positionX, positionY, positionZ);
            transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.eulerAngles.y, 0);
        }
        else
        {
            isRotate = true;
        }
        
    }
    */
}
