using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class RemindUIHelper : Singleton<RemindUIHelper>
	{
        [SerializeField]
        GameObject RemindPanel;
        [SerializeField]
        Text RemindText;
  	  	// Start is called before the first frame update
  	  	void Start()
        {
            RemindPanel.SetActive(false);
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}

        Coroutine ShowUpRemindCoroutine;
        public void ShowUpRemind(string remindText)
        {
            RemindPanel.SetActive(true);
            RemindText.text = remindText;
            if(ShowUpRemindCoroutine != null)
            {
                StopCoroutine(ShowUpRemindCoroutine);
            }
            ShowUpRemindCoroutine = StartCoroutine(ShowUpRemindIe());
        }

        void CloseRemindPanel()
        {
            RemindPanel.SetActive(false);
        }

        private IEnumerator ShowUpRemindIe()
        {
            yield return new WaitForSeconds(1f);
            CloseRemindPanel();
        }
    }

}
