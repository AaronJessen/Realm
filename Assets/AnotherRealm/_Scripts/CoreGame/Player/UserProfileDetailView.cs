using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class UserProfileDetailView : MonoBehaviour
	{
        [SerializeField] Button exitBtn;
        [SerializeField] SkillPoolView skillPoolViewScr;
        [SerializeField] UserProfileView userProfileViewScr;
        [SerializeField] Text hpText;
        [SerializeField] Text mpText;
        // Start is called before the first frame update
        void Start()
        {
            exitBtn.onClick.AddListener(Hide);
            gameObject.SetActive(false);
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}

        private void ShowUserInfo()
        {
            hpText.text = UserProfile.Instance.userData.HP.ToString();
            mpText.text = UserProfile.Instance.userData.MP.ToString();
            userProfileViewScr.ShowUserInfo();
        }

        public void ShowUserDetail()
        {
            gameObject.SetActive(true);
            ShowUserInfo();
            skillPoolViewScr.ShowSkillPanel();
        }

        void Hide()
        {
            gameObject.SetActive(false);
        }
	}
}
