using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class SkillItemView : MonoBehaviour
	{
        [SerializeField] Image sourceImg;
        [SerializeField] Image gemImg;

        [SerializeField] Text nameTxt;
        [SerializeField] Text mpTxt;
        [SerializeField] Text upgradeGemTxt;
        [SerializeField] Text gemPctTxt;

        [SerializeField] Button upgradeSkillBtn;
        [SerializeField] SkillPropertyView skillPropertyViewPref;
        [SerializeField] List<SkillPropertyView> skillTypePropertyViewList = new List<SkillPropertyView>();
        [SerializeField] List<SkillPropertyView> skillBasicPropertyViewList = new List<SkillPropertyView>();
        [SerializeField] RectTransform gridLayoutRT;
        // Start is called before the first frame update
        void Start()
        {
            
        }

   	 	// Update is called once per frame
		public void DisplaySkillItem(SkillData skillData)
		{
            InitSkillItem();
            sourceImg.sprite = Resources.Load<Sprite>(PathProvider.skillTexturePath + skillData.Name);

            Debug.Log(PathProvider.skillTexturePath + skillData.Name);
            sourceImg.SetNativeSize();
            sourceImg.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
            nameTxt.text = skillData.Name;
            mpTxt.text = skillData.MP.ToString();
            int curSkillLevel = UserProfile.Instance.userData.GetSkillLevel(skillData.Name);


            float gemPct = (float)UserProfile.Instance.userData.GetSkillGem(skillData.Name) / (float)skillData.Upgradegem[curSkillLevel];

           // Debug.Log();
            gemPctTxt.text = UserProfile.Instance.userData.GetSkillGem(skillData.Name) + "/" + skillData.Upgradegem[curSkillLevel].ToString();
            gemImg.fillAmount = gemPct;

            MatchSkill(skillData.Skilltype[0], skillData.Skillvalue1[0]);

            MatchLevelUpBtn(skillData.Upgradegem[curSkillLevel], skillData.Name);

            if (skillData.Skilltype.Length == 2)
            {
                MatchSkill(skillData.Skilltype[1], skillData.Skillvalue2[0]);
            }

            skillBasicPropertyViewList[0].ShowSkillProperty("Cold Time", skillData.CD);
            skillBasicPropertyViewList[1].ShowSkillProperty("Speed", skillData.Speed);
            skillBasicPropertyViewList[2].ShowSkillProperty("Range", skillData.Range);
            LayoutRebuilder.ForceRebuildLayoutImmediate(gridLayoutRT);
            //gridLayout.
        }

        void MatchSkill(string slillType, int value)
        {
            if (slillType == "Heal")
            {
                skillTypePropertyViewList[0].ShowSkillProperty("Heal", value);
            }
            if (slillType == "Shield")
            {
                skillTypePropertyViewList[1].ShowSkillProperty("Shield", value);
            }
            if (slillType == "Freeze")
            {
                skillTypePropertyViewList[2].ShowSkillProperty("Freeze", value);
            }
            if (slillType == "AOE")
            {
                skillTypePropertyViewList[3].ShowSkillProperty("AOE", value);
            }
            if (slillType == "AD")
            {
                skillTypePropertyViewList[4].ShowSkillProperty("Attack", value);
            }

        }

        void MatchLevelUpBtn(int requireValue, string name)
        {
            if (UserProfile.Instance.userData.GetSkillGem(name) >= requireValue)
            {
                upgradeGemTxt.text = "Level Up";
                upgradeSkillBtn.interactable = true;
            }
            else 
            {
                upgradeGemTxt.text = "Level Up";
                upgradeSkillBtn.interactable = false;
                // skillTypePropertyViewList[1].ShowSkillProperty("Shield", value);
            }
 

        }


        void InitSkillItem()
        {
            foreach(var skillTypeProperty in skillTypePropertyViewList)
            {
                skillTypeProperty.HideSkill();
            }

            foreach (var skillBasicProperty in skillBasicPropertyViewList)
            {
                skillBasicProperty.HideSkill();
            }
        }
	}
}
