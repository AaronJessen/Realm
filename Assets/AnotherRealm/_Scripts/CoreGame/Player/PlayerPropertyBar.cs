using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
    public class PlayerPropertyBar : MonoBehaviour
    {
        [Tooltip("Image component dispplaying current health")]
        public Image healthFillImage;
        public Image batteryFillImage;

        Health m_PlayerHealth;

        [SerializeField] GameObject playerGetHitEffect;
        PlayerCharacterController playerCharacterController;
        private void Start()
        {
            playerCharacterController = FindObjectOfType<PlayerCharacterController>();
            //DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

            m_PlayerHealth = playerCharacterController.GetComponent<Health>();
            m_PlayerHealth.onDamaged += UpdateHealthBar;
            // playerCharacterController.playerWeaponsManagerScr.InitBatteryBar();
            //UpdateMPBar(UserProfile.Instance.userData.MP);
            //InitPlayerProperty();

        }

        private void OnDestroy()
        {
            m_PlayerHealth.onDamaged -= UpdateHealthBar;
        }

        public void InitPlayerProperty()
        {
            UpdateMPBar(UserProfile.Instance.userData.MP);
            m_PlayerHealth.currentHealth = UserProfile.Instance.userData.HP;
            healthFillImage.fillAmount = 1f;
            //UpdateHealthBar(0);
        }

        void Update()
        {
            // update health bar value
            //healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
        }

        public void UpdateHealthBar(float damage)
        {
//          Debug.Log(m_PlayerHealth.currentHealth + " : " + damage);
            m_PlayerHealth.currentHealth = m_PlayerHealth.currentHealth - damage;
            if (m_PlayerHealth.currentHealth <= 0f)
            {
                PopUpCtrl.Instance.ShowPopUpWindow("You Lost", false);
                healthFillImage.fillAmount = 0;
            }
            else
            {
                healthFillImage.fillAmount = m_PlayerHealth.currentHealth / (float)UserProfile.Instance.userData.HP;
                StartCoroutine(HitEffectIE());
            }
        }

        private IEnumerator HitEffectIE()
        {
            playerGetHitEffect.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            playerGetHitEffect.gameObject.SetActive(false);
        }

        public void UpdateMPBar(int curMP)
        {
            //int curEnergy = playerCharacterController.playerWeaponsManagerScr.CurBattery - consume;
            batteryFillImage.fillAmount = (float)curMP / (float)UserProfile.Instance.userData.MP;
        }
    }
}
