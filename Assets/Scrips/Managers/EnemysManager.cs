using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{

    [Header("Enemys")]
    [SerializeField] float SpeedEnemys;
    [SerializeField] float SpeedRotationEnemys;
    [SerializeField] float MinSpeedEnemys;
    [SerializeField] float MaxSpeedEnemys;
    [SerializeField] float TimeInstantiateEnemys;
    [SerializeField] float TimeOneTurnEnemys;


    public float GetSpeedEnemys()
    {
        return SpeedEnemys;
    }
    public void SetSpeedEnemys(float newSpeed)
    {
        SpeedEnemys = newSpeed;
    }
    public float GetSpeedRotationEnemys()
    {
        return SpeedRotationEnemys;
    }
    public void SetSpeedRotationEnemys(float newSpeedRotationEnemys)
    {
        SpeedRotationEnemys = newSpeedRotationEnemys;
    }

    public float GetMinSpeedEnemys()
    {
        return MinSpeedEnemys;
    }

    public float GetMaxSpeedEnemys()
    {
        return MaxSpeedEnemys;
    }

    public float GetTimeInstantiateEnemys()
    {
        return TimeInstantiateEnemys;
    }
    public void SetTimeInstantiateEnemys(float newTimeInstantiateEnemys)
    {
        TimeInstantiateEnemys = newTimeInstantiateEnemys;
    }
    public float GetTimeOneTurnEnemys()
    {
        return TimeOneTurnEnemys;
    }
    public void SetTimeOneTurnEnemys(float newTimeOneTurnEnemys)
    {
        TimeOneTurnEnemys = newTimeOneTurnEnemys;
    }


}
