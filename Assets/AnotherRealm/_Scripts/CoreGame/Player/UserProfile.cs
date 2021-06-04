using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class UserProfile : Singleton<UserProfile>
    {
        public UserData userData = new UserData();
        public Skill skillData;// = new SkillData();
                                   // Start is called before the first frame update

        void Awake()
        {
            skillData = Resources.Load<Skill>("Persistent/Skill");
            Debug.Log("skillData " + skillData.dataArray.Length);
            //tem.dataArray[0].
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}
	}
}
