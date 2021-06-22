using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class SpellBase : MonoBehaviour
	{

        public SkillData m_SkillData;

        public delegate void HitEnemyEventHanlder(GameObject hitEnemy, int damageValue);
        public static HitEnemyEventHanlder HitEnemyEvent;
        // Start is called before the first frame update
        void Start()
        {
            
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}
	}
}
