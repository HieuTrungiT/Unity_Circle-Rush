using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCirclePlayer : MonoBehaviour
{
    [SerializeField] GameObject CirclePlayer;
    PlayerManager Player;
    float speed = 5f;
    [SerializeField] Vector3 minTranlate;
    [SerializeField] Vector3 maxTranlate;
    [Header("Audio Sounds")]
    [SerializeField] AudioClip EffectTapSFX;
    [SerializeField] AudioClip EffectRunSFX;


    bool Loop = true;
    void Awake()
    {
        Player = FindObjectOfType<PlayerManager>();

    }
    void Update()
    {

        RunCircleLoop();
    }

    void RunCircleLoop()
    {
        speed = Player.GetSpeedPlayer();
        if (CirclePlayer.transform.position.x <= -1.8f)
        {
            Loop = true;
        }
        else if (CirclePlayer.transform.position.x >= 1.79f)
        {
            Loop = false;
        }

        if (Loop)
        {
            CirclePlayer.transform.Translate(speed * Time.deltaTime, 0, 0);

        }
        else
        {
            CirclePlayer.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

    }


    public void CheckComeBack()
    {
        CirclePlayer.GetComponent<AudioEffect>().PlayAudioEffect(EffectTapSFX);

        Loop = !Loop;
    }
}
