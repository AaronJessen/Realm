using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ARExplorer
{
	public class SpellCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public delegate void ShotToggleEventHandler(SkillData skillData);
        public static event ShotToggleEventHandler ShotToggleEvent;
        [SerializeField] int skillIndex;
        [SerializeField] int speed;
        [SerializeField] Image skillFreezeImg;

        [SerializeField] Image sourceImg;

        bool isReleased = false;
        bool canReleaseSkill = true;

        public float skillFreezeTime = 1f;
        public float pressDownTime = 0;
        [SerializeField] MagicProjectileScript curMagicProjectileScript;
        SkillData m_SkillData;
        // Start is called before the first frame update
        void Start()
		{
    	 	   
		}

        public void Display(SkillData skillData)
        {
            m_SkillData = skillData;
            skillFreezeTime = m_SkillData.CD;
            sourceImg.sprite = Resources.Load<Sprite>(PathProvider.rewardTexturePath + skillData.Name);
            sourceImg.SetNativeSize();
            sourceImg.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);

            if(UserProfile.Instance.userData.GetSkillLevel(skillData.Name) > 0)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
	
		// Update is called once per frame
		void Update()
   	 	{
            if (isReleased)
            {

                pressDownTime += Time.deltaTime;
                if (pressDownTime > skillFreezeTime)
                {
                    Debug.Log("isPress and shot");
                    isReleased = false;
                    canReleaseSkill = true;
                    //ShotToggleEvent?.Invoke(false);
                    pressDownTime = 0;
                    skillFreezeImg.fillAmount = 1f;
                }
                else
                {
                    skillFreezeImg.fillAmount = pressDownTime / skillFreezeTime;
                }
            }
   	 	}

        public void OnPointerDown(PointerEventData eventData)
        {
            if (canReleaseSkill)
            {
                canReleaseSkill = false;
                ShotToggleEvent?.Invoke(m_SkillData);
            }

            isReleased = true;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
        }


        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}
