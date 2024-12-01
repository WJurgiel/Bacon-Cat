using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--Audio Source ----")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("--Audio Clip ----")]
    public AudioClip background;
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
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


}
