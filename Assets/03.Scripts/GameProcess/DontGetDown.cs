using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontGetDown : MonoBehaviour
{
    Rigidbody rigid;

    public Vector3 nowPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        nowPosition = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MapCollider"))
        {
            this.transform.position = nowPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
