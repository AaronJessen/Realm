using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARExplorer
{
    public class MonsterBase : MonoBehaviour, IMonster
    {
        float m_speed;

        [SerializeField]
        public EnemyHealthBar enemyHealthBarScr;

        [SerializeField]
        GameObject m_Model;
        Animator m_Animator;
        
        MonsterState m_MonsterState;

        public delegate void MonsterDieEventHandle();
        public static event MonsterDieEventHandle MonsterDieEvent;

        // Start is called before the first frame update
        void Awake()
        {
            m_Animator = m_Model.GetComponent<Animator>();
            AddAnimationListner();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public virtual void Create(float speed)
        {
            //gameObject.AddComponent<BoxCollider>();
            m_MonsterState = MonsterState.Move;
            m_Animator = m_Model.GetComponent<Animator>();
            m_speed = speed;
           // spawnOffest = new Vector3(Random.Range(-20, 20), 0, 0);
            transform.localPosition = new Vector3(Random.Range(-50, 50), 0, 0);
            ShowToggle(false);
            enemyHealthBarScr.SetupHealthBar(10);
           // gameObject.SetActive(true);
            Debug.Log("Create base" + gameObject.name);

        }

        public virtual void Move()
        {
            //var lookPos = Camera.main.transform.position - transform.position;
            //lookPos.y = 0;
            //var rotation = Quaternion.LookRotation(lookPos);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 0.1f);

            transform.LookAt(Camera.main.transform.position, Vector3.up);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(movement), 10 * Time.deltaTime);

            if (m_MonsterState == MonsterState.Move)
            {
                
                //transform.position = Vector3.MoveTowards(transform.position, CrystleCtrl.Instance.transform.position, m_speed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, m_speed * Time.deltaTime * 5f);
                // Debug.Log("Move base" + gameObject.name);
            }
        }

        public virtual void ShowToggle(bool enable)
        {
            gameObject.SetActive(enable);
           // Debug.Log("ShowToggle base" + gameObject.name);
        }

        //private void UpdateHealthBar(float damage, GameObject source)
        //{
        //    enemyHealthBarScr.currentHealth = enemyHealthBarScr.currentHealth;
        //    healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
        //}

        public void EnterCrystleZone()
        {
            //gameObject.SetActive(false);
            //Debug.Log("EnterCrystleZone " + gameObject.name);
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    MoveForward("Fly Forward", false);
        //}

        private void OnTriggerExit(Collider collision)
        {
            m_MonsterState = MonsterState.Move;
            MoveForward("Fly Forward", true);
        }

        private void OnTriggerStay(Collider collision)
        {
            //collision.gameObject.GetComponent<CrystleCtrl>()
            //if (collision.tag == "SpotLightCollider")
            //{
            //    GetDamage("Take Damage");
            //    Debug.Log("OnTriggerEnter " + collision.gameObject.name);
            //}
            if (collision.tag == "Player")
            {
                m_MonsterState = MonsterState.Attack;
                //m_MonsterState = MonsterState.Attack;
                MoveForward("Fly Forward", false);
                Attack("Melee Attack");
                //HitCrystalEvent?.Invoke(1f, other.gameObject);
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Bullet")
            {
                GetDamage("Take Damage");
                SimplePool.Despawn(collision.gameObject);
                Debug.Log("OnTriggerEnter Bullet " + collision.gameObject.name);
            }
            if (collision.tag == "SpotLightCollider")
            {
                GetDamage("Take Damage");
                SimplePool.Despawn(collision.gameObject);
                Debug.Log("OnTriggerEnter " + collision.gameObject.name);
            }
            else if (collision.tag == "Player")
            {
                Debug.Log("OnTriggerEnter");
                m_MonsterState = MonsterState.Attack;
                MoveForward("Fly Forward", false);
            }
        }

        public virtual void MoveForward(string key, bool move)
        {
            m_Animator.SetBool(key, move);
        }

        public virtual void Attack(string key)
        {
            m_Animator.SetTrigger(key);
        }


        public virtual void GetDamage(string key)
        {
            if(m_MonsterState == MonsterState.Die)
            {
                return;
            }

            //gameObject.SetActive(false);
            Debug.Log("GetDamage");
            enemyHealthBarScr.UpdateHealthBar(1f);
            if (enemyHealthBarScr.CurHealth <= 0)
            {
                m_MonsterState = MonsterState.Die;
                Die("Die");
            }
            else
            {
                m_MonsterState = MonsterState.GetDamage;
                m_Animator.SetTrigger(key);

                StartCoroutine(MonsterGetHitIE());
            }


        }

        private IEnumerator MonsterGetHitIE()
        {
            yield return new WaitForSeconds(0.5f);
            transform.localScale = Vector3.zero;
            yield return new WaitForSeconds(2f);
            transform.localPosition = new Vector3(Random.Range(transform.localPosition.x - 10, transform.localPosition.x + 10), transform.localPosition.y, transform.localPosition.z);
            //gameObject.SetActive(true);
            transform.localScale = Vector3.one;
            m_MonsterState = MonsterState.Move;
        }


        public void GetDamageFinsih()
        {

        }


        public virtual void Die(string key)
        {
            MonsterDieEvent?.Invoke();
            m_Animator.SetTrigger(key);
        }
        AnimationClip clip;
        private void AddAnimationListner()
        {

            //Animator anim;
            AnimationEvent evt;
            evt = new AnimationEvent();

           // evt.intParameter = 12345;
            evt.time = 1.15f;
            evt.functionName = "DieAnimFinish";

            // get the animation clip and add the AnimationEvent
           // anim = GetComponent<Animator>();
            foreach (var ani in m_Animator.runtimeAnimatorController.animationClips)
            {
                clip = ani;
                if(ani.name == "Die")
                    clip.AddEvent(evt);
            }
        }

        //public void DieAnimFinish()
        //{
        //    Debug.Log("DieAnimFinish");
        //    gameObject.SetActive(false);
        //}
    }

    public interface IMonster
    {
        void Create(float speed);
        void Move();
        void Attack(string key);
        void GetDamage(string key);
        void Die(string key);
    }

    public enum MonsterState
    {
        Idle,
        Move,
        Attack,
        GetDamage,
        Die,

    }
}
