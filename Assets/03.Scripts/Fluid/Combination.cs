using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{

    int ID;
    public GameObject OrangeCup;
    
    void Start()
    {
        ID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision) // 접촉시 기존 오브젝트들 삭제 후 지정된 오브젝트 생성
    {
        if (collision.collider.gameObject.CompareTag("Object"))
        {
            Debug.Log("접촉");
            Instantiate(OrangeCup, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
