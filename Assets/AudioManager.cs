using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundFX
{
    LASER_SHOOT,
    PAPER_UP,
    PAPER_DOWN,
    QUEST_WIN,
    DEATH_BELL,
    PAPER_STOP_DRAG,
    NEW_QUEST,
    CORRUPTION,
    KNIFE
}

public class AudioManager : MonoBehaviour
{
    public AudioClip laserShoot;
    public AudioClip paperUp;
    public AudioClip paperDown;
    public AudioClip questWin;
    public AudioClip deathBell;
    public AudioClip paperStopDrag;
    public AudioClip newQuest;
    public AudioClip corruption;
    public AudioClip knife;


    private AudioSource source;
    public static AudioManager Instance;

    void Awake()
    {
        AudioManager.Instance = this;
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(SoundFX sound)
    {
        switch (sound)
        {
            case SoundFX.LASER_SHOOT:
                source.PlayOneShot(laserShoot);
                break;

            case SoundFX.PAPER_UP:
                source.PlayOneShot(paperUp);
                break;

            case SoundFX.PAPER_DOWN:
                source.PlayOneShot(paperDown);
                break;

            case SoundFX.QUEST_WIN:
                source.PlayOneShot(questWin);
                break;

            case SoundFX.DEATH_BELL:
                source.PlayOneShot(deathBell);
                break;

            case SoundFX.PAPER_STOP_DRAG:
                source.PlayOneShot(paperStopDrag);
                break;
            case SoundFX.NEW_QUEST:
                source.PlayOneShot(newQuest);
                break;
            case SoundFX.CORRUPTION:
                source.PlayOneShot(corruption);
                break;

            case SoundFX.KNIFE:
                source.PlayOneShot(knife);
                break;

            default:
                break;
        }
    }
}
