using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ARExplorer
{
    public class WeaponHUDManager : MonoBehaviour
    {
        //[Tooltip("UI panel containing the layoutGroup for displaying weapon ammos")]
        //public RectTransform ammosPanel;
        //[Tooltip("Prefab for displaying weapon ammo")]
        public SpellCtrl spellCtrlPrefab;
        List<SpellCtrl> spellCtrlList = new List<SpellCtrl>();

        //[SerializeField] Button baseShotBtn;
        //[SerializeField] Button skillShot1Btn;

        public delegate void BaseShotToggleEventHandler();
        public static event BaseShotToggleEventHandler BaseShotToggleEvent;

        //PlayerWeaponsManager m_PlayerWeaponsManager;
        //List<AmmoCounter> m_AmmoCounters = new List<AmmoCounter>();

        private void Start()
        {
            Display();
        }
        public void Display()
        {
            for (int i = 0; i < UserProfile.Instance.skillData.dataArray.Length; i++)
            {
                if (i >= spellCtrlList.Count)
                {
                    SpellCtrl tem = Instantiate<SpellCtrl>(spellCtrlPrefab, transform);
                    spellCtrlList.Add(tem);
                }

                spellCtrlList[i].Display(UserProfile.Instance.skillData.dataArray[i]);
            }
        }

        private void OrdinaryShow()
        {
            BaseShotToggleEvent?.Invoke();
        }

    }
}
