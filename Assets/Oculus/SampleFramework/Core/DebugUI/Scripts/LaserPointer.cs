using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserPointer : MonoBehaviour
{
    private LineRenderer rendo;

    void Start()
    {
        rendo = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            DoLaser(transform.position, transform.forward, 5f);
            rendo.enabled = true;
        }
        else
        {
            rendo.enabled = false;
        }
    }

    void DoLaser(Vector3 targetPos, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPos, direction);
        Vector3 endPos = targetPos + (direction * length);

        if(Physics.Raycast(ray, out RaycastHit rayHit, length))
        {
            endPos = rayHit.point;
            //Debug.Log(rayHit.collider.gameObject.name);
        }
        rendo.SetPosition(0, targetPos);
        rendo.SetPosition(1, endPos);
    }
}
