using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
public class CheckPointManager : Singleton<CheckPointManager>
{
    public int lastChackPointKey = 0;
    public List<CheckpointBase> checkPoints;
    public bool HasCheckPoint()
    {
        return lastChackPointKey > 0;
    }
    public void SaveCheckPoint(int i)
    {
        if(lastChackPointKey < i)
        {
            lastChackPointKey = i;
        }
    }
    public Vector3 GetPositionToRespawn()
    {
        var checkpoint= checkPoints.Find(i => i.key == lastChackPointKey);
        return checkpoint.transform.position;
    }
}
