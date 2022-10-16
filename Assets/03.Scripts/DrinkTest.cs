using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkTest : MonoBehaviour
{
    List<string> ingr = new List<string>();
    List<string> mbase = new List<string>();
    List<string> recipe = new List<string>();
    void Start()
    {
        AddArgument();
    }

    // Update is called once per frame
    void Update()
    {
        Combine();
    }

    void AddArgument()
    {
        ingr.Add("a");
        ingr.Add("b");
        mbase.Add("c");
        mbase.Add("d");
        recipe.Add("e");
        recipe.Add("f");
    }

    void Combine() // 손의 콜라이더가 특정 콜라이더에 닿았을 시 지정한 리스트의 구성요소 호출
    {
        
    }

   
}
