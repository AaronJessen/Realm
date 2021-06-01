﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class UserData
	{
        string UserNameTag = "UserName";
        string CurrentEXPTag = "CurrentEXP";
        string LevelTag = "Level";

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
    }
}
