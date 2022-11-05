using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFluid : MonoBehaviour
{
    //액체 변수
    public GameObject Obi;
    //액체 소환지점
    public Transform FluidPoint;
    public bool isFluid = false;

    public bool isX=false;
    public bool isZ=false;

    // Update is called once per frame
    void Update()
    {
        isZ = ((Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) % 360) >= 60 
            && (Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) % 360) <= 270);
        isX = ((Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) % 360) >= 60 
            && (Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) % 360) <= 270);
        //만약 술병이 기울었으면
        if (isX || isZ)
        {
            //액체 생성
            if (isFluid == false)
            {
                Debug.Log("음료생성");
                isFluid = true;
                GameObject temp = Instantiate(Obi, FluidPoint.position, Quaternion.Euler(0, 0, 0));
                temp.transform.SetParent(FluidPoint.transform);
            }
        }
        
        if (!(isX)&&!(isZ))
        {
            isFluid = false;
        }
    }
}
