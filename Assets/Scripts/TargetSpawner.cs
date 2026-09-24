using UnityEngine;

namespace AimTrainer
{
    public class TargetSpawner : MonoBehaviour
    {
        [Header("Dependências")]
        [SerializeField] private TargetFactory factory;

        [Header("Pontos de Spawn")]
        [SerializeField] private Transform[] spawnPoints;

        [Header("Configurações do Spawner")]
        [SerializeField] private float spawnInterval = 1.5f;

        private float timer = 0f;

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnRandomTarget();
            }
        }

        private void SpawnRandomTarget()
        {
            if (factory == null)
            {
                Debug.LogWarning("TargetFactory não atribuída no TargetSpawner!");
                return;
            }

            if (spawnPoints == null || spawnPoints.Length == 0)
            {
                Debug.LogWarning("Nenhum SpawnPoint configurado no TargetSpawner!");
                return;
            }

            int randomPointIndex = Random.Range(0, spawnPoints.Length);
            Transform chosenPoint = spawnPoints[randomPointIndex];

            
            TargetType randomType = (TargetType)Random.Range(0, 3);

            
            factory.CreateTarget(randomType, chosenPoint.position);
        }
    }
}