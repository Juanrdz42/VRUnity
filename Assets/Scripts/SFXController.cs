using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFXAtPosition(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
    }


}
