using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    ColorsManager colorsManager;
    public Camera mainCamera;
    public float duration = 0.5f;
    [SerializeField] GameObject Player;
    Renderer ColorPlayer;
    [SerializeField] GameObject Track;
    Renderer ColorTrack;
    RandomInstantiate randomInstantiate;
    Renderer ColorEnemys;
    [SerializeField] GameObject Points;
    Renderer ColorPoints;


     [SerializeField] int indexThisIndexColor = 0;
    void Awake()
    {
        colorsManager = FindObjectOfType<ColorsManager>();
        ColorPlayer = Player.GetComponent<Renderer>();
        ColorTrack = Track.GetComponent<Renderer>();
        randomInstantiate = FindObjectOfType<RandomInstantiate>();

    }
    void Update()
    {
        SetColor();
    }
    void SetColor()
    {
        mainCamera.backgroundColor =  colorsManager.GetColorBackground(indexThisIndexColor);
        ColorTrack.material.SetColor("_Color", colorsManager.GetColorTrack(indexThisIndexColor));
        SetColorArrayEnemys(randomInstantiate.GetEnemys());
        SetColorArrayPoints(randomInstantiate.GetPoints());
    }
    public void OnChangeColorsGame()
    {

        float t = Mathf.PingPong(Time.time, duration) / duration;

        mainCamera.backgroundColor = Color.Lerp(indexThisIndexColor == 0 ? colorsManager.GetColorBackground(indexThisIndexColor) : colorsManager.GetColorBackground(indexThisIndexColor - 1), colorsManager.GetColorBackground(indexThisIndexColor), t);


        ColorPlayer.material.SetColor("_Color", colorsManager.GetColorPlayer(indexThisIndexColor));
        ColorTrack.material.SetColor("_Color", colorsManager.GetColorTrack(indexThisIndexColor));
        SetColorArrayEnemys(randomInstantiate.GetEnemys());
        SetColorArrayPoints(randomInstantiate.GetPoints());
        if (indexThisIndexColor == colorsManager.GetLenghtColorBackground() - 1)
        {
            indexThisIndexColor = 0;
        }
        else
        {
            indexThisIndexColor += 1;
        }
    }
    void SetColorArrayEnemys(List<GameObject> listObject)
    {
        for (int i = 0; i < listObject.Count; i++)
        {
            listObject[i].GetComponent<RunEnemy>().GetGameObjectEnemy().GetComponent<Renderer>().material.SetColor("_Color", colorsManager.GetColorEnemy(indexThisIndexColor));
        }
    }
    void SetColorArrayPoints(List<GameObject> listObject)
    {
        for (int i = 0; i < listObject.Count; i++)
        {
            listObject[i].GetComponent<RunPoint>().GetGameObjectPoint().GetComponent<Renderer>().material.SetColor("_Color", colorsManager.GetColorPoints(indexThisIndexColor));
        }
    }
}
