using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Vuforia;
namespace ARExplorer
{
    public class ARPanelView : MonoBehaviour
    {
        [SerializeField]
        private Button ExitButton;
        [SerializeField] Text levelText;
        // Start is called before the first frame update
        void Awake()
        {
            ExitButton.onClick.AddListener(ExitToHome);
            LevelCtrl.LoadLevelEvent += InitiARPanel;

        }

        private void OnDestroy()
        {
            LevelCtrl.LoadLevelEvent -= InitiARPanel;
        }
        // Update is called once per frame
        void InitiARPanel(LevelBuilder selectedLevel)
        {
            levelText.text = selectedLevel.levelName;
        }

        public void ExitToHome()
        {
           // GameManager.Instance.VuforiaToggle(false);
            LoadScene.JumpToScene(0);
        }
    }
}
