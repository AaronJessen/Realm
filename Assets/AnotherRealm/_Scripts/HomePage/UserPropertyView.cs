using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class UserPropertyView : MonoBehaviour
	{
        [SerializeField] Text diamondTxt;
        [SerializeField] Text goldTxt;
        [SerializeField] Text strengthTxt;

        // Start is called before the first frame update
        void Start()
        {
            UpdateUI();
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}

        public void UpdateUI()
        {
            diamondTxt.text = UserProfile.Instance.userData.Diamond.ToString();
            goldTxt.text = UserProfile.Instance.userData.Gold.ToString();
            strengthTxt.text = UserProfile.Instance.userData.Strength.ToString();
        }
	}
}
