using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ARExplorer
{
	public class SpotLightCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public delegate void ShotToggleEventHandler(bool shot);
        public static event ShotToggleEventHandler ShotToggleEvent;

        bool isDown = false;
        bool isPress = false;

        public float pressThresholdTime = 0.001f;
        public float pressDownTime = 0;
        // Start is called before the first frame update
        void Start()
		{
    	 	   
		}
	
		// Update is called once per frame
		void Update()
   	 	{
            if (isPress)
            {

                pressDownTime += Time.deltaTime;
                if (pressDownTime > pressThresholdTime)
                {
                    Debug.Log("isPress and shot");
                    ShotToggleEvent?.Invoke(false);
                    pressDownTime = 0;
                }
            }
   	 	}

        public void OnPointerDown(PointerEventData eventData)
        {
            isDown = true;
            isPress = true;
            ShotToggleEvent?.Invoke(true);
            //LongPress(true);
            Debug.Log("按下");
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            isDown = false;
            isPress = false;
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
