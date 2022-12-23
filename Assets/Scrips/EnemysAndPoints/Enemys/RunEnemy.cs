using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemy : MonoBehaviour
{
    [SerializeField] GameObject SquareEnemy;
    [SerializeField] GameObject PlayerCircle;
    EnemysManager EnemyMgr;
    float SpeedEnemy;
    float RotateZ = 0f;
    void Awake()
    {
        EnemyMgr = FindObjectOfType<EnemysManager>();
    }
    void Update()
    {


        SpeedEnemy = EnemyMgr.GetSpeedEnemys();
        transform.Translate(0f, Random.Range(-SpeedEnemy - 0.02f, -SpeedEnemy + 0.02f) * Time.deltaTime, 0f);
    }
    public void SetInitPositionEnemy(float minBoundsX, float maxBoundsX)
    {
        // Set Positon
        float randomPstX = Random.Range(minBoundsX, maxBoundsX);
        transform.position = new Vector3(randomPstX, 7f, 0f);

        // Set Rotation
        var lookDir = (Vector2)transform.position - (Vector2)PlayerCircle.transform.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle - 180);

    }

    public GameObject GetGameObjectEnemy()
    {
        return SquareEnemy;
    }

}
