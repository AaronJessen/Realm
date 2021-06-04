using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class SkillPoolView : MonoBehaviour
	{
        [SerializeField] SkillItemView skillItemViewPref;
        List<SkillItemView> skillItemViewList = new List<SkillItemView>();
        [SerializeField] Transform skillItemTraPar;
        // Start is called before the first frame update
        void Start()
        {
            
        }

   	 	// Update is called once per frame
		public void ShowSkillPanel()
		{
            for(int i = 0; i < UserProfile.Instance.skillData.dataArray.Length; i++)
            {
                SkillItemView tem = Instantiate<SkillItemView>(skillItemViewPref, skillItemTraPar);

                skillItemViewList.Add(tem);
                skillItemViewList[i].DisplaySkillItem(UserProfile.Instance.skillData.dataArray[i]);
            }
		}
	}
}
