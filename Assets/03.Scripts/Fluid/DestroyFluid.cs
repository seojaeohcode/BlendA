using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFluid : MonoBehaviour
{
    public GameObject RootDrink;
    public GameObject FluidPoint;

    public bool isX = false;
    public bool isZ = false;

    void Start()
    {
        RootDrink = transform.parent.parent.gameObject;
        FluidPoint = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = FluidPoint.transform.position;

        isZ = ((Mathf.Abs(RootDrink.transform.rotation.eulerAngles.z)%360) >= 60 
            && (Mathf.Abs(RootDrink.transform.rotation.eulerAngles.z)%360) <= 270);
        isX = ((Mathf.Abs(RootDrink.transform.rotation.eulerAngles.x)%360) >= 60 
            && (Mathf.Abs(RootDrink.transform.rotation.eulerAngles.x)%360) <= 270);

        if (!(isX || isZ))
        {
            Destroy(gameObject,0.01f);
        }

    }
}
