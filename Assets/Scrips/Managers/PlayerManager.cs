using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] int Life;
    [SerializeField] float SpeedPlayer;
    [SerializeField] float MinSpeedPlayer;
    [SerializeField] float MaxSpeedPlayer;

    public int GetLife()
    {
        return Life;
    }
    public void SetLoseLife(){
      Life -= 1;
    }
    public float GetSpeedPlayer()
    {
        return SpeedPlayer;
    }
    public void SetSpeedPlayer(float newSpeed)
    {
        SpeedPlayer = newSpeed;
    }
    public float GetMinSpeedPlayer()
    {
        return MinSpeedPlayer;
    }
    public float GetMaxSpeedPlayer()
    {
        return MaxSpeedPlayer;
    }
}
