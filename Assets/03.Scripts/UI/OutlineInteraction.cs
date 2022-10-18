using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineInteraction : MonoBehaviour
{
    // Outline 컴포넌트 사용 유무
    public bool useOutline = false;

    // 시작과 동시에 Outline을 표시할 것인지 유무
    public bool playOnAwake = false;

    // OutLine의 컬러 색상 설정
    public Color positiveColor = Color.white;

    // Quick Outline 컴포넌트를 저장하는 변수
    private Outline outline = null;

    void Start()
    {
        // 게임오브젝트가 아웃라인이 없다면
        if (useOutline)
        {
            // 게임오브젝트에 아웃라인 컴포넌트를 추가하여 할당
            if(gameObject.GetComponent<Outline>() == null)
            {
                outline = gameObject.AddComponent<Outline>();
            }
            else
            {
                // 아웃라인 컴포넌트가 있따면 해당 컴포넌트를 참조하여 할당
                outline = GetComponent<Outline>();
            }
        }
        // 아웃라인 컴포넌트를 삭제
        else
        {
            Destroy(GetComponent<Outline>());
        }

        //시작과 동시에 아웃라인을 표시할 것인지
        if (playOnAwake)
            ShowOutline();
        // 안할 것인지를 설정
        else
            HideOutline();

    }

    // 아웃라인을 표시하는 기능
    public void ShowOutline()
    {
        outline.OutlineColor = positiveColor;       //아웃라인 색상 설정
        outline.enabled = true;     //아웃라인 활성화
    }

    // 아웃라인을 숨기는 기능
    public void HideOutline()
    {
        outline.enabled = false;        //아웃라인 비활성화
    }

}
