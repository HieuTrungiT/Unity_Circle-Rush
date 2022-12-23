using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEnemy : MonoBehaviour
{
    [SerializeField] ParticleSystem EffectEnemy;

    EnemysManager EnemyMgr;
    float speedRotationEnemys;

    bool isRotation = true;
    void Awake()
    {
        EnemyMgr = FindObjectOfType<EnemysManager>();
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
        EffectEnemy.GetComponent<ParticleSystem>().Play();
    }
    void Update()
    {

        if (isRotation)
        {
            transform.Rotate(0f, 0f, EnemyMgr.GetSpeedRotationEnemys() * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, 0f, -EnemyMgr.GetSpeedRotationEnemys() * Time.deltaTime);
        }
    }

}
