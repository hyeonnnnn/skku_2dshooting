using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public enum EBgm
    {
        BGM_GAME,
    }

    public enum ESfx
    {
        SFX_BULLET,
        SFX_ENEMYEXPLOSION,
        SFX_ITEMPICKUP,
        SFX_UlTIMATESKILL,
        SFX_GAMEOVER,
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

    public void PlayBGM(EBgm bgmIndex)
    {
        audioBgm.clip = bgms[(int)bgmIndex];
        audioBgm.Play();
    }

    public void StopBGM()
    {
        audioBgm.Stop();
    }

    public void PlaySFX(ESfx sfxIndex)
    {
        audioSfx.PlayOneShot(sfxs[(int)sfxIndex]);
    }

}
