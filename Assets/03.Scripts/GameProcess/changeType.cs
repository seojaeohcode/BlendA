using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeType : MonoBehaviour
{

    public List<GameObject> RecipeA = new List<GameObject>();
    public List<GameObject> RecipeB = new List<GameObject>();
    public List<GameObject> RecipeC = new List<GameObject>();
    public List<GameObject> RecipeD = new List<GameObject>();
    //드링크 타입 => 클래스 4개의 값 중 1개를 가지고 만약 잔이 비면 None으로.
    //실패할 경우는 None이 아니라 Fail로 처리
    public string DrinkType = "None";



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
