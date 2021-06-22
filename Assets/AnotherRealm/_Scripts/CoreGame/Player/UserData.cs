using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class UserData
	{
        string UserNameTag = "UserName";
        string CurrentEXPTag = "CurrentEXP";
        //string CurrentDiamondTag = "CurrentDiamond";
        string SkillGemTag = "SkillGem";
        string SkillLevelTag = "SkillLevel";
        string LevelTag = "Level";
        string CurrentChapterIndexTag = "CurrentChapterIndex";
        string CurrentUnlockEpisodeIndexTag = "CurrentUnlockEpisodeIndex";

        
        string DiamondTag = "Diamond";
        string GoldTag = "Gold";
        string StrengthTag = "Strength";


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
                if (value >= NextLevelEXP)
                {
                    value = value - NextLevelEXP;
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

        //public int CurrentDiamond
        //{
        //    get
        //    {
        //        return PlayerPrefs.GetInt(CurrentDiamondTag, 100);
        //    }
        //    set
        //    {
        //        PlayerPrefs.SetInt(CurrentDiamondTag, value);
        //    }
        //}
        

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

        public int CurrentUnlockEpisodeIndex
        {
            get
            {
                return PlayerPrefs.GetInt(CurrentUnlockEpisodeIndexTag, 0);
            }
            set
            {
                PlayerPrefs.SetInt(CurrentUnlockEpisodeIndexTag, value);
            }
        }

        public int Diamond
        {
            get
            {
                return PlayerPrefs.GetInt(DiamondTag, UserProfile.Instance.userConfigData.dataArray[0].Diamond);
            }
            set
            {
                PlayerPrefs.SetInt(DiamondTag, value);
            }
        }

        public int Strength
        {
            get
            {
                return PlayerPrefs.GetInt(StrengthTag, UserProfile.Instance.userConfigData.dataArray[0].Strength);
            }
            set
            {
                PlayerPrefs.SetInt(StrengthTag, value);
            }
        }

        public int Gold
        {
            get
            {
                return PlayerPrefs.GetInt(GoldTag, UserProfile.Instance.userConfigData.dataArray[0].Gold);
            }
            set
            {
                PlayerPrefs.SetInt(GoldTag, value);
            }
        }


        public int GetSkillGem(string name)
        {          
            return PlayerPrefs.GetInt(SkillGemTag + name, 0);
        }

        public void SetSkillGem(string name, int value)
        {
            string key = SkillGemTag + name;
            PlayerPrefs.SetInt(key, value);
        }

        public int GetSkillLevel(string name)
        {
            return PlayerPrefs.GetInt(SkillLevelTag + name, 0);
        }

        public void SetSkillLevel(string name, int value)
        {
            string key = SkillLevelTag + name;
            PlayerPrefs.SetInt(key, value);
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
