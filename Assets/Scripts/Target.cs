using System;
using UnityEngine;

namespace AimTrainer
{
    public class Target : MonoBehaviour
    {
        
        public static event Action<int> OnTargetDestroyed;

        [Header("Configurações do Alvo")]
        [SerializeField] private int scoreValue = 10;
        [SerializeField] private float lifetime = 5f;

        private void Start()
        {
            
            Destroy(gameObject, lifetime);
        }

       
        public void Hit()
        {
          
            OnTargetDestroyed?.Invoke(scoreValue);

            
            Destroy(gameObject);
        }
    }
}