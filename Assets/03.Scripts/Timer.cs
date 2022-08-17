using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int startHour = 35;
    public int startMin = 0;
    public int startSec = 0;

    private int tempHour = 0;
    private int tempMin = 0;
    private int tempSec = 0;


    public Text timerText;

    private int totalSec = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalSec = (startHour * 60 * 60) + (startMin * 60) + startSec;
        StartCoroutine("countTime", 1);
    }

    IEnumerator countTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        totalSec -= 1;
        tempHour = totalSec / 3600;
        tempMin = (totalSec % 3600) / 60;
        tempSec = (totalSec % 3600) % 60;
        timerText.text = tempHour + ":" + tempMin + ":" + tempSec;

        if(totalSec > 0)
        {
            StartCoroutine("countTime", 1);
        }

    }
}
