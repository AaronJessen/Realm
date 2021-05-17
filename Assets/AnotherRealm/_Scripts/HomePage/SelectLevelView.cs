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
        Text levelText;
        int level;
        public delegate void SelectLevelEventHandler(int level);
        public static SelectLevelEventHandler SelectLevelEvent;
        // Start is called before the first frame update
        void Awake()
        {
            selectLevelBtn = GetComponent<Button>();
            levelText = GetComponentInChildren<Text>();
            selectLevelBtn.onClick.AddListener(SelcetLevel);

        }

        public void InitLevelView(int _level)
        {
            level = _level;
            levelText.text = "Level " + level.ToString();
        }

   	 	// Update is called once per frame
		void SelcetLevel()
		{
            SelectLevelEvent?.Invoke(level);

        }
	}
}
