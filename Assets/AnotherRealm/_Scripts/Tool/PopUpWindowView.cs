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
        Button NextOrRetryBtn;
        [SerializeField] Text NextOrRetryTxt;
        [SerializeField]
        LoadingHelper loadingHelperScr;
        [SerializeField]
        GameObject messagePanel;
        [SerializeField]
        Transform rewardPanel;
        [SerializeField]
        RewardItemView rewardItemViewPref;

        List<RewardItemView> rewardItemViewList = new List<RewardItemView>();

        //[SerializeField]
        //ARScaningPopupWindow ARScaningPopupWindowScr;
        //GameObject scaningPanel;

        [SerializeField]
        Image selfImage;


        // Start is called before the first frame update
        void Start()
        {
            ExitMessageWindowBtn.onClick.AddListener(ExitWindow);
            NextOrRetryBtn.onClick.AddListener(NextOrRetryLevel);
            //NextLevelTxt = NextLevelBtn.GetComponentInChildren<Text>();
        }

        private void Awake()
        {
            
        }

        // Update is called once per frame
        void Update()
		{
            
		}

        //public void ShowWinWindow(int[] Reward, int[] RewardValue)
        //{

        //}

        public void ShowMessage(string msg, bool success = true)
        {
            mainMessageText.text = msg;
            selfImage.enabled = true;
            //ExitMessageWindowBtn.gameObject.SetActive(false);
            //NextLevelBtn.gameObject.SetActive(false);
            rewardPanel.gameObject.SetActive(success);
            int curLevel = MapPanelView.curLevel; //UserProfile.Instance.userData.CurrentUnlockEpisodeIndex;
            if (success)
            {
                ///NextLevelBtn.gameObject.SetActive(true);
                NextOrRetryTxt.text = "Next";
                titleMessageText.text = "Success";
                additionalMessageText.gameObject.SetActive(false);
                resultImage.gameObject.SetActive(false);
                int[] reward = UserProfile.Instance.allChapter.dataArray[curLevel].Reward;
                int[] rewardValue = UserProfile.Instance.allChapter.dataArray[curLevel].Rewardvalue;
                //Debug.Log("reward " + reward.Length + " : " + rewardValue.Length + " " + rewardItemViewList.Count);
                for (int i = 0; i < reward.Length; i++)
                {
                    if (i >= rewardItemViewList.Count)
                    {
                        RewardItemView tem = Instantiate<RewardItemView>(rewardItemViewPref, rewardPanel);
                        rewardItemViewList.Add(tem);
                    }
                    string rewardName = GetReward(reward[i], rewardValue[i]);
                    rewardItemViewList[i].Show(rewardName, rewardValue[i]);

                }
                MapPanelView.curLevel += 1;

            }
            else
            {
                NextOrRetryTxt.text = "Retry";
                titleMessageText.text = "Opps";
                additionalMessageText.gameObject.SetActive(true);
                resultImage.gameObject.SetActive(true);


            }
            messagePanel.SetActive(true);
            gameObject.SetActive(true);
        }

        private string GetReward(int key, int value)
        {
            string displyName = "";
            if(key == 1)
            {
                displyName = "diamond";
                UserProfile.Instance.userData.Diamond += value;
            }
            else if (key == 2)
            {
                displyName = "gold";
                UserProfile.Instance.userData.Gold += value;
            }
            else if (key == 3)
            {
                displyName = "strength";
                UserProfile.Instance.userData.Strength += value;
            }
            return displyName;

        }

        public void ExitWindow()
        {
            selfImage.enabled = true;
            messagePanel.SetActive(false);
            gameObject.SetActive(false);
            LoadScene.JumpToScene(0);
            // ARScaningPopupWindowScr.gameObject.SetActive(false);
        }

        private void NextOrRetryLevel()
        {
            selfImage.enabled = true;
            messagePanel.SetActive(false);
            gameObject.SetActive(false);


            //LoadScene.JumpToScene(1);

            FindObjectOfType<PlayerCharacterController>().InitPlyerSetting();
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
