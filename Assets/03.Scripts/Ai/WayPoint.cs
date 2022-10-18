using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WayPoint : MonoBehaviour
{
    public static WayPoint instance = null;
    public List<Transform> wayPoints;

    public void Awake()
    {
        if (instance == null)
            instance = this;


        Init();
    }
    
    private void Init()
    {
        GetComponentsInChildren<Transform>(wayPoints);
        wayPoints.Remove(this.transform);
    }

    public bool isValid(int idx)
    {
        return (idx >= 0 && idx < wayPoints.Count);
    }

    public Vector3 GetPoint(int idx)
    {
        Assert.IsTrue(isValid(idx));
        return wayPoints[idx].position;
    }
}
