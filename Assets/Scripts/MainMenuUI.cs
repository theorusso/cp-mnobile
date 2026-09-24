using UnityEngine;
using UnityEngine.UI;

namespace AimTrainer
{
    public class MainMenuUI : MonoBehaviour
    {
        [Header("Painéis da UI")]
        [SerializeField] private GameObject startMenuPanel;
        [SerializeField] private Button startButton;

        [Header("Componentes de Gameplay para Ativar")]
        [SerializeField] private TargetSpawner spawner;
        [SerializeField] private FPSLook mouseLook;
        [SerializeField] private FPSMovement playerMovement;
        [SerializeField] private WeaponManager weaponManager;

        private void Start()
        {
            ShowMenu();

            if (startButton != null)
            {
                startButton.onClick.AddListener(StartGame);
            }
        }

        public void ShowMenu()
        {
            
            if (startMenuPanel != null) startMenuPanel.SetActive(true);

            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

           
            if (spawner != null) spawner.enabled = false;
            if (mouseLook != null) mouseLook.enabled = false;
            if (playerMovement != null) playerMovement.enabled = false;
            if (weaponManager != null) weaponManager.enabled = false;
        }

        public void StartGame()
        {
            
            if (startMenuPanel != null) startMenuPanel.SetActive(false);

            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            
            if (spawner != null) spawner.enabled = true;
            if (mouseLook != null) mouseLook.enabled = true;
            if (playerMovement != null) playerMovement.enabled = true;
            if (weaponManager != null) weaponManager.enabled = true;
        }
    }
}