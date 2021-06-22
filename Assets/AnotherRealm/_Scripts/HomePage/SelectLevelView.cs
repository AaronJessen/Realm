using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ARExplorer
{
    [RequireComponent(typeof(Button))]
	public class SelectLevelView : MonoBehaviour
	{

        Button selectLevelBtn;
        [SerializeField] Text nameText;
        [SerializeField] Text desText;
        [SerializeField] Text rewardText;
        [SerializeField] GameObject blockObject;
        [SerializeField] Image sourceImg;

        int level;
        public delegate void SelectLevelEventHandler(int level);
        public static SelectLevelEventHandler SelectLevelEvent;
        // Start is called before the first frame update
        void Awake()
        {
            selectLevelBtn = GetComponent<Button>();
            //levelText = GetComponentInChildren<Text>();
            selectLevelBtn.onClick.AddListener(SelcetLevel);

        }

        public void InitLevelView(ChapterData chapterData)
        {
            sourceImg.sprite = Resources.Load<Sprite>(PathProvider.levelTexturePath + chapterData.Episodeindex);

            level = chapterData.Episodeindex;
            nameText.text = chapterData.Name;
            desText.text = chapterData.Description;
            for (int i = 0; i < chapterData.Reward.Length; i++)
            {
                rewardText.text += chapterData.Reward[i].ToString();
            }

            //Debug.Log(UserProfile.Instance.userData.CurrentEpisodeIndex + " " + chapterData.Episodeindex);
            if(UserProfile.Instance.userData.CurrentUnlockEpisodeIndex >= chapterData.Episodeindex)
            {
                blockObject.SetActive(false);
            }
            else
            {
                blockObject.SetActive(true);
            }
        }

   	 	// Update is called once per frame
		void SelcetLevel()
		{
            if (UserProfile.Instance.userData.Strength >= 3)
            {
                MapPanelView.curLevel = level;
                UserProfile.Instance.userData.Strength -= 3;
                SelectLevelEvent?.Invoke(level);
            }
            else
            {
                PopUpCtrl.Instance.ShowPopUpWindow("Not Enough Strength", false);
            }

        }
	}
}
