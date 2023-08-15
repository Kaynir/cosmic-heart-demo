using Cinemachine;
using CosmicHeart.Weapons;
using UnityEngine;

namespace CosmicHeart.Characters
{
    public class Vehicle : MonoBehaviour
    {
        [SerializeField] private CharacterMotor motor = null;
        [SerializeField] private WeaponHolder weaponHolder = null;
        [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

        public bool IsDriving { get; private set; }

        private Transform driver;
        private Transform driverParent;

        public void Enter(Transform driver)
        {
            motor.enabled = true;
            weaponHolder.enabled = true;
            virtualCamera.enabled = true;

            this.driver = driver;
            driverParent = driver.parent;
            driver.gameObject.SetActive(false);
            driver.SetParent(transform);

            IsDriving = true;
        }

        public void Exit()
        {
            motor.enabled = false;
            weaponHolder.enabled = false;
            virtualCamera.enabled = false;
            
            driver.gameObject.SetActive(true);
            driver.SetParent(driverParent);
            driverParent = null;
            driver = null;

            IsDriving = false;
        }
    }
}