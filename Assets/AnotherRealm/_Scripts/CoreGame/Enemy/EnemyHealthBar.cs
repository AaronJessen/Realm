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
        public GameObject flyTxtPref;
        public RectTransform flyTxtPar;
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
            CurHealth = maxHealth;

        }

        void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
            //transform.LookAt(Camera.main.transform.position);
        }

        public void SetupHealthBar(float health)
        {
            maxHealth = health;
            CurHealth = maxHealth;
            healthFillImage.fillAmount = 1f;
        }

        public void UpdateHealthBar(int damage)
        {
            CurHealth -= damage;

            healthFillImage.fillAmount = CurHealth / maxHealth;

            GameObject tem = SimplePool.Spawn(flyTxtPref, Vector3.zero, Quaternion.identity);
            tem.transform.SetParent(flyTxtPar);

            tem.transform.localPosition = Vector3.zero;
            tem.transform.localEulerAngles = Vector3.zero;

            tem.GetComponent<Text>().text = "-" + damage.ToString();
        }
    }
}
