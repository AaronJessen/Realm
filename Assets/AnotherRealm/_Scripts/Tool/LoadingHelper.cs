using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class LoadingHelper : Singleton<LoadingHelper>
	{
        public GameObject LoadingBlockPanel;
  	  	// Start is called before the first frame update
  	  	void Start()
        {
            //LoadingHelper.Instance.ShowLoadingPanel(false);
            //gameObject.SetActive(false);
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}

        public void ShowLoadingPanel(bool show)
        {
            LoadingBlockPanel.SetActive(show);
        }
	}
}
