using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ARExplorer
{
	public class SpotLightCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public delegate void ShotToggleEventHandler(int index);
        public static event ShotToggleEventHandler ShotToggleEvent;
        [SerializeField] int skillIndex;
        [SerializeField] int speed;
        [SerializeField] Image skillFreezeImg;
        bool isReleased = false;
        bool canReleaseSkill = true;

        public float skillFreezeTime = 1f;
        public float pressDownTime = 0;
        [SerializeField] MagicProjectileScript curMagicProjectileScript;
        // Start is called before the first frame update
        void Start()
		{
    	 	   
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
                ShotToggleEvent?.Invoke(skillIndex);
            }

            isReleased = true;
            //isPress = true;
            ////ShotToggleEvent?.Invoke(true);
            ////LongPress(true);
            //Debug.Log("按下");
        }
        public void OnPointerUp(PointerEventData eventData)
        {
           // isDown = false;
            //isPress = false;
            //ShotToggleEvent?.Invoke(false);
            Debug.Log("抬起");
            //if (IsStart)
            //{
            //    LongPress(false);
            //    Debug.Log("抬起");
            //}
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            //isDown = false;
            //isPress = false;

        }
    }
}
