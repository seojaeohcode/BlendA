using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRLocomotion : MonoBehaviour
{
    // PlayerTurn을 사용할건지, PlayerRotate를 사용할건지 정하는 변수
    public bool turnRotate = false;

    public Transform player;

    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public float rotateAngle = 25f;     // 고정된 회전 각도를 지정하는 변수

    private Vector3 movePosition = Vector3.zero;
    private Vector3 rotateDirection = Vector3.zero;

    private Vector2 moveValue = Vector2.zero;       // 왼쪽 컨트롤러의 Thumbstick Value
    private Vector2 rotateValue = Vector2.zero;     // 오른쪽 컨트롤러의 Thubmstick Value

    void Update()
    {
        //PlayerMove();

        if (!turnRotate)
        {
            //PlayerRotate();
        }
        else
        {
            //PlayerTurn();
        }
    }

    // 왼쪽 컨트롤러의 LThumbstick의 값에 따라 이동하는 기능
    private void PlayerMove()
    {
        moveValue = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        movePosition.Set(moveValue.x, 0, moveValue.y);

        player.Translate(movePosition * moveSpeed * Time.deltaTime);
    }

    // 오른쪽 컨트롤러의 RThumbstick의 값에 따라 회전(부드러운 회전)하는 기능
    private void PlayerRotate()
    {
        rotateValue = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        player.Rotate(Vector3.up * rotateValue.x * rotateSpeed * Time.deltaTime);
    }

    private void PlayerTurn()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            OVRFade.Instance.AutoFade();
            player.rotation = Quaternion.Euler(0, player.rotation.eulerAngles.y + rotateAngle, 0);
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            OVRFade.Instance.AutoFade();
            player.rotation = Quaternion.Euler(0, player.rotation.eulerAngles.y - rotateAngle, 0);
        }
    }
}
