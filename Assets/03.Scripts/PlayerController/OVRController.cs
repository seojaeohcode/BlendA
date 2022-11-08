using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRController : MonoBehaviour
{
    // OVR 컨트롤러 위치를 확인하기 위한 변수
    public OVRInput.Controller controller;

    // OVR Player 변수
    public Transform player = null;

    // 컨트롤러의 Transform과 Rigidbody 변수
    private Transform handTransform = null;     // 부착하는 오브젝트의 위치, 회전
    private Rigidbody handRigidbody = null;     // 떼어지는 오브젝트의 velocity 값

    // 컨트롤러와 충돌한 후, PickUp할 수 있는 오브젝트를 저장하는 변수
    private Rigidbody attachedObject;

    // 컨트롤러와 충돌하는 다수의 충돌체를 저장하기 위한 배열 변수
    private List<Rigidbody> contactRigidbodies = new List<Rigidbody>();

    // 부착됐는지를 학인해서 Outline을 표시해주는 flag 변수
    private bool isAttached = false;

    void Start()
    {
        handTransform = GetComponent<Transform>();
        handRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Grip 버튼을 눌렀을 때 ObjectPickUp() 함수 호출
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            isAttached = true;

            ObjectPickUp();
        }       
        // Grip 버튼을 뗏을 때 ObjectDrop() 함수 호출
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            isAttached = false;

            ObjectDrop();
        }

    }

    // 오브젝트를 컨트롤러에 부착시키는 기능
    private void ObjectPickUp()
    {
        // attachObject = 가장 가까운 충돌체를 계산해서 넣어주기
        attachedObject = GetNearestRigidbody();

        // attachObject가 있을 때
        if (attachedObject == null)
            return;

        // attachObject의 rigidbody 값의 설정을 변경
        attachedObject.useGravity = false; // 부착된 오브젝트의 중력 비활성화
        attachedObject.isKinematic = true; // 부착된 오브젝트의 물리화 비활성화

        // attachObject의 위치, 회전값을 = handTransform으로 변경 (선택 사항, 위치& 회전 초기화)
        // attachedObject.transform.position = handTransform.position;
        // attachedObject.transform.rotation = handTransform.rotation;

        // attachObject의 Transform Parentfmf handTransform으로 변경 (차일드화, 부착)
        attachedObject.transform.parent = handTransform;
    }

    // 컨트롤러에 부착된 오브젝트를 떼어주는 기능
    private void ObjectDrop()
    {
        // attachObject가 있을 때
        if (attachedObject == null)
            return;

        // attachObject의 rigidbody 값의 설정을 변경
        attachedObject.useGravity = true; // 부착된 오브젝트의 중력 비활성화
        attachedObject.isKinematic = false; // 부착된 오브젝트의 물맇과 비활성화

        // attachObject에 handTransform에 가지고 있는 현재 Velocity값을 전달
        attachedObject.velocity += player.rotation * OVRInput.GetLocalControllerVelocity(controller);
        attachedObject.angularVelocity += player.rotation * OVRInput.GetLocalControllerAngularVelocity(controller);


        // 부착된 게임 오브젝트를 비워준다
        //attachedObject = null;

        // attachObject의 Transform Parentfmf handTransform으로 변경 (차일드화, 부착)
        attachedObject.transform.parent = null;
    }

    // 컨트롤러와 충돌한 Rigidbody 중 가장 가까운 충돌체를 판별하는 기능
    private Rigidbody GetNearestRigidbody()
    {

        // Rigidbody를 저장하는 임시변수
        Rigidbody nearestRigidbody = null;

        // 비교된 Distance 값을 저장하는 변수 (최소 값)
        float minDistance = float.MaxValue;

        // 현재 Distance 값을 저장하는 변수
        float distance = 0;

        // List에 저장된 충돌체 리스트 중 가까운 Rigidbody를 계산하는 기능
        foreach (Rigidbody rigidbody in contactRigidbodies)
        {
            // 현재 rigidbody와 HandTransform 사이의 거리를 비교
            distance = Vector3.Distance(rigidbody.transform.position, handTransform.position);

            // 현재 distance와 minDistance를 비교
            if(distance < minDistance)
            {
                // 최소 거리 값을 갱신
                minDistance = distance;

                // 반환할 가장 가까운 Rigidbody 객체를 갱신
                nearestRigidbody = rigidbody;
            }           
        }

        // 계산된 Rigidbody를 반환

        return nearestRigidbody;
    }

    // 컨트롤러에 오브젝트를 부착하는 조건
    // 1. Grip 버튼을 누른다
    // 2. 충돌이 가능해야 한다
    // 3. 충돌체가 간의 충돌이 일어나야 한다

    // 컨트롤러에 충돌한 오브젝트가 있을 때
    private void OnTriggerEnter(Collider other)
    {
        // 태그가 "InteractionObject"인 오브젝트를 구분하는 기능
        // 해당 게임오브젝트를 attactedObject에 할당하되, Rigidbody를 할당
        if (other.CompareTag ("Object"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // 배열에 충돌체를 저장
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 활성화 한다.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if(other.CompareTag("glass"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // 배열에 충돌체를 저장
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 활성화 한다.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if(other.CompareTag("Orange"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // 배열에 충돌체를 저장
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 활성화 한다.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if (other.CompareTag("Cherry"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // 배열에 충돌체를 저장
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 활성화 한다.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if(other.CompareTag("Lime"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // 배열에 충돌체를 저장
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 활성화 한다.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }

    }

    // 컨트롤러에 충돌한 오브젝트가 떼어졌을 때
    private void OnTriggerExit(Collider other)
    {
        // 태그가 "InteractionObject"인 오브젝트를 구분하는 기능
        // attactedObject를 null로 변경
        if (other.CompareTag("Object"))
        {
            //attachedObject = null;

            // 배열에 충돌체를 제거
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 비활성화 한다.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if (other.CompareTag("glass"))
        {
            //attachedObject = null;

            // 배열에 충돌체를 제거
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 비활성화 한다.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if(other.CompareTag("Orange"))
        {
            //attachedObject = null;

            // 배열에 충돌체를 제거
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 비활성화 한다.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if(other.CompareTag("Cherry"))
        {
            //attachedObject = null;

            // 배열에 충돌체를 제거
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 비활성화 한다.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if(other.CompareTag("Lime"))
        {
            //attachedObject = null;

            // 배열에 충돌체를 제거
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // 아직 컨트롤러에 부착되지 않았다면
            if (!isAttached)
            {
                // 충돌한 게임 오브젝트의 아웃라인을 비활성화 한다.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }


    }
}
