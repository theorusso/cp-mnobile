using UnityEngine;

namespace AimTrainer
{
    public class TargetFactory : MonoBehaviour
    {
        [Header("Prefabs dos Alvos (Atribuir no Inspector)")]
        [SerializeField] private GameObject normalTargetPrefab;
        [SerializeField] private GameObject fastTargetPrefab;
        [SerializeField] private GameObject bonusTargetPrefab;

      
        public GameObject CreateTarget(TargetType type, Vector3 spawnPosition)
        {
            GameObject prefabToInstantiate = null;

            switch (type)
            {
                case TargetType.Normal:
                    prefabToInstantiate = normalTargetPrefab;
                    break;
                case TargetType.Fast:
                    prefabToInstantiate = fastTargetPrefab;
                    break;
                case TargetType.Bonus:
                    prefabToInstantiate = bonusTargetPrefab;
                    break;
                default:
                    prefabToInstantiate = normalTargetPrefab;
                    break;
            }

            if (prefabToInstantiate == null)
            {
                Debug.LogError($"Prefab para o tipo {type} não foi atribuído no TargetFactory!");
                return null;
            }

            return Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
        }
    }
}