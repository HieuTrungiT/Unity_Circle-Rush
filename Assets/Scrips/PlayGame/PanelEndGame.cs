using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelEndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTMP;
    public void SetScorePanel(float score)
    {
        scoreTMP.text = score.ToString("0");
    }
}
