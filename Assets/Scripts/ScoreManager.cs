using UnityEngine;
using TMPro;

namespace AimTrainer
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Referência da UI")]
        [SerializeField] private TextMeshProUGUI scoreText;

        private int currentScore = 0;

        private void OnEnable()
        {
            
            Target.OnTargetDestroyed += AddScore;
        }

        private void OnDisable()
        {
            
            Target.OnTargetDestroyed -= AddScore;
        }

        private void Start()
        {
            UpdateUI();
        }

        private void AddScore(int points)
        {
            currentScore += points;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (scoreText != null)
            {
                scoreText.text = $"Pontuação: {currentScore}";
            }
        }
    }
}