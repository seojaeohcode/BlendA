using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    float Sec;
    int Min;
    public TextMeshProUGUI timeText;    
    
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sec += Time.deltaTime;
        timeText.text = string.Format("{0:D2}:{1:D2}", Min, (int)Sec);
        if ((int)Sec > 59)
        {
            Sec = 0;
            Min++;
        }
    }

    void Timer()
    {
        //Sec += Time.deltaTime;
        //textTimer.text = string.Format("{0:D2}:{1:D2}", Min, (int)Sec);
        //if((int)Sec > 59)
        //{
        //    Sec = 0;
        //    Min++;
        //}
    }

}
