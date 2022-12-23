using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    public void PlayAudioEffect(AudioClip clipSoundSFX)
    {
        GetComponent<AudioSource>().PlayOneShot(clipSoundSFX);
    }
}
