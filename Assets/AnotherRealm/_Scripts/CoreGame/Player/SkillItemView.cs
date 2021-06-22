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
        [SerializeField] Text levelTxt;

        [SerializeField] GameObject goldIndiObject;

        [SerializeField] Button upgradeSkillBtn;
        [SerializeField] Button testAddSkillBtn;
        [SerializeField] SkillPropertyView skillPropertyViewPref;
        [SerializeField] List<SkillPropertyView> skillTypePropertyViewList = new List<SkillPropertyView>();
        [SerializeField] List<SkillPropertyView> skillBasicPropertyViewList = new List<SkillPropertyView>();
        [SerializeField] RectTransform gridLayoutRT;

        SkillData m_skillData;
        Color greyColor = new Color(0.5f, 0.5f, 0.5f);
        // Start is called before the first frame update
        private void Start()
        {
            upgradeSkillBtn.onClick.AddListener(UpdateSkill);
            testAddSkillBtn.onClick.AddListener(TestAddGem);
        }

        void TestAddGem()
        {
            int nextSkillGem = UserProfile.Instance.userData.GetSkillGem(m_skillData.Name) + 1;
            UserProfile.Instance.userData.SetSkillGem(m_skillData.Name, nextSkillGem);
            DisplaySkillItem(m_skillData);
            //Debug.Log("WinResult UserProfile " + userData.Curre
        }

        void UpdateSkill()
        {
            if (UserProfile.Instance.userData.Gold > 50)
            {
                int curGem = UserProfile.Instance.userData.GetSkillGem(m_skillData.Name);
                int curSkillLevel = UserProfile.Instance.userData.GetSkillLevel(m_skillData.Name);

                UserProfile.Instance.userData.SetSkillGem(m_skillData.Name, curGem - m_skillData.Upgradegem[curSkillLevel]);
                UserProfile.Instance.userData.SetSkillLevel(m_skillData.Name, curSkillLevel + 1);
                DisplaySkillItem(m_skillData);
                UserProfile.Instance.userData.Gold -= 50;
            }

        }

   	 	// Update is called once per frame
		public void DisplaySkillItem(SkillData skillData)
		{
            m_skillData = skillData;
            InitSkillItem();
            sourceImg.sprite = Resources.Load<Sprite>(PathProvider.rewardTexturePath + skillData.Name);
            sourceImg.SetNativeSize();
            sourceImg.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
            nameTxt.text = skillData.Name;
            mpTxt.text = skillData.MP.ToString();

            int curSkillLevel = UserProfile.Instance.userData.GetSkillLevel(skillData.Name);

            Debug.Log("DisplaySkillItem " + curSkillLevel);

            MatchSkill(skillData.Skilltype[0], skillData.Skillvalue1[0]);

            MatchLevelUI(curSkillLevel, skillData.Name);

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

        void MatchLevelUI(int curSkillLevel, string name)
        {

            bool isMaxLevel = curSkillLevel >= m_skillData.Upgradegem.Length;
            if (isMaxLevel)
            {
                upgradeSkillBtn.interactable = false;

                levelTxt.gameObject.SetActive(true);//
                levelTxt.text = "Level " + curSkillLevel.ToString();
                upgradeGemTxt.text = "Max Level";
                sourceImg.color = greyColor;
                goldIndiObject.gameObject.SetActive(false);
                sourceImg.color = Color.white;

                gemPctTxt.text = UserProfile.Instance.userData.GetSkillGem(m_skillData.Name) + "/" + m_skillData.Upgradegem[m_skillData.Upgradegem.Length - 1].ToString();
                gemImg.fillAmount = 1f;
            }
            else
            {
                int requireValue = m_skillData.Upgradegem[curSkillLevel];
                Debug.Log("MatchLevelUI " + name + " : " + isMaxLevel);
                if (UserProfile.Instance.userData.GetSkillGem(name) >= requireValue && UserProfile.Instance.userData.Gold > 50)
                {
                    upgradeSkillBtn.interactable = true;
                }
                else
                {
                    upgradeSkillBtn.interactable = false;
                    // skillTypePropertyViewList[1].ShowSkillProperty("Shield", value);
                }
                goldIndiObject.gameObject.SetActive(true);

                if (curSkillLevel == 0)
                {
                    levelTxt.gameObject.SetActive(false);// = "Level " + curSkillLevel.ToString();

                    upgradeGemTxt.text = "Unlock Skill";
                    sourceImg.color = greyColor;
                }
                else
                {
                    levelTxt.gameObject.SetActive(true);//
                    levelTxt.text = "Level " + curSkillLevel.ToString();
                    sourceImg.color = Color.white;
                    upgradeGemTxt.text = "Level Up";
                }

                float gemPct = (float)UserProfile.Instance.userData.GetSkillGem(m_skillData.Name) / (float)m_skillData.Upgradegem[curSkillLevel];
                gemPctTxt.text = UserProfile.Instance.userData.GetSkillGem(m_skillData.Name) + "/" + m_skillData.Upgradegem[curSkillLevel].ToString();
                gemImg.fillAmount = gemPct;
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
