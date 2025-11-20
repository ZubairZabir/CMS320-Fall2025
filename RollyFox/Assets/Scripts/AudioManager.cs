using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource; // for background music
    [SerializeField] private AudioSource sfxSource;   // for sound effects

    [Header("Clips")]
    public AudioClip backgroundMusic;
    public AudioClip stumbleSound; // hurt sound
    public AudioClip gameOverMusic;

    private void Awake()
    {
        // Optional: keep this across scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Don't auto-play background music - it will start when Play() is called
        StopAllMusic();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void StartBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            // Cancel any pending music stops
            CancelInvoke(nameof(StopAllMusic));
            
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayGameOverMusic()
    {
        if (gameOverMusic != null && musicSource != null)
        {
            // Cancel any pending music stops
            CancelInvoke(nameof(StopAllMusic));
            
            musicSource.clip = gameOverMusic;
            musicSource.loop = false;
            musicSource.Play();
            
            // Stop all music after game over music finishes
            Invoke(nameof(StopAllMusic), gameOverMusic.length);
        }
    }

    public void StopAllMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
