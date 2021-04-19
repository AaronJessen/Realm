using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class EnemyHealthBar : MonoBehaviour
	{
        [Tooltip("Image component dispplaying current health")]
        public Image healthFillImage;

        //Health m_PlayerHealth;
        float curHealth = 10;
        public float CurHealth
        {
            get { return curHealth; }
            private set { curHealth = value; }
        }

        float maxHealth = 10;
        private void Awake()
        {
            //PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
            ////DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

            //m_PlayerHealth = playerCharacterController.GetComponent<Health>();
            //m_PlayerHealth.onDamaged += UpdateHealthBar;
            curHealth = maxHealth;

        }

        void Update()
        {
            transform.LookAt(Camera.main.transform.position);
            // update health bar value
            //healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
        }

        public void SetupHealthBar(float health)
        {
            maxHealth = health;
            curHealth = maxHealth;
        }

        public void UpdateHealthBar(float damage)
        {
            curHealth -= damage;
            healthFillImage.fillAmount = curHealth / maxHealth;
        }
    }
}
