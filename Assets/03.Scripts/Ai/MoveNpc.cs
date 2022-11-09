using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoveNpc : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject target;
    public GameObject out_target;
    public Animator animator;
    public TextMeshProUGUI npc_ui;
    public bool IsSit = false;
    string[] QueryList = new string[] { "음...달콤한게 좋겠어요!", "부드럽고 과일향이 나는 양주가 좋겠네요!","부드러운 양주에 달콤한것을 섞어주세요!",
        "양주인데... 주스 맛도 났어요!","오렌지가 올라갔고 부드러운 양주와 주스맛이 났던거같아요!","부드러운 양주에 달콤한것을 섞고 라임을 올려주세요!",
    "달콤한주스에 라임을 올려주세요!","아주 센술을 먹고싶어요!","오렌지가 올라간 아주 센 술을 먹고싶어요!",
    "저는 아주 깨끗한 색의 술을 좋아해요!","새콤달콤한 과일과 부드러운 양주를 좋아해아요","그 술은...아주 신맛의 과일과 부드러운 양주맛이 났어요!",
    "저는 술을 안좋아하고 새콤달콤한 과일과 주스가 좋아요","그 술은 아주 쓴데도 깔끔해서 좋더라구요!!","아마... 체리가 있던 부드러운 양주일거에요!",
    };
    
    string[] CorrectList = new string[] { "OrangeJuice", "Jack","JackJuice"
    ,"JackJuice","OrangeJackJuice","LimeJackJuice",
    "LimeJuice","JackVodka","OrangeJackVodka",
    "Vodka","CherryJack","LimeJack",
    "CherryJuice","Vodka","CherryJack",};

    int QueryIndex = -1;
    public string collect = "";
    public GameObject glass;
    public bool Go_Out = true;
    public bool isCheck = true;

    void Start()
    {
        
        glass.GetComponent<DrinkProcess>().DrinkType = "None"; 
        npc_ui.text = "기다리세요..";
        out_target.SetActive(false);
    }

    void Update()
    {
        if (IsSit==false && Go_Out)
        {
            MoveToTarget();
        }
        else if (IsSit == true && Go_Out)
        {
            Invoke("MoveToOut", 3f);
        }

        if (IsSit && (QueryIndex==-1))
        {
            
            QueryIndex = ((int)Random.Range(0f, 12f));
            npc_ui.text = QueryList[QueryIndex];
            collect = CorrectList[QueryIndex];
            Debug.Log(collect);
        }

        if(glass.GetComponent<DrinkProcess>().DrinkType != "None" && isCheck==false)
        {
            string submit = glass.GetComponent<DrinkProcess>().DrinkType;
            Debug.Log(submit);
            if (submit == collect)
            {
                Debug.Log("정답컴인");
                npc_ui.text = "정답입니다!";
                //glass.GetComponent<DrinkProcess>().DrinkType = "None";
                Go_Out = true;
                isCheck = true;
            }
            else
            {
                npc_ui.text = "실패...";
                //glass.GetComponent<DrinkProcess>().DrinkType = "None";
                Go_Out = true;
                isCheck = true;
            }
        }
    }

    void MoveToTarget()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        if (target.transform.position != Vector3.MoveTowards(transform.position, target.transform.position, 1f))
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 6f * Time.deltaTime); // 현위치, 도착점, 속도
        }
    }
    void MoveToOut()
    {
        glass.GetComponent<DrinkProcess>().DrinkType = "None";
        for (int i = 0; i < 4; i++)
        {
            glass.GetComponent<DrinkProcess>().Element[i] = null;
        }
        animator.SetBool("sitting", false);
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (out_target.transform.position != Vector3.MoveTowards(transform.position, out_target.transform.position, 1f))
        {
            //Debug.Log("움직임.");
            transform.position = Vector3.MoveTowards(transform.position, out_target.transform.position, 6f * Time.deltaTime); // 현위치, 도착점, 속도
        }
        npc_ui.text = "다음차례...";
    }
    void setChair()
    {
        target.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chair"))
        {
            Go_Out = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("sitting", true);
            target.SetActive(false);
            IsSit = true;
            out_target.SetActive(true);
            isCheck = false;
        }
        else if (other.gameObject.CompareTag("OutPos"))
        {
            IsSit = false;
            Invoke("setChair", 0.5f);
            QueryIndex = -1;
            out_target.SetActive(false);
            GameManager.GetComponent<GameManager>().IsMan = !(GameManager.GetComponent<GameManager>().IsMan);
            isCheck = false;
        }
    }
}
    
