using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrinkProcess : MonoBehaviour
{
    // 쉐이더 접근 변수
    float a;
    public GameObject glass;
    //Renderer glassR = glass.GetComponent<Renderer>();
    //Renderer glassTR = glass.transform.GetComponent<Renderer>();

    public GameObject[] FruitList = new GameObject[3];
    //public GameObject[] AlcoholList = new GameObject[2];
    //public GameObject[] NonAlcoholList = new GameObject[2];

    public GameObject FruitPoint;
    public string DrinkType = "None";

    //public string DrinkType = "None";
    
    //술에 담은 내용물 이걸 가지고 if문에서 판단.
    //0:술 1:주스 2:과일 4:추가 술
    public GameObject[] Element = new GameObject[4];

    public GameObject[] OrangeJuice = new GameObject[4];
    public GameObject[] Jack = new GameObject[4];
    public GameObject[] Vodka = new GameObject[4];
    public GameObject[] JackJuice = new GameObject[4];
    public GameObject[] JackVodka = new GameObject[4];
    public GameObject[] OrangeJackJuice = new GameObject[4];
    public GameObject[] OrangeJackVodka = new GameObject[4];
    public GameObject[] LimeJack = new GameObject[4];
    public GameObject[] LimeJackJuice = new GameObject[4];
    public GameObject[] LimeJuice = new GameObject[4];
    public GameObject[] CherryJack = new GameObject[4];
    public GameObject[] CherryJuice = new GameObject[4];

    public Vector3 nowPosition;


    // Start is called before the first frame update
    private void Awake()
    {
        nowPosition = this.transform.position;
    }
    void Start()
    {
        for(int i=0; i<4; i++)
        {
            Element[i] = null;
        }

        //쉐이더 접근
        Renderer glassR = glass.GetComponent<Renderer>();
        Renderer glassTR = glass.transform.GetComponent<Renderer>();
        glassR.material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        a = glassTR.material.GetFloat("_FillAmount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Element 내부 원소에 null이 있으면 스크립트 비활성
        //if (collision.collider.gameObject.CompareTag("Complete"))
        //{
        //    if (Element[0] == null)
        //    {
        //        Debug.Log("0번 비엇음");
        //    }
        //    if (Element[1] == null)
        //    {
        //        Debug.Log("1번 비엇음");
        //    }
        //    if (Element[2] == null)
        //    {
        //        Debug.Log("2번 비엇음");
        //    }
        //    //완성품 비교
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (Element[i] != null)
        //        {
        //            if (Element.SequenceEqual(HighBall) == true)
        //            {
        //                Debug.Log("하이볼 정답");
        //                DrinkType = "HighBall";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];


        //            }
        //            else if (Element.SequenceEqual(ScrewDriver) == true)
        //            {
        //                Debug.Log("스크류드라이버 정답");
        //                DrinkType = "ScrewDriver";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];
        //            }
        //            else
        //            {
        //                Debug.Log("실패");
        //                DrinkType = "Fail";
        //            }
        //        }
        //    }

        //}
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

        //완성품 비교------------------------------------------------------------------------
        if (other.gameObject.CompareTag("Complete"))
        {
            Debug.Log("컴플리트");
            /*
            if (Element[0] == null)
            {
                Debug.Log("0번 비엇음");
            }
            if (Element[1] == null)
            {
                Debug.Log("1번 비엇음");
            }
            if (Element[2] == null)
            {
                Debug.Log("3번 비엇음");
            }
            */
            /*
            for (int i = 0; i < 3; i++)
            {
                if (Element[i] != null)
                {
                    if (Element.SequenceEqual(HighBall) == true)
                    {
                        Debug.Log("하이볼 정답");
                        DrinkType = "HighBall";
                        this.transform.position = nowPosition;
                        Element = new GameObject[3];
                    }                   
                    else if (Element.SequenceEqual(ScrewDriver) == true)
                    {
                        Debug.Log("스크류드라이버 정답");
                        DrinkType = "ScrewDriver";
                        this.transform.position = nowPosition;
                        Element = new GameObject[3];
                    }
                    else
                    {
                        Debug.Log("실패");
                        DrinkType = "Fail";
                    }
                }
            }
            */
            if (Element.SequenceEqual(OrangeJuice) == true)
            {
                
                DrinkType = "OrangeJuice";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);

            }           
            else if (Element.SequenceEqual(Jack) == true)
            {
                
                DrinkType = "Jack";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(Vodka) == true)
            {

                DrinkType = "Vodka";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(JackJuice) == true)
            {

                DrinkType = "JackJuice";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(JackVodka) == true)
            {

                DrinkType = "JackVodka";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 3; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(OrangeJackJuice) == true)
            {

                DrinkType = "OrangeJackJuice";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(OrangeJackVodka) == true)
            {

                DrinkType = "OrangeJackVodka";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(LimeJack) == true)
            {

                DrinkType = "LimeJack";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(LimeJackJuice) == true)
            {

                DrinkType = "LimeJackJuice";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(LimeJuice) == true)
            {

                DrinkType = "LimeJuice";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(CherryJack) == true)
            {

                DrinkType = "CherryJack";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else if (Element.SequenceEqual(CherryJuice) == true)
            {

                DrinkType = "CherryJuice";
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
            else
            {
                Debug.Log("실패");
                DrinkType = "Fail";
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
            }
        }
        //----------------------------------------------------------------

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
        //레몬 추가시 사용
        //else if (other.gameObject.CompareTag("Lemon"))
        //{
        //    Debug.Log("레몬충돌");
        //    if (Element[2] == null)
        //    {
        //        Element[2] = FruitList[3];
        //        GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
        //        temp.transform.SetParent(FruitPoint.transform);
        //    }
        //}

        //Element 내부 원소에 null이 있으면 스크립트 비활성
        //if (other.gameObject.CompareTag("Complete"))
        //{
        //    if (Element[0] == null)
        //    {
        //        Debug.Log("0번 비엇음");
        //    }
        //    else if (Element[1] == null)
        //    {
        //        Debug.Log("1번 비엇음");
        //    }
        //    else if (Element[2] == null)
        //    {
        //        Debug.Log("3번 비엇음");
        //    }
        //    //완성품 비교
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (Element[i] != null)
        //        {
        //            if (Element.SequenceEqual(HighBall) == true)
        //            {
        //                Debug.Log("하이볼 정답");
        //                DrinkType = "HighBall";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];


        //            }
        //            else if (Element.SequenceEqual(ScrewDriver) == true)
        //            {
        //                Debug.Log("스크류드라이버 정답");
        //                DrinkType = "ScrewDriver";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];
        //            }
        //            else
        //            {
        //                Debug.Log("실패");
        //                DrinkType = "Fail";
        //            }
        //        }
        //    }

        //}

    }
    
    
}
