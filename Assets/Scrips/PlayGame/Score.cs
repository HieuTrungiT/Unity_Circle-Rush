using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreTMP;

    float score;

    void Update()
    {
        ScoreTMP.text = score.ToString("0");
    }
    public void SetScore(float scorePush)
    {
        score += scorePush;
    }
    public float GetScore()
    {
        return score;
    }
}
