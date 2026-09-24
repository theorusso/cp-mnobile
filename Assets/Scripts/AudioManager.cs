using UnityEngine;

namespace AimTrainer
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [Header("Música de Fundo")]
        [SerializeField] private AudioClip backgroundMusic;
        [Range(0f, 1f)][SerializeField] private float musicVolume = 0.3f;

        private AudioSource musicSource;

        private void Awake()
        {
            musicSource = GetComponent<AudioSource>();
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.volume = musicVolume;
            musicSource.playOnAwake = true;
        }

        private void Start()
        {
            if (backgroundMusic != null && !musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }

        public void SetVolume(float volume)
        {
            musicVolume = Mathf.Clamp01(volume);
            if (musicSource != null)
            {
                musicSource.volume = musicVolume;
            }
        }
    }
}