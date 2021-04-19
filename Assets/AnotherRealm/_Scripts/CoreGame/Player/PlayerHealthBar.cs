using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [Tooltip("Image component dispplaying current health")]
        public Image healthFillImage;
        public Image batteryFillImage;

        Health m_PlayerHealth;


        PlayerCharacterController playerCharacterController;
        private void Start()
        {
            playerCharacterController = FindObjectOfType<PlayerCharacterController>();
            //DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

            m_PlayerHealth = playerCharacterController.GetComponent<Health>();
            m_PlayerHealth.onDamaged += UpdateHealthBar;
            playerCharacterController.playerWeaponsManagerScr.InitBatteryBar();
            UpdateBattertBar(0);

        }

        void Update()
        {
            // update health bar value
            //healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
        }

        public void UpdateHealthBar(float damage, GameObject source)
        {
            Debug.Log(m_PlayerHealth.currentHealth + " : " + damage);
            m_PlayerHealth.currentHealth = m_PlayerHealth.currentHealth - damage;
            if (m_PlayerHealth.currentHealth <= 0f)
            {
                PopUpCtrl.Instance.ShowPopUpWindow("You Lost", true);
                healthFillImage.fillAmount = 0;
            }
            else
            {
                healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
            }
        }

        public void UpdateBattertBar(int consume)
        {
            int curEnergy = playerCharacterController.playerWeaponsManagerScr.CurBattery - consume;
           // Debug.Log(curEnergy + " : " + playerCharacterController.playerWeaponsManagerScr.BatteryTotal);

           // Debug.Log(playerCharacterController.playerWeaponsManagerScr.name);
            batteryFillImage.fillAmount = (float)curEnergy / (float)playerCharacterController.playerWeaponsManagerScr.BatteryTotal;
        }
    }
}
