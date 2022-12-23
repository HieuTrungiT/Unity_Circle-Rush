using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject AudioEffect;
    [SerializeField] AudioClip EffectBTNReloadScene;


    public void ReloadGameScene()
    {
        AudioEffect.GetComponent<AudioEffect>().PlayAudioEffect(EffectBTNReloadScene);
        StartCoroutine(ReloadScene());
    }
    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(0);
    }
}
