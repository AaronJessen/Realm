using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class UserData
	{
        string UserNameTag = "UserName";
        string CurrentEXPTag = "CurrentEXP";
        string CurrentDiamondTag = "CurrentDiamond";
        string SkillGemTag = "SkillGem";
        string SkillLevelTag = "SkillLevel";
        string LevelTag = "Level";
        string CurrentChapterIndexTag = "CurrentChapterIndex";
        string CurrentEpisodeIndexTag = "CurrentEpisodeIndex";

        
        string MobileTag = "Mobile";
        string CodeTag = "Code";

        string LastNameTag = "LastName";


        public delegate void LevelUpEventHandle();
        public static event LevelUpEventHandle LevelUpEvent;

        public string UserName
        {
            get
            {
                return PlayerPrefs.GetString(UserNameTag);
            }
            set
            {
                PlayerPrefs.SetString(UserNameTag, value);
            }
        }

        public int CurrentEXP
        {
            get
            {
                return PlayerPrefs.GetInt(CurrentEXPTag);
            }
            set
            {
                if (CurrentEXP >= NextLevelEXP)
                {
                    CurrentEXP = CurrentEXP - NextLevelEXP;
                    Level++;
                    LevelUpEvent?.Invoke();
                }

                PlayerPrefs.SetInt(CurrentEXPTag, value);
            }
        }

        public int NextLevelEXP
        {
            get
            {
                return Level * 10;
            }
            //set
            //{
            //    PlayerPrefs.SetInt(CurrentEXPTag, value);
            //}
        }
        public int MP
        {
            get
            {
                return Level * 20;
            }
        }

        public int HP
        {
            get
            {
                return Level * 30;
            }
        }
        //CurrentMPTag
        public int Level
        {
            get
            {
                return PlayerPrefs.GetInt(LevelTag, 1);
            }
            set
            {
                PlayerPrefs.SetInt(LevelTag, value);
            }
        }

        public int CurrentDiamond
        {
            get
            {
                return PlayerPrefs.GetInt(CurrentDiamondTag, 100);
            }
            set
            {
                PlayerPrefs.SetInt(CurrentDiamondTag, value);
            }
        }
        

        public int CurrentChapterIndex
        {
            get
            {
                return PlayerPrefs.GetInt(CurrentChapterIndexTag, 0);
            }
            set
            {
                PlayerPrefs.SetInt(CurrentChapterIndexTag, value);
            }
        }

        public int CurrentEpisodeIndex
        {
            get
            {
                return PlayerPrefs.GetInt(CurrentEpisodeIndexTag, 0);
            }
            set
            {
                PlayerPrefs.SetInt(CurrentEpisodeIndexTag, value);
            }
        }

        public int GetSkillGem(string name)
        {          
            return PlayerPrefs.GetInt(SkillGemTag + name, 0);
        }

        public void AddSkillGem(string name, int value)
        {
            string key = SkillGemTag + name;
            PlayerPrefs.SetInt(key, GetSkillGem(name) + value);
        }

        public int GetSkillLevel(string name)
        {
            return PlayerPrefs.GetInt(SkillLevelTag + name, 0);
        }

        public void AddSkillLevel(string name, int value)
        {
            string key = SkillLevelTag + name;
            PlayerPrefs.SetInt(key, GetSkillLevel(name) + value);
        }

    }

}

public enum SkillType
{
    AD,
    Freeze,
    Heal,
    Shield,
    AOE
}
