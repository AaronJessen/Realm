using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class PopUpCtrl : Singleton<PopUpCtrl>
	{
        PopUpWindowView messagePopUpViewScr;

        //[SerializeField]
        GameObject popupPrefab;

        //[SerializeField]
        GameObject popupParentPanel;
        private void Start()
        {
            //CreatePopUpPanel();
        }

        // Start is called before the first frame update
        void CreatePopUpPanel()
        {
            GameObject popupPrefab = Resources.Load<GameObject>("Prefab/MessagePanel");

            if (popupPrefab)
            {
        
                popupParentPanel = GameObject.Instantiate(popupPrefab) as GameObject;
                if (popupParentPanel)
                {
                    popupParentPanel.name = "popup";
                    messagePopUpViewScr = popupParentPanel.GetComponent<PopUpWindowView>();
                    
                    transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").GetComponent< Canvas>().transform);
                    gameObject.AddComponent<RectTransform>();
                    // gameObject.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left)

                    RectTransform popUpRect = gameObject.GetComponent<RectTransform>();

                    popUpRect.localPosition = Vector3.zero;
                    popUpRect.localScale = Vector3.one;
                    popUpRect.anchorMin = new Vector2(0f, 0f);
                    popUpRect.anchorMax = new Vector2(1f, 1f);
                    transform.SetAsLastSibling();
                }
            }
            RectTransform popupParentPanelRect = popupParentPanel.GetComponent<RectTransform>();
            popupParentPanel.transform.SetParent(this.transform);
            popupParentPanelRect.offsetMax = new Vector2(0f, 0f);
            popupParentPanelRect.offsetMin = new Vector2(0f, 0f);
            //popupParentPanelRect.anchorMax = new Vector2(1f, 1f);
            popupParentPanelRect.localScale = Vector3.one;
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}

        public void ShowPopUpWindow(string msg, bool success)
        {
            if (!popupParentPanel)
            {
                CreatePopUpPanel();
            }

            popupParentPanel.SetActive(true);
            messagePopUpViewScr.ShowMessage(msg, success);
        }


        public void CloseErrorPopUpWindow()
        {
            popupParentPanel.SetActive(false);
            messagePopUpViewScr.ExitWindow();
        }

        public void LoadingWindowToggle(bool toggle)
        {
            if (!popupParentPanel)
            {
                CreatePopUpPanel();
            }
            messagePopUpViewScr.ShowLoadingPanelToggle(toggle);
        }

        public void ShowTapToPlacePanel()
        {
            if (!popupParentPanel)
            {
                CreatePopUpPanel();
            }

            messagePopUpViewScr.TapToPlaceToggle();
        }

        public void ShowScnaingPanel(bool show)
        {
            if (!popupParentPanel)
            {
                CreatePopUpPanel();
            }

            messagePopUpViewScr.FindAndTapInstructionToggle(show);
        }

        public void BlockOtherAction(bool block)
        {
            if (!popupParentPanel)
            {
                CreatePopUpPanel();
            }
            messagePopUpViewScr.BlockOtherActionToggle(block);
        }
    }
}
