using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class UserProfileView : MonoBehaviour
	{
        [SerializeField] Image profileImg;
        [SerializeField] Button profileBtn;
        [SerializeField] Image expImg;
        [SerializeField] Text usetNameTxt;
        [SerializeField] Text expTxt;
        [SerializeField] Text levelTxt;
        [SerializeField] Text hpTxt;
        [SerializeField] GameObject lockObject;
        [SerializeField] UserProfileDetailView userProfileDetailViewScr;

        //void Aw
        // Start is called before the first frame update
        void Start()
        {
            profileBtn.onClick.AddListener(ShowUserDetail);
            UpdateUserData();
        }

   	 	// Update is called once per frame
		void ShowUserDetail()
		{
            if (userProfileDetailViewScr != null)
            {
                userProfileDetailViewScr.ShowUserDetail();

            }
            UpdateUserData();
        }

        void UpdateUserData()
        {
            levelTxt.text = UserProfile.Instance.userData.Level.ToString();
            expTxt.text = UserProfile.Instance.userData.CurrentEXP.ToString() + "/" + UserProfile.Instance.userData.NextLevelEXP.ToString();
            expImg.fillAmount = (float)UserProfile.Instance.userData.CurrentEXP / (float)UserProfile.Instance.userData.NextLevelEXP;
        }
	}
}
