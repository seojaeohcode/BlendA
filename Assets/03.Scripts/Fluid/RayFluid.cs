using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RayFluid : MonoBehaviour
{
    float a;
    private RaycastHit hit; // 충돌된 객체
    public float raycastDistance = 10f;
    public GameObject glass;
    public GameObject bottle;
    Vector3 dir = new Vector3(0, 1, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer glassR = glass.GetComponent<Renderer>();
        Renderer glassTR = glass.transform.GetComponent<Renderer>();
        glassR.material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        a = glassTR.material.GetFloat("_FillAmount");
        glassTR.material.SetFloat("_FillAmount", 1.0f);
        Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = new Vector3(transform.rotation.eulerAngles.x, 1, transform.rotation.eulerAngles.z);
        //Vector3 f = gameObject.transform.position;
        //dir = new Vector3(-f.x, -dir.y, -f.z);
        //dir = dir.normalized;
        /*
        if (transform.rotation.eulerAngles.x == 0 && transform.rotation.eulerAngles.z==0)
        {
            dir = new Vector3(0, 1, 0);
        }
        else
        {
            dir += new Vector3(bottle.transform.rotation.eulerAngles.x, bottle.transform.rotation.eulerAngles.y, bottle.transform.rotation.eulerAngles.z);
        }
        */
        //dir = dir.normalized;
        //dir = new Vector3(dir.x%360, dir.y % 360, dir.z % 360);
        #region 레이 구동부
        //Vector3 look = transform.TransformDirection(dir);

        //Debug.DrawRay(transform.position, look * raycastDistance, Color.green, 0.5f);

        //if (Physics.Raycast(transform.position, look, out hit, raycastDistance))
        //{
        //    if (hit.collider.gameObject.CompareTag("glass"))
        //    {
        //        Debug.Log("채워짐");
        //        if (a > 0)
        //        {
        //            a -= 0.01f;
        //            Renderer glassTR = glass.transform.GetComponent<Renderer>();
        //            glassTR.material.SetFloat("_FillAmount", a);

        //        }
        //        else
        //        {
        //            a = 0;
        //            Renderer glassTR = glass.transform.GetComponent<Renderer>();
        //            glassTR.material.SetFloat("_FillAmount", a);
        //        }
        //    }
        //}
        //else
        //{
        //    /*
        //    if (a < 1)
        //    {
        //        a += 0.1f;
        //        Renderer glassTR = glass.transform.GetComponent<Renderer>();
        //        glassTR.material.SetFloat("_FillAmount", a);
        //    }
        //    */
        //}
        #endregion

        InvokeRepeating("RayFunction", 1.0f, 3.0f);
        
    }

    void RayFunction()
    {
        Vector3 look = transform.TransformDirection(dir);

        Debug.DrawRay(transform.position, look * raycastDistance, Color.green, 0.5f);

        //if (Physics.Raycast(transform.position, look, out hit, raycastDistance))
        //if(Physics.BoxCast(transform.position, transform.localScale, look, out hit, transform.parent.rotation, raycastDistance))
        if (Physics.Raycast(transform.position, look, out hit, raycastDistance))
        {
            if (hit.collider.gameObject.CompareTag("glass"))
            {
                Debug.Log("채워짐");
                if (this.gameObject.layer == LayerMask.NameToLayer("Alcohol"))
                {
                    //자기 자신의 태그나 레이어가 알콜인지 논알콜인지 체크.
                    if (GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] == null)
                    {
                        GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] = transform.parent.gameObject;
                        //들어온 술 오브젝트의 태그 체크
                    }
                }

                if (this.gameObject.layer == LayerMask.NameToLayer("NonAlcohol"))
                {
                    //자기 자신의 태그나 레이어가 알콜인지 논알콜인지 체크.
                    if (GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[1] == null)
                    {
                        GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[1] = transform.parent.gameObject;
                        //들어온 술 오브젝트의 태그 체크
                    }
                }

                ////자기 자신의 태그나 레이어가 알콜인지 논알콜인지 체크.
                //if (GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] == null)
                //{
                //    GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] = transform.parent.gameObject;
                //    //들어온 술 오브젝트의 태그 체크
                //}
                
                if (a > 0)
                {
                    a -= 0.002f;
                    Renderer glassTR = glass.transform.GetComponent<Renderer>();
                    glassTR.material.SetFloat("_FillAmount", a);

                }
                else
                {
                    a = 0;
                    Renderer glassTR = glass.transform.GetComponent<Renderer>();
                    glassTR.material.SetFloat("_FillAmount", a);
                }
            }
        }
    }
    /*
    private void OnDrawGizmos()
    {
        Vector3 look = transform.TransformDirection(dir);
        Gizmos.color = Color.green;
        // Physics.BoxCast (레이저를 발사할 위치, 사각형의 각 좌표의 절판 크기, 발사 방향, 충돌 결과, 회전 각도, 최대 거리)
        //레이 포인트의 포지션좌표,
        if (Physics.BoxCast(transform.position, transform.localScale, look, out hit, transform.parent.rotation, raycastDistance))
        {
            Gizmos.DrawRay(transform.position, look);
            Gizmos.DrawWireCube(transform.position + look * hit.distance, transform.localScale);
            if (hit.collider.gameObject.CompareTag("glass"))
            {
                Gizmos.DrawRay(transform.position, look);
                Gizmos.DrawWireCube(transform.position + look * hit.distance, transform.localScale);
            }   
        }
    }
    */
}