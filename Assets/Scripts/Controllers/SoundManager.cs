using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundManager : MonoBehaviour
{
    [Inject]
    private GameConfig gameConfig;

    [SerializeField] private AudioSource sfx_hit;
    [SerializeField] private AudioSource sfx_wing;
    [SerializeField] private AudioSource sfx_point;

#if UNITY_EDITOR
    void OnValidate()
    {
        sfx_hit = transform.Find("sfx_hit").GetComponent<AudioSource>();
        sfx_wing = transform.Find("sfx_wing").GetComponent<AudioSource>();
        sfx_point = transform.Find("sfx_point").GetComponent<AudioSource>();
    }
#endif

    private void Awake()
    {
        SetSound();
    }

    public void SetSound()
    {
        if (gameConfig.soundOn)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0f;
    }

    public void PlayHit()
    {
        sfx_hit.Play();
    }

    public void PlayWing()
    {
        sfx_wing.Play();
    }

    public void PlayPoint()
    {
        sfx_point.Play();
    }

}
