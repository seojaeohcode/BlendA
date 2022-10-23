using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFluid : MonoBehaviour
{
    public GameObject drink;
    public GameObject FluidPoint;

    public bool isX = false;
    public bool isZ = false;

    void Start()
    {
        drink = GameObject.FindWithTag("Object");
        FluidPoint = GameObject.FindWithTag("FluidPoint");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = FluidPoint.transform.position;

        isZ = ((Mathf.Abs(drink.transform.rotation.eulerAngles.z)%360) >= 60 
            && (Mathf.Abs(drink.transform.rotation.eulerAngles.z)%360) <= 270);
        isX = ((Mathf.Abs(drink.transform.rotation.eulerAngles.x)%360) >= 60 
            && (Mathf.Abs(drink.transform.rotation.eulerAngles.x)%360) <= 270);

        if (!(isX || isZ))
        {
            Destroy(gameObject,0.01f);
        }

    }
}
