using UnityEngine;
using UnityEngine.Events;

namespace ARExplorer
{
    public class Health : MonoBehaviour
    {
        [Tooltip("Maximum amount of health")]
        public float maxHealth = 10f;
        [Tooltip("Health ratio at which the critical health vignette starts appearing")]
        public float criticalHealthRatio = 0.3f;

        public UnityAction<float> onDamaged;
        public UnityAction<float> onHealed;
        public UnityAction onDie;

        public float currentHealth { get; set; }
        public bool invincible { get; set; }
        //public bool canPickup() => currentHealth < maxHealth;

        //public float getRatio() => currentHealth / maxHealth;
        //public bool isCritical() => getRatio() <= criticalHealthRatio;

        bool m_IsDead;

        private void Start()
        {
            //currentHealth = maxHealth;

            //CrystleCtrl.HitCrystalEvent += TakeDamage;
            PlayerCharacterController.HitPlayerEvent += TakeDamage;
            
        }

        private void OnDestroy()
        {
            //CrystleCtrl.HitCrystalEvent -= TakeDamage;
            PlayerCharacterController.HitPlayerEvent -= TakeDamage;
        }
        //private void UpdateHealthBar(int damgage, )
        //{
        //    m_PlayerHealth.currentHealth = m_PlayerHealth.currentHealth - 1;
        //    healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
        //}

        //public void Heal(float healAmount)
        //{
        //    float healthBefore = currentHealth;
        //    currentHealth += healAmount;
        //    currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        //    // call OnHeal action
        //    float trueHealAmount = currentHealth - healthBefore;
        //    if (trueHealAmount > 0f && onHealed != null)
        //    {
        //        onHealed.Invoke(trueHealAmount);
        //    }
        //}

        public void TakeDamage(float damage, GameObject damageSource)
        {
            if (invincible)
                return;

            //float healthBefore = currentHealth;
            //currentHealth -= damage;
            //currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            //// call OnDamage action
            //float trueDamageAmount = healthBefore - currentHealth;
            if (damage > 0f && onDamaged != null)
            {
                onDamaged.Invoke(damage);
            }

           // HandleDeath();
        }

        //public void Kill()
        //{
        //    currentHealth = 0f;

        //    // call OnDamage action
        //    if (onDamaged != null)
        //    {
        //        onDamaged.Invoke(maxHealth);
        //    }

        //    HandleDeath();
        //}

        //private void HandleDeath()
        //{
        //    if (m_IsDead)
        //        return;

        //    // call OnDie action
        //    if (currentHealth <= 0f)
        //    {
        //        if (onDie != null)
        //        {
        //            m_IsDead = true;
        //            onDie.Invoke();
        //        }
        //    }
        //}
    }
}
