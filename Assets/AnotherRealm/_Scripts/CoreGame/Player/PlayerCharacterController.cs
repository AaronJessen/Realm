using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ARExplorer
{
    [RequireComponent(typeof(CharacterController), typeof(AudioSource))]
    public class PlayerCharacterController : MonoBehaviour
    {
        //[Header("References")]
        //[Tooltip("Reference to the main camera used for the player")]
        //public Camera playerCamera;
        [Tooltip("Audio source for footsteps, jump, etc...")]
        AudioSource audioSource;

        [Header("General")]
        [Tooltip("Force applied downward when in the air")]
        public float gravityDownForce = 20f;
        [Tooltip("Physic layers checked to consider the player grounded")]
        public LayerMask groundCheckLayers = -1;
        [Tooltip("distance from the bottom of the character controller capsule to test for grounded")]
        public float groundCheckDistance = 0.05f;
        public PlayerWeaponsManager playerWeaponsManagerScr;
        [SerializeField]
        PlayerPropertyBar playerPropertyBarScr;
        //public Button shotBtn;
        int curMP = 0;
        //int curHP = 0;
        public delegate void HitPlayerEventHandler(float damage, GameObject damageSource);
        public static event HitPlayerEventHandler HitPlayerEvent;

        void Start()
        {
            //shotBtn.onClick.AddListener(ShotToggle);
            //SpotLightCtrl.ShotToggleEvent += ShotToggle;
            //curMP = UserProfile.Instance.userData.MP;
            //curHP = UserProfile.Instance.userData.HP;
            SpellCtrl.ShotToggleEvent += Shot;
            InitPlyerSetting();
            //PlayerHealthBar
        }


        public void InitPlyerSetting()
        {
            curMP = UserProfile.Instance.userData.MP;
            //curHP = UserProfile.Instance.userData.HP;
            playerPropertyBarScr.InitPlayerProperty();
        }

        private void OnDestroy()
        {
            SpellCtrl.ShotToggleEvent -= Shot;
            //SpotLightCtrl.ShotToggleEvent -= ShotToggle;
        }

        public void Shot(SkillData skillData)
        {
            if (curMP >= skillData.MP)
            {
                curMP -= skillData.MP;
                playerPropertyBarScr.UpdateMPBar(curMP);
                playerWeaponsManagerScr.Shot(skillData);
            }
        }

        public bool isDead { get; private set; }
 

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.tag == "Enemy")
        //    {
        //        MonsterBase tem = other.gameObject.GetComponentInParent<MonsterBase>();
        //        HitPlayerEvent?.Invoke(1f, other.gameObject);
        //    }
        //}

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Enemy")
            {
                MonsterBase tem = other.gameObject.GetComponentInParent<MonsterBase>();
                HitPlayerEvent?.Invoke(1f, other.gameObject);
            }
        }
    }
}
