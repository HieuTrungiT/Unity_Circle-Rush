using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPoint : MonoBehaviour
{
    PointsManager PointMgr;
    [SerializeField] ParticleSystem EffectPoint;

    float speedRotationPoints;
    bool isRotation = true;
    private void Awake()
    {
        PointMgr = FindObjectOfType<PointsManager>();
    }
    void Start()
    {
        if (Random.Range(0, 2) == 1)
        {
            isRotation = false;
        }
    }
    public void PlayEffect()
    {
        EffectPoint.GetComponent<ParticleSystem>().Play();
    }
    void Update()
    {
        speedRotationPoints = PointMgr.GetSpeedRotationPoints();
        if (isRotation)
        {
            transform.Rotate(0f, 0f, speedRotationPoints * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, 0f, -speedRotationPoints * Time.deltaTime);
        }
    }

}
