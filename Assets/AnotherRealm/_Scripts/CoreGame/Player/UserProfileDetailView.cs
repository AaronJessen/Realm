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

        public void ShowUserDetail()
        {
            gameObject.SetActive(true);
            skillPoolViewScr.ShowSkillPanel();
        }

        void Hide()
        {
            gameObject.SetActive(false);
        }
	}
}
