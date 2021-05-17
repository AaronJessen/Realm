using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class PopUpWindowView : MonoBehaviour
	{
        [SerializeField]
        Text mainMessageText;
        [SerializeField]
        Text additionalMessageText;
        [SerializeField]
        Text titleMessageText;

        [SerializeField]
        Image resultImage;

        [SerializeField]
        Button ExitMessageWindowBtn;

        [SerializeField]
        Button NextLevelBtn;

        [SerializeField]
        LoadingHelper loadingHelperScr;
        [SerializeField]
        GameObject messagePanel;

        //[SerializeField]
        //ARScaningPopupWindow ARScaningPopupWindowScr;
        //GameObject scaningPanel;

        [SerializeField]
        Image selfImage;


        // Start is called before the first frame update
        void Start()
        {
            ExitMessageWindowBtn.onClick.AddListener(ExitWindow);
            NextLevelBtn.onClick.AddListener(NextLevel);
        }

        private void Awake()
        {
            
        }

        // Update is called once per frame
        void Update()
		{
            
		}


        public void ShowMessage(string msg, bool success = true)
        {
            mainMessageText.text = msg;
            selfImage.enabled = true;
            //ExitMessageWindowBtn.gameObject.SetActive(false);
            NextLevelBtn.gameObject.SetActive(false);
            if (success)
            {
                NextLevelBtn.gameObject.SetActive(true);
                titleMessageText.text = "Success";
                additionalMessageText.gameObject.SetActive(false);
                resultImage.gameObject.SetActive(false);
            }
            else
            {
                titleMessageText.text = "Opps";
                additionalMessageText.gameObject.SetActive(true);
                resultImage.gameObject.SetActive(true);


            }
            messagePanel.SetActive(true);
            gameObject.SetActive(true);
        }

        public void ExitWindow()
        {
            selfImage.enabled = true;
            messagePanel.SetActive(false);
            gameObject.SetActive(false);
            LoadScene.JumpToScene(0);
            // ARScaningPopupWindowScr.gameObject.SetActive(false);
        }

        private void NextLevel()
        {
            selfImage.enabled = true;
            messagePanel.SetActive(false);
            gameObject.SetActive(false);

            MapPanelView.curLevel += 1;
            FindObjectOfType<LevelCtrl>().LoadLevel(MapPanelView.curLevel);
            //LoadScene.JumpToNextLevel(1);
        }

        public void ShowLoadingPanelToggle(bool toggle)
        {
            selfImage.enabled = true;
            gameObject.SetActive(toggle);
            loadingHelperScr.ShowLoadingPanel(toggle);
        }

        public void FindAndTapInstructionToggle(bool show)
        {
            selfImage.enabled = false;
            gameObject.SetActive(show);
            //ARScaningPopupWindowScr.gameObject.SetActive(show);
        }

        public void TapToPlaceToggle()
        {
            gameObject.SetActive(true);
            selfImage.enabled = false;
            //gameObject.SetActive(show);
           // ARScaningPopupWindowScr.gameObject.SetActive(true);
           // ARScaningPopupWindowScr.TapToPlaceAni();
        }

        public void BlockOtherActionToggle(bool block)
        {
            selfImage.enabled = block;
        }

    }
}
