using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] float SpeedPoints;
    [SerializeField] float SpeedRotationPoints;
    [SerializeField] float MinSpeedPoints;
    [SerializeField] float MaxSpeedPoints;
    [SerializeField] float TimeInstantiatePoints;
    [SerializeField] float TimeOneTurnPoints;
    [SerializeField] float PointScore = 10f;
    public float GetSpeedPoints()
    {
        return SpeedPoints;
    }
    public void SetSpeedPoints(float newSpeedPoints)
    {
        SpeedPoints = newSpeedPoints;
    }
     public float GetSpeedRotationPoints()
    {
        return SpeedRotationPoints;
    }
    public void SetSpeedRotationPoints(float newSpeedRotationPoints)
    {
        SpeedRotationPoints = newSpeedRotationPoints;
    }

    public float GetMinSpeedPoints()
    {
        return MinSpeedPoints;
    }
    public float GetMaxSpeedPoints()
    {
        return MaxSpeedPoints;
    }
    public float GetTimeInstantiatePoints()
    {
        return TimeInstantiatePoints;
    }
    public void SetTimeInstantiatePoints(float newTimeInstaniate)
    {
        TimeInstantiatePoints = newTimeInstaniate;
    }
    public float GetTimeOneTurnPoints()
    {
        return TimeOneTurnPoints;
    }
    public void SetTimeOneTurnPoints(float newTimeOneTurnPoints)
    {
        TimeOneTurnPoints = newTimeOneTurnPoints;
    }
     public float GetPointScore()
    {
        return PointScore;
    }
    public void SetPointScore(float newPointScore)
    {
        PointScore = newPointScore;
    }
}
