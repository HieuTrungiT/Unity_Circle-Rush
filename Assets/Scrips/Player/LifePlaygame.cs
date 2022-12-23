using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LifePlaygame : MonoBehaviour
{
    PlayerManager Player;
    PointsManager Points;
    SpeedByScore speedByScore;
    int Life;
    [SerializeField] GameObject EffectCircle;

    float point = 10f;
    [SerializeField] TextMeshProUGUI LifeTMP;
    [SerializeField] GameObject PanelEndGame;

    [Header("Audio Sounds")]
    [SerializeField] AudioClip EffectCollideEnemySFX;
    [SerializeField] AudioClip EffectCollidePointSFX;
    [SerializeField] AudioClip EffectCollideAfterSFX;
    [SerializeField] AudioClip EffectLifeSFX;

    ChangeColors changeColors;
    RunCirclePlayer runCircle;
    Score score;


    [Header("Frame")]
    public int frameRate = 60;
    void Awake()
    {
        Application.targetFrameRate = frameRate;
        score = FindObjectOfType<Score>();
        Points = FindObjectOfType<PointsManager>();
        Player = FindObjectOfType<PlayerManager>();
        runCircle = FindObjectOfType<RunCirclePlayer>();
        changeColors = FindObjectOfType<ChangeColors>();
        speedByScore = FindObjectOfType<SpeedByScore>();
        PanelEndGame.SetActive(false);
        Life = Player.GetLife();
    }

    void Update()
    {
        point = Points.GetPointScore();
        LifeTMP.text = "LIFE: " + Life.ToString("0");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<RotationEnemy>().PlayEffect();
            Player.SetLoseLife();
            if (Player.GetLife() <= 0)
            {
                GetComponent<AudioEffect>().PlayAudioEffect(EffectLifeSFX);
                EffectCircle.GetComponent<ParticleSystem>().Play();
                Player.SetSpeedPlayer(0f);
                transform.localScale = new Vector2(0f, 0f);
                StartCoroutine(ShowPanel());
            }
            StartCoroutine(ZoomOutGameObject(other.gameObject));
            GetComponent<AudioEffect>().PlayAudioEffect(EffectCollideEnemySFX);
            GetComponent<AudioEffect>().PlayAudioEffect(EffectCollideAfterSFX);
            Life = Player.GetLife();
        }
        else if (other.gameObject.tag == "Point")
        {
            speedByScore.SetUpSpeed();
            changeColors.OnChangeColorsGame();
            other.gameObject.GetComponent<RotationPoint>().PlayEffect();
            score.SetScore(point);
            GetComponent<AudioEffect>().PlayAudioEffect(EffectCollidePointSFX);
            GetComponent<AudioEffect>().PlayAudioEffect(EffectLifeSFX);
            StartCoroutine(ZoomOutGameObject(other.gameObject));
        }


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
    IEnumerator ShowPanel()
    {
        yield return new WaitForSeconds(1.5f);

        PanelEndGame.SetActive(true);
        PanelEndGame.GetComponent<PanelEndGame>().SetScorePanel(score.GetScore());
    }




}
