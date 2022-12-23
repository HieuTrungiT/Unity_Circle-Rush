using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstantiate : MonoBehaviour
{
    float timeDelayInstantiate;
    [Header("Enemys")]
    [SerializeField] List<GameObject> ListEnemys;
    float timeMinInstantiateEnemy;
    float timeMaxInstantiateEnemy;

    [Header("Points")]
    [SerializeField] List<GameObject> ListPoints;
    float timeMinInstantiatePoint;
    float timeMaxInstantiatePoint;
    PlayerManager Player;
    EnemysManager EnemysMgr;
    PointsManager PointsMgr;
    Vector3 spaseScale;
    Vector2 minBounds;
    Vector2 maxBounds;
    bool isLife = true;
    bool isLoop = true;

    void Awake()
    {
        Player = FindObjectOfType<PlayerManager>();
        EnemysMgr = FindObjectOfType<EnemysManager>();
        PointsMgr = FindObjectOfType<PointsManager>();
    }

    void Start()
    {
        InitBounds();
        StartCoroutine(DelayInstantiatePoints());
        StartCoroutine(DelayInstantiateEnemys());
    }
    IEnumerator DelayInstantiateEnemys()
    {
        yield return new WaitForSeconds(EnemysMgr.GetTimeOneTurnEnemys());
        StartCoroutine(NewPositonEnemys());
    }
    IEnumerator DelayInstantiatePoints()
    {
        yield return new WaitForSeconds(PointsMgr.GetTimeOneTurnPoints());
        StartCoroutine(NewPositonPoints());
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        timeMinInstantiatePoint = PointsMgr.GetTimeInstantiatePoints() - Random.Range(0.3f, 0.7f);
        timeMaxInstantiatePoint = PointsMgr.GetTimeInstantiatePoints();

        timeMinInstantiateEnemy = EnemysMgr.GetTimeInstantiateEnemys() - Random.Range(0.3f, 0.7f);
        timeMaxInstantiateEnemy = EnemysMgr.GetTimeInstantiateEnemys();
        CheckLife();
    }
    void CheckLife()
    {
        int life = Player.GetLife();
        if (life <= 0)
        {
            isLife = false;
            Stop();
        }
    }
    void Stop()
    {
        FindObjectOfType<EnemysManager>().SetSpeedEnemys(0f);
        FindObjectOfType<PointsManager>().SetSpeedPoints(0f);

        for (int i = 0; i < ListEnemys.Count; i++)
        {
            ListEnemys[i].transform.localScale = new Vector3(0f, 0f, 0f);
        }
        for (int i = 0; i < ListPoints.Count; i++)
        {
            ListPoints[i].transform.localScale = new Vector3(0f, 0f, 0f);
        }
    }


    IEnumerator NewPositonEnemys()
    {
        while (isLife)
        {
            for (int i = 0; i < ListEnemys.Count; i++)
            {
                // StartCoroutine(ZoomOutGameObject(ListEnemys[i]));
                ListEnemys[i].transform.localScale = new Vector2(0.3f, 0.3f);
                ListEnemys[i].GetComponent<RunEnemy>().GetGameObjectEnemy().transform.localScale = new Vector2(1.3f, 1.3f);
                ListEnemys[i].GetComponent<RunEnemy>().SetInitPositionEnemy(minBounds.x, maxBounds.x);
                yield return new WaitForSeconds(Random.Range(timeMinInstantiateEnemy, timeMaxInstantiateEnemy));
            }
        }
    }
    IEnumerator NewPositonPoints()
    {
        while (isLife)
        {
            for (int i = 0; i < ListPoints.Count; i++)
            {
                // StartCoroutine(ZoomOutGameObject(ListPoints[i]));
                ListPoints[i].transform.localScale = new Vector2(0.3f, 0.3f);
                ListPoints[i].GetComponent<RunPoint>().GetGameObjectPoint().transform.localScale = new Vector2(1.3f, 1.3f);
                ListPoints[i].GetComponent<RunPoint>().SetInitPositionPoint(minBounds.x, maxBounds.x);
                yield return new WaitForSeconds(Random.Range(timeMinInstantiatePoint, timeMaxInstantiatePoint));
            }
        }
    }

    public List<GameObject> GetEnemys()
    {
        return ListEnemys;
    }
    public List<GameObject> GetPoints()
    {
        return ListPoints;
    }
        IEnumerator ZoomOutGameObject(GameObject gameObjectTemb)
    {
        float ratioScaleX = gameObjectTemb.transform.localScale.x;
        float ratioScaleY = gameObjectTemb.transform.localScale.x;
        bool isLoop = true;
        while (isLoop)
        {
            yield return new WaitForSeconds(0.001f);
            gameObjectTemb.transform.localScale = new Vector3(ratioScaleX -= 0.1f, ratioScaleY -= 0.1f, 0f);
            if (gameObjectTemb.transform.localScale.x <= 0.00f) { isLoop = false; }
        }
    }
}
