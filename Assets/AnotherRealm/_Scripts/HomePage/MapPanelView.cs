using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ARExplorer
{
    public class MapPanelView : MonoBehaviour
    {

        [SerializeField] SelectLevelView selectLevelViewPrefab;
        [SerializeField] RectTransform levelViewPar;
        //[SerializeField] Chapter allChapter;

        List<List<ChapterData>> allChapterDataList = new List<List<ChapterData>>();
        List<SelectLevelView> selectLevelViewList = new List<SelectLevelView>();
        public static int curLevel = 0;

        // Start is called before the first frame update
        void Awake()
        {
            for (int i = 0; i < UserProfile.Instance.allChapter.dataArray.Length; i++)
            {
                int chapterIndex = UserProfile.Instance.allChapter.dataArray[i].Chpaterindex;
                if (chapterIndex >= allChapterDataList.Count) {
                    allChapterDataList.Add(new List<ChapterData>());
                }
                //Debug.Log(allChapterDataList.Count + " : " + chapterIndex);
                allChapterDataList[chapterIndex].Add(UserProfile.Instance.allChapter.dataArray[i]);


            }
            for (int i = 0; i < allChapterDataList[UserProfile.Instance.userData.CurrentChapterIndex].Count; i++)
            {
                SelectLevelView tem = Instantiate<SelectLevelView>(selectLevelViewPrefab, Vector3.zero, Quaternion.identity, levelViewPar);
                tem.InitLevelView(allChapterDataList[UserProfile.Instance.userData.CurrentChapterIndex][i]);
                selectLevelViewList.Add(tem);
            }
            SelectLevelView.SelectLevelEvent += EnterLevelMode;
        }

        private void OnDestroy()
        {
            SelectLevelView.SelectLevelEvent -= EnterLevelMode;
           // LevelCtrl.WinEvent -= WinResult;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void EnterLevelMode(int level)
        {
            curLevel = level;
            LoadScene.JumpToScene(1);
        }


    }
}
