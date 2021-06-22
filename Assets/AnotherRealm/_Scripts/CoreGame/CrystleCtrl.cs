using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class CrystleCtrl : Singleton<CrystleCtrl>
	{
        public delegate void HitCrystalEventHandler(float damage, GameObject damageSource);
        public static event HitCrystalEventHandler HitCrystalEvent;

        // Start is called before the first frame update
        void Start()
		{
    	 	   
		}
	
		// Update is called once per frame
		void Update()
   	 	{
   	  	   
   	 	}
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.GetComponentInParent<MonsterBase>())
        //    {
        //        other.gameObject.GetComponentInParent<MonsterBase>().EnterCrystleZone();
        //        HitCrystalEvent?.Invoke(1f, other.gameObject);
        //    }
        //}
        //void OnCollisionEnter(Collision collision)
        //{

        //}
    }
}
