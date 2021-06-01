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
        public static int curLevel = 6;

        List<SelectLevelView> selectLevelViewList = new List<SelectLevelView>();
        // Start is called before the first frame update
        void Awake()
        {
            for(int i = 0; i < 10; i++)
            {
                SelectLevelView tem = Instantiate<SelectLevelView>(selectLevelViewPrefab, Vector3.zero, Quaternion.identity, levelViewPar);
                tem.InitLevelView(i+1);
                selectLevelViewList.Add(tem);
            }
            SelectLevelView.SelectLevelEvent += EnterLevelMode;

           // EnterButton.onClick.AddListener(EnterARMode);
        }

        private void OnDestroy()
        {
            SelectLevelView.SelectLevelEvent -= EnterLevelMode;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void EnterLevelMode(int level)
        {
            curLevel = level;
           // GameManager.Instance.VuforiaToggle(true);
            LoadScene.JumpToScene(1);
        }


    }
}
