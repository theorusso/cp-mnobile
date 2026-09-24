using UnityEngine;

namespace AimTrainer
{
    public class WeaponManager : MonoBehaviour
    {
        [Header("Referências")]
        [SerializeField] private Camera fpsCamera;
        [SerializeField] private Weapon[] weapons;

        private int selectedWeaponIndex = 0;

        private void Start()
        {
            SelectWeapon(0);
        }

        private void Update()
        {
            int previousSelected = selectedWeaponIndex;

            
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeaponIndex >= weapons.Length - 1)
                    selectedWeaponIndex = 0;
                else
                    selectedWeaponIndex++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeaponIndex <= 0)
                    selectedWeaponIndex = weapons.Length - 1;
                else
                    selectedWeaponIndex--;
            }

            
            if (Input.GetKeyDown(KeyCode.Alpha1) && weapons.Length >= 1) selectedWeaponIndex = 0;
            if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length >= 2) selectedWeaponIndex = 1;
            if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Length >= 3) selectedWeaponIndex = 2;

            if (previousSelected != selectedWeaponIndex)
            {
                SelectWeapon(selectedWeaponIndex);
            }

            
            if (Input.GetMouseButton(0) || Input.GetButton("Fire1"))
            {
                if (weapons != null && weapons.Length > selectedWeaponIndex && weapons[selectedWeaponIndex] != null)
                {
                    weapons[selectedWeaponIndex].TryShoot(fpsCamera);
                }
            }
        }

        private void SelectWeapon(int index)
        {
            if (weapons == null || weapons.Length == 0) return;

            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] != null)
                {
                    weapons[i].gameObject.SetActive(i == index);
                }
            }
        }
    }
}