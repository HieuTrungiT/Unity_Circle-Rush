using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] Color[] ColorsBackground;
    [SerializeField] Color[] ColorsPlayer;
    [SerializeField] Color[] ColorsTrack;
    [SerializeField] Color[] ColorsEnemys;
    [SerializeField] Color[] ColorsPoints;


    // Backgrounds
    public Color GetColorBackground(int index)
    {
        return ColorsBackground[index];
    }
    public int GetLenghtColorBackground()
    {
        return ColorsBackground.Length;
    }

    // Player
    public Color GetColorPlayer(int index)
    {
        return ColorsPlayer[index];
    }
    public int GetLenghtColorPlayer()
    {
        return ColorsPlayer.Length;
    }
    //  Track
    public Color GetColorTrack(int index)
    {
        return ColorsTrack[index];
    }
    public int GetLenghtColorTrack()
    {
        return ColorsTrack.Length;
    }
    // Enemys
    public Color GetColorEnemy(int index)
    {
        return ColorsEnemys[index];
    }
    public int GetLenghtColorEnemys()
    {
        return ColorsEnemys.Length;
    }
    // Points
    public Color GetColorPoints(int index)
    {
        return ColorsPoints[index];
    }
    public int GetLenghtColorPoints()
    {
        return ColorsPoints.Length;
    }

}
