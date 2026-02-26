using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip[] audioClips;

    public static SoundManager instance = null;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void PlaySFX(AudioClip clip, AudioSource source)
    {
        source.PlayOneShot(clip);
    }
}
