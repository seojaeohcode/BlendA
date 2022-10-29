using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkProcess : MonoBehaviour
{
    public GameObject[] FruitList = new GameObject[3];
    //public GameObject[] AlcoholList = new GameObject[2];
    //public GameObject[] NonAlcoholList = new GameObject[2];

    public GameObject FruitPoint;
    //public string DrinkType = "None";
    //술에 담은 내용물 이걸 가지고 if문에서 판단.
    //0:술 1:주스 2:과일
    public GameObject[] Element = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<3; i++)
        {
            Element[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Quaternion cur = this.transform.rotation;
        float changeRot = 0;

        Debug.Log("Z변경");
        if (cur.eulerAngles.z < 0)
        {
            changeRot = 100.0f;
        }
        else
        {
            changeRot = -100.0f;
        }

        Quaternion rotZ = Quaternion.Euler(new Vector3(0, 0, changeRot));
        cur *= rotZ;

        if (other.gameObject.CompareTag("Orange"))
        {
            
            Debug.Log("오렌지충돌");
            if (Element[2] == null)
            {
                Element[2] = FruitList[0];
                GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
                temp.transform.SetParent(FruitPoint.transform);
            }
        }
        else if (other.gameObject.CompareTag("Lime"))
        {
            Debug.Log("라임충돌");
            if (Element[2] == null)
            {
                Element[2] = FruitList[1];
                GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
                temp.transform.SetParent(FruitPoint.transform);
            }
        }
        else if (other.gameObject.CompareTag("Cherry"))
        {
            Debug.Log("체리충돌");
            if (Element[2] == null)
            {
                Element[2] = FruitList[2];
                GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
                temp.transform.SetParent(FruitPoint.transform);
            }
        }
    }
}
