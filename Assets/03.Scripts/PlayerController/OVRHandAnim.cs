using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRHandAnim : MonoBehaviour
{
    // OVR 컨트롤러 위치를 확인하기 위한 변수
    public OVRInput.Controller controller;

    // Hand 모델의 애니메이터 컴포넌트 저장 변수
    [SerializeField]
    private Animator handAnim = null;

    // Trigger Button을 누르는 힘에 따라 변하는 값

    private float triggerValue = 0;

    // Grip Button을 누르는 힘에 따라 변하는 값
    private float gripValue = 0;


    void Start()
    {
        
    }


    void Update()
    {
        ControllerInputState();

        //Hand 애니메이터 컴포넌트의 파라미터(Triggerm Grip)값을 변경하는 기능
        handAnim.SetFloat("Trigger", triggerValue);
        handAnim.SetFloat("Grip", gripValue);
    }

    private void ControllerInputState()
    {
        //입력한 컨트롤러 위치에 따라 해당 컨트롤러 버튼의 Trigger, Grip Value를 변경하는 기능
        triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        gripValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

    }

}
