using UnityEngine;

namespace AimTrainer
{
    [RequireComponent(typeof(AudioSource))]
    public class Weapon : MonoBehaviour
    {
        [Header("Atributos da Arma")]
        [SerializeField] private string weaponName = "Pistola";
        [SerializeField] private float range = 100f;
        [SerializeField] private float fireRate = 0.2f;

        [Header("Efeitos Visuais e Sonoros")]
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private GameObject impactEffectPrefab;
        [SerializeField] private AudioClip shootSound;

        private AudioSource audioSource;
        private float nextTimeToFire = 0f;

        public string WeaponName => weaponName;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void TryShoot(Camera fpsCamera)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + fireRate;
                Shoot(fpsCamera);
            }
        }

        private void Shoot(Camera fpsCamera)
        {
            Debug.Log($"[TIRO] A arma '{weaponName}' disparou!");

            if (muzzleFlash != null)
            {
                muzzleFlash.Play();
            }

            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }

            if (fpsCamera == null) return;

            RaycastHit hit;

            
            int layerMask = ~LayerMask.GetMask("Ignore Raycast");

            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range, layerMask))
            {
                Debug.DrawLine(fpsCamera.transform.position, hit.point, Color.red, 0.5f);
                Debug.Log($"[COLISÃO] O tiro atingiu: {hit.transform.name}");

                if (impactEffectPrefab != null)
                {
                    GameObject impactObj = Instantiate(impactEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactObj, 1f);
                }

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.Hit();
                }
            }
            else
            {
                Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * range, Color.yellow, 0.5f);
            }
        }
    }
}