using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedByScore : MonoBehaviour
{
    Score score;
    PlayerManager Player;
    PointsManager Points;
    EnemysManager Enemys;
    float AverageSpeedPlayer;
    float AverageSpeedPoints;
    float AverageSpeedInstanPoints;
    float AverageSpeedEnemys;
    float AverageSpeedInstanEnemys;

    void Awake()
    {
        score = FindObjectOfType<Score>();
        Player = FindObjectOfType<PlayerManager>();
        Enemys = FindObjectOfType<EnemysManager>();
        Points = FindObjectOfType<PointsManager>();

        AverageSpeedInstanPoints = (Enemys.GetTimeInstantiateEnemys() / 40);
        AverageSpeedInstanEnemys =(Points.GetTimeInstantiatePoints() / 40);

    }


    public void SetUpSpeed()
    {
        if (score.GetScore() == (Points.GetPointScore() * 10))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 20))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 30))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 40))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 50))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 60))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 70))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 80))
        {
            SetStepUpSpeeds();
        }
        else if (score.GetScore() == (Points.GetPointScore() * 90))
        {
            SetStepUpSpeeds();
        }


    }
    void SetStepUpSpeeds()
    {
        GetAverageSpeeds();
        Player.SetSpeedPlayer(Player.GetSpeedPlayer() + AverageSpeedPlayer);

        Enemys.SetSpeedEnemys(Enemys.GetSpeedEnemys() + AverageSpeedEnemys);
        Enemys.SetTimeInstantiateEnemys(Enemys.GetTimeInstantiateEnemys() - AverageSpeedInstanEnemys);

        Points.SetSpeedPoints(Points.GetSpeedPoints() + AverageSpeedPoints);
        Points.SetTimeInstantiatePoints(Points.GetTimeInstantiatePoints() - AverageSpeedInstanPoints);
    }
    void GetAverageSpeeds()
    {
        AverageSpeedPlayer = ((Player.GetMaxSpeedPlayer() - Player.GetMinSpeedPlayer()) / 10);
        AverageSpeedPoints = ((Points.GetMaxSpeedPoints() - Points.GetMinSpeedPoints()) / 10);
        AverageSpeedEnemys = ((Enemys.GetMaxSpeedEnemys() - Enemys.GetMinSpeedEnemys()) / 10);

    }
}
