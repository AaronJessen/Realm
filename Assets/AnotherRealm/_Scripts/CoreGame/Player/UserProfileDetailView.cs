using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class UserProfileDetailView : MonoBehaviour
	{
        [SerializeField] Button exitBtn;
  	  	// Start is called before the first frame update
  	  	void Start()
        {
            exitBtn.onClick.AddListener(Hide);
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}

        public void ShowUserDetail()
        {
            gameObject.SetActive(true);
        }

        void Hide()
        {
            gameObject.SetActive(false);
        }
	}
}
