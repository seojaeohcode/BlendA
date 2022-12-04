using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetComment : MonoBehaviour
{
    public TextMeshProUGUI OrderText;
    public TextMeshProUGUI BringText;
    void Start()
    {
        //GameObject.Find("Android 25_URP").GetComponent<MoveNpc>().npc_ui.text = BringText;
    }

    
    void Update()
    {
        GameObject.Find("Android 25_URP").GetComponent<MoveNpc>().npc_ui.text = BringText.text;
        OrderText.text = BringText.text;
        
        //GetOrder();
    }

    //void GetOrder()
    //{
    //    OrderText.text = BringText;
    //}
}
