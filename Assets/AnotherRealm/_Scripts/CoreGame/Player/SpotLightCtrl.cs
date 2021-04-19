using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ARExplorer
{
	public class SpotLightCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
        public delegate void ShotToggleEventHandler(bool shot);
        public static event ShotToggleEventHandler ShotToggleEvent;


        // Start is called before the first frame update
        void Start()
		{
    	 	   
		}
	
		// Update is called once per frame
		void Update()
   	 	{
   	  	   
   	 	}

        public void OnPointerDown(PointerEventData eventData)
        {
            ShotToggleEvent?.Invoke(true);
            //LongPress(true);
            Debug.Log("按下");
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            ShotToggleEvent?.Invoke(false);
            Debug.Log("抬起");
            //if (IsStart)
            //{
            //    LongPress(false);
            //    Debug.Log("抬起");
            //}
        }
    }
}
