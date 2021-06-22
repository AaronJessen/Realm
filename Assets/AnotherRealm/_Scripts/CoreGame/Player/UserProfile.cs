using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class UserProfile : Singleton<UserProfile>
    {
        public UserData userData = new UserData();
        public Skill skillData;// = new SkillData();
        public UserConfig userConfigData;                           // Start is called before the first frame update
        public Chapter allChapter;

        override public void Awake()
        {
            base.Awake();
            skillData = Resources.Load<Skill>("Persistent/Skill");

            userConfigData = Resources.Load<UserConfig>("Persistent/UserConfig");

            allChapter = Resources.Load<Chapter>("Persistent/Chapter");

            Debug.Log("skillData " + skillData.dataArray.Length);
            if (!PlayerPrefs.HasKey("SkillLevelArcane"))
            {
                userData.SetSkillLevel("Arcane", 1);
            }

            LevelCtrl.WinEvent += WinResult;

        }

        private void OnDestroy()
        {
            LevelCtrl.WinEvent -= WinResult;
        }

        void WinResult(int level)
        {
            userData.CurrentEXP += Random.Range(10, 20);
            int index = Random.Range(0, skillData.dataArray.Length);
            string skillName = skillData.dataArray[index].Name;
            int nextSkillGem = userData.GetSkillGem(skillName) + Random.Range(1, 4);

            Debug.Log("WinResult UserProfile " + userData.CurrentEXP + " " + nextSkillGem);
            userData.SetSkillGem(skillName, nextSkillGem);

            //userData.Diamond += Random.Range(1, 5);
            //userData.Gold += Random.Range(10, 20);

            PopUpCtrl.Instance.ShowPopUpWindow("You Win", true);

            if (level == userData.CurrentUnlockEpisodeIndex)
            {
                userData.CurrentUnlockEpisodeIndex = level + 1;
            }
        }

        // Update is called once per frame
        void Update()
		{
            
		}
	}
}
