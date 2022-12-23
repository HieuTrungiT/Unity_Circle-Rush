using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPoint : MonoBehaviour
{
    PointsManager PointMgr;
    float SpeedPoints;
    float RotateZ = 0f;
    [SerializeField] GameObject SquarePlayer;
    [SerializeField] GameObject OjGMessenger;
    void Awake()
    {
        PointMgr = FindObjectOfType<PointsManager>();
    }
    void Update()
    {
        SpeedPoints = PointMgr.GetSpeedPoints();
        transform.Translate(0f, Random.Range(-SpeedPoints - 0.02f, -SpeedPoints + 0.02f) * Time.deltaTime, 0f);
    }

    public void SetInitPositionPoint(float minBoundsX, float maxBoundsX)
    {
        float randomPstX = Random.Range(minBoundsX, maxBoundsX);
        if (randomPstX >= (maxBoundsX / 2))
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-10, -40));
        }
        else if (randomPstX <= (maxBoundsX / 2) && randomPstX >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, -30));
        }
        else if (randomPstX <= (minBoundsX / 2))
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(10, 40));
        }
        else if (randomPstX >= (minBoundsX / 2) && (randomPstX <= 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 30));
        }
        transform.position = new Vector3(randomPstX, 7f, 0f);

    }


    public GameObject GetGameObjectMessenger()
    {
        return OjGMessenger;
    }
    public GameObject GetGameObjectPoint()
    {
        return SquarePlayer;
    }

}
