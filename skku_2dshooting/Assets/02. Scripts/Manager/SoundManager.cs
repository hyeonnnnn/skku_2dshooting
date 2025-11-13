using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    public enum Bgm
    {
        BGM_GAME,
    }

    public enum Sfx
    {
        BULLET,
        ENEMYEXPLOSION,
        ITEMPICKUP,
        UITIMATESKILL,
        GAMEOVER,
    }

    [SerializeField] private AudioClip[] bgms;
    [SerializeField] private AudioClip[] sfxs;

    [SerializeField] private AudioSource audioBgm;
    [SerializeField] private AudioSource audioSfx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(Bgm bgmIndex)
    {
        audioBgm.clip = bgms[(int)bgmIndex];
        audioBgm.Play();
    }

    public void StopBGM()
    {
        audioBgm.Stop();
    }

    public void PlaySFX(Sfx sfxIndex)
    {
        audioSfx.PlayOneShot(sfxs[(int)sfxIndex]);
    }
}
