using UnityEngine;

public class AudioManagerTutorial : MonoBehaviour
{
    [Header("--Audio Source ----")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("--Audio Clip ----")]
    public AudioClip background;
    public AudioClip backgroundLvl1;
    public AudioClip backgroundLvl2;
    public AudioClip bossMusic;
    public AudioClip pickup;
    public AudioClip healingPickup;
    public AudioClip update;
    public AudioClip enemySound;
    public AudioClip flyingSound;
    public AudioClip buttonError;
    public AudioClip menuClick;
    public AudioClip gameStart;
    public AudioClip laughter;
    public AudioClip falling;
    public AudioClip fireplace;
    public AudioClip killedBoss;

    private void Start()
    {
        musicSource.clip = backgroundLvl1;
        if (musicSource != null)
        {
            musicSource.loop = true; // Ustaw zapętlanie
            musicSource.Play(); // Odtwórz dźwięk
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayLoopedSound()
    {
       
    }

}
