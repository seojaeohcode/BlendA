using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour
{
    public Vector3 nowPosition;
    public Vector3 nowPosition2;
    public Vector3 nowRoation;
    
    // Start is called before the first frame update
    private void Awake()
    {
        nowPosition = this.transform.position;
        nowRoation = this.transform.eulerAngles;
    }

    void Start()
    {
        nowPosition2 = new Vector3(nowPosition.x, nowPosition.y+1, nowPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MapCollider"))
        {
            
            this.transform.position = nowPosition;
            this.transform.eulerAngles = nowRoation;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
