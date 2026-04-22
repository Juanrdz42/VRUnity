using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource; // 👈 NUEVO

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFXAtPosition(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
    }


    public void PlayMusic(AudioClip music)
    {
        if (musicSource.clip == music && musicSource.isPlaying) return;

        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}